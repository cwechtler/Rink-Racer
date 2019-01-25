using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ZoomCam : MonoBehaviour {

    public Transform playerTransform;
    public GameObject powerUpSpawn;

    public AudioMixer audioMixerMain;
    public AudioMixer audioMixerSub;

    float LPFrequencyMain;
    float LPFrequencySub;

    private void Start()
    {
        LPFrequencyMain = LPFrequencySub = 22000;
    }

	void LateUpdate () {
        if (powerUpSpawn.GetComponent<PowerUpManager>().isPowered)
        {
            Vector3 playerPosition = playerTransform.position;
            playerPosition.z = playerPosition.z - 10;
            CameraLerp(Camera.main.orthographicSize, 2.5f, Camera.main.transform.position, playerPosition);

            LowPassFilter(600, 0.095f, audioMixerMain, "LowPass", ref LPFrequencyMain);
            LowPassFilter(5000, 0.080f, audioMixerSub, "LowPassSub", ref LPFrequencySub);
        }
        else {
            Vector3 defaultPosition = new Vector3(0, 0, -10);
            CameraLerp(Camera.main.orthographicSize, 3.6f, Camera.main.transform.position, defaultPosition);

            LowPassFilter(22000, 0.040f, audioMixerMain, "LowPass", ref LPFrequencyMain);
            LowPassFilter(22000, 0.035f, audioMixerSub, "LowPassSub", ref LPFrequencySub);
        }
	}

    private void CameraLerp(float fromCamSize, float toCamSize, Vector3 fromPosition, Vector3 toPosition) {
        Camera.main.orthographicSize = Mathf.Lerp(fromCamSize, toCamSize, 0.08f * Timer.DeltaTimeMod);
        Camera.main.transform.position = Vector3.Lerp(fromPosition, toPosition, 0.08f * Timer.DeltaTimeMod);

    }

    private void LowPassFilter(float endLimit, float rate, AudioMixer mixer, string effect, ref float frequency)
    {
        frequency = Mathf.Lerp(frequency, endLimit, rate * Timer.DeltaTimeMod);
        //if (slider == "SlideDown")
        //    frequency = (frequency > endLimit) ? frequency * rate : endLimit;
        //else if (slider == "SlideUp")
        //    frequency = (frequency < endLimit) ? frequency * rate : endLimit;
        mixer.SetFloat(effect, frequency);
    }
}
