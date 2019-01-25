using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldManager : MonoBehaviour
{
    List<GameObject> AllSpheres = new List<GameObject>();
    public static int GrandTotalScore;
    bool BonusSwitch;

    SphereController SphereScript;
    AudioSource[] Audio;

	void Start()
	{
        BonusSwitch = true;
        SphereScript = GameObject.Find("Sphere").GetComponent<SphereController>();
        Audio = GetComponents<AudioSource>();
        MusicStart();
	}

	void Update()
	{
        GetCloseCallScore();
        PreSpawnAirHorn();
        MusicModifier();
        BonusAnnounce();
	}

    private void GetCloseCallScore()
    {
        foreach (GameObject sphere in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (!AllSpheres.Contains(sphere))
            {
                AllSpheres.Add(sphere);
            }
        }

        int tempTotal = 0;
        foreach (GameObject sphere in AllSpheres)
        {
            SphereController eachSphereScript = sphere.GetComponent<SphereController>();
            tempTotal += eachSphereScript.CloseCall;
        }
        GrandTotalScore = tempTotal;
    }

    private void PreSpawnAirHorn()
    {
        if (SphereScript.Timer == SphereScript.SpawnInterval - 150)
        {
            Audio[1].Play();
        }
    }

    private void MusicStart()
    {
        Audio[2].Play();
        Audio[3].Play();
    }

    private void MusicModifier()
    {
        if (SphereScript.WaveCount < 3)
        {
            Audio[2].mute = false;
            Audio[3].mute = true;
        }
        else if (SphereScript.WaveCount == 3)
        {
            Audio[2].mute = true;
            Audio[3].mute = false;
        }
        else if (SphereScript.WaveCount == 5)
        {
            Audio[3].pitch = Mathf.Lerp(Audio[3].pitch, 1.2f, 0.01f);
        }
        else if (SphereScript.WaveCount > 5)
        {
            Audio[3].pitch = Mathf.Lerp(Audio[3].pitch, 1.3f, 0.01f);
        }
    }

    private void BonusAnnounce()
    {
        if (GrandTotalScore > 25000 && GrandTotalScore < 50000 && BonusSwitch)
        {
            Audio[4].Play();
            float powerUpbonus = PowerUpManager.PowerUpMeter;
            powerUpbonus *= 1.5f;
            PowerUpManager.PowerUpMeter = (int)powerUpbonus;
            BonusSwitch = !BonusSwitch;
        }
        else if (GrandTotalScore > 50000 && !BonusSwitch)
        {
            Audio[5].Play();
            float powerUpbonus = PowerUpManager.PowerUpMeter;
            powerUpbonus *= 1.25f;
            PowerUpManager.PowerUpMeter = (int)powerUpbonus;
            BonusSwitch = !BonusSwitch;
        }
    }
}