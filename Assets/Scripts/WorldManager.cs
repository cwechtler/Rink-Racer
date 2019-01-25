using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

    List<GameObject> allEnemys = new List<GameObject>();
    public static int grandTotalScore;
    bool bonusSwitch;

    SphereController sphereController;
    AudioSource[] audioSource;

    private Timer hornTimer;

    bool pauseSwitch;
    public static bool isScoring;

	void Start () {
        hornTimer = new Timer(0);
        sphereController = GameObject.Find("Enemy").GetComponent<SphereController>();
        audioSource = GetComponents<AudioSource>();
        bonusSwitch = true;
        MusicStart();
	}
	
	void Update () {
        GetCloseCallScore();
        PreSpawnAirHorn();
        MusicModifier();
        BonusAnnounce();
        GamePause();
    }

    private void GetCloseCallScore() {
        int previousGrandTotalScore = grandTotalScore;
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            if (!allEnemys.Contains(enemy)) {
                allEnemys.Add(enemy);
            }
        }

        float tempTotal = 0;
        foreach (GameObject enemy in allEnemys){
            SphereController eachSphereScript = enemy.GetComponent<SphereController>();
            tempTotal += eachSphereScript.closeCall;
        }
        grandTotalScore = (int)tempTotal;

        isScoring = ScoringCheck(previousGrandTotalScore, grandTotalScore);
    }

    private void PreSpawnAirHorn() {
        float hornInterval = sphereController.spawnInterval - 150;
        if (hornTimer.Counter > hornInterval) {
            if(!GameOverManager.isGameOver)
            audioSource[1].Play();
        }
        if (sphereController.spawnTimer.Counter == 0) {
            hornTimer.Counter = 0;
        }
        hornTimer.RunForwarTo(hornInterval);
    }

    private void MusicStart() {
        audioSource[2].Play();
        audioSource[3].Play();
    }

    private void MusicModifier() {
        if (sphereController.waveCount < 3)
        {
            audioSource[2].mute = false;
            audioSource[3].mute = true;
        }
        else if (sphereController.waveCount > 3)
        {
            audioSource[2].mute = true;
            audioSource[3].mute = false;
        }
        else if (sphereController.waveCount == 5)
        {
            audioSource[3].pitch = Mathf.Lerp(audioSource[3].pitch, 1.2f, 0.01f * Timer.DeltaTimeMod);
        }
        else if (sphereController.waveCount > 5) {
            audioSource[3].pitch = Mathf.Lerp(audioSource[3].pitch, 1.3f, 0.01f * Timer.DeltaTimeMod);
        }
    }

    private void BonusAnnounce() {
        if (grandTotalScore > 7000 && grandTotalScore < 10000 && bonusSwitch)
        {
            audioSource[4].Play();
            PowerUpManager.powerUpMeter.Counter *= 1.5f;
            bonusSwitch = !bonusSwitch;
        }
        else if (grandTotalScore > 10000 && !bonusSwitch) {
            audioSource[5].Play();
            PowerUpManager.powerUpMeter.Counter *= 1.25f;
            bonusSwitch = !bonusSwitch;
        }
    }

    public void GamePause() {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Start"))
            pauseSwitch = !pauseSwitch;
        
        if (pauseSwitch && !GameOverManager.isGameOver)
        {
            Time.timeScale = 0.0f;
            GameObject.Find("Player 1").GetComponent<CubeController>().enabled = false;
        }
        else if (!pauseSwitch && !GameOverManager.isGameOver) {
            Time.timeScale = 1f;
            GameObject.Find("Player 1").GetComponent<CubeController>().enabled = true;
        }
    }

    private bool ScoringCheck(int previousFramesScore, int currentFrameScore) {
        if (previousFramesScore < currentFrameScore)
            return true;
        else
            return false;
        
    }
}
