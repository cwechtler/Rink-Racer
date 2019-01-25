using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    public GameObject PowerUpPrefab;
    int Timer;
    public static int PowerUpMeter;

    public bool IsPowered;

    void Start()
	{
        IsPowered = false;
        Timer = 1;
        PowerUpMeter = 50; //default bonus on start
    }

	void Update()
	{
        //Spawns PowerUp ever 300 ticks
        if (Timer % 300 == 0)
        {
            Vector3 randomSpawn = new Vector3(
                Random.Range(-6.2f, 6.2f),
                Random.Range(-3.4f, 3.4f),
                transform.position.z
            );

            GameObject gO = (GameObject)GameObject.Instantiate(PowerUpPrefab, randomSpawn, transform.rotation);
            gO.transform.parent = gameObject.transform;
        }

        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("PowerUp")) && !IsPowered && PowerUpMeter > 0)
            TimeChange(0.5f); //enter PowerUp Mode, Change Time
        else if ((Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("PowerUp")) && IsPowered)
            TimeChange(2f); //exit PowerUp Mode, Change Time

        if (IsPowered)
        {
            PowerUpMeter--;
            if(PowerUpMeter == 0)
            {
                TimeChange(2f);
            }
        }

        Timer++;
	}

    private void TimeChange(float speedFactor)
    {
        CubeController.Speed = CubeController.Speed * speedFactor;
        SphereController.Speed = SphereController.Speed * speedFactor;
        IsPowered = !IsPowered;
    }
}