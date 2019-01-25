using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    public GameObject powerUpPrefab;
    private Timer spawnTimer;
    public static Timer powerUpMeter;
    public bool isPowered;

    private bool powerUp;

	void Start () {
        spawnTimer = new Timer(0);
        powerUpMeter = new Timer(50);
        isPowered = false;
        powerUp = false;
    }
	
	void Update(){
        PowerUpSpawner();
        PowerUpActivation();
    }

    private void PowerUpSpawner() {
        if (spawnTimer.Counter > 300)
        {
            Vector3 randomSpawn = new Vector3(
                Random.Range(-6.2f, 6.2f),
                Random.Range(-3.4f, 3.4f),
                transform.position.z
            );
            if (powerUp == false  && GameOverManager.isGameOver == false)
            {
                GameObject powerUpChild = GameObject.Instantiate(powerUpPrefab, randomSpawn, transform.rotation) as GameObject;
                powerUpChild.transform.parent = gameObject.transform;
                powerUp = true;
            }
            else powerUp = false;
        }
        spawnTimer.RunForwarTo(300);
   
    }

    private void PowerUpActivation()
    {
        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("PowerUp")) && !isPowered && powerUpMeter.Counter > 0)
            TimeChange(0.5f);

        else if ((Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("PowerUp")) && isPowered)
            TimeChange(2f);

        if (isPowered)
        {
            powerUpMeter.RunReverse();
            if (powerUpMeter.Counter == 0)
            {
                TimeChange(2f);
            }
        }
    }

    private void TimeChange(float speedFactor)
    {
        CubeController.Speed = CubeController.Speed * speedFactor;
        SphereController.Speed = SphereController.Speed * speedFactor;
        isPowered = !isPowered;
    }
}
