using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class ZoomCam : MonoBehaviour
{
    public Transform CubeTransform;

    public AudioMixer AudMixerMain;
    public AudioMixer AudMixerSub;

    float LPFrequencyMain;
    float LPFrequencySub;

    void Start()
    {
        LPFrequencyMain = LPFrequencySub = 22000;
    }

    void LateUpdate()
    {
        PowerUpManager powerUpManager = GameObject.Find("PowerUpSpawn").GetComponent<PowerUpManager>();

        if (powerUpManager.IsPowered)
        {
            Vector3 cubePosition = CubeTransform.position;
            cubePosition.z = cubePosition.z - 10;
            CameraLerp(Camera.main.orthographicSize, 2.5f,
                Camera.main.transform.position, cubePosition);

            LowPassFilter(600, 0.9f, AudMixerMain, "LowPass", "SlideDown", ref LPFrequencyMain);
            LowPassFilter(5000, 0.75f, AudMixerSub, "LowPassSub", "SlideDown", ref LPFrequencySub);
        }
        else
        {
            Vector3 defaultPosition = new Vector3(0, 0, -10);
            CameraLerp(Camera.main.orthographicSize, 3.6f, 
                Camera.main.transform.position, defaultPosition);

            LowPassFilter(22000, 1.25f, AudMixerMain, "LowPass", "SlideUp", ref LPFrequencyMain);
            LowPassFilter(22000, 1.1f, AudMixerSub, "LowPassSub", "SlideUp", ref LPFrequencySub);
        }
    }

    private void CameraLerp(float fromCamSize, float toCamSize, Vector3 fromPosition, Vector3 toPosition)
    {
        Camera.main.orthographicSize = Mathf.Lerp(fromCamSize, toCamSize, 0.08f);
        Camera.main.transform.position = Vector3.Lerp(fromPosition, toPosition, 0.08f);
    }

    private void LowPassFilter(float endLimit, float rate, AudioMixer mixer, string effect, string slider, ref float frequency)
    {
        if (slider == "SlideDown")
        {
            frequency = (frequency > endLimit) ? frequency * rate : endLimit;
            frequency--;
        }
        else if (slider == "SlideUp")
        {
            frequency = (frequency < endLimit) ? frequency * rate : endLimit;
            frequency++;
        }
        mixer.SetFloat(effect, frequency);
    }
}