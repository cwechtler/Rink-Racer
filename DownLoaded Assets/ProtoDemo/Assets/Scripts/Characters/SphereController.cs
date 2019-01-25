using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour
{
    public GameObject CubeReference;
    public static float Speed = 0.06f;
    Vector3 CubeRefPosition;

    Vector2 Distance;
    AudioSource Audio;
    int CoolCrowd;

    public int WaveCount;
    public int CloseCall;
    public int SpawnInterval = 500;

    public int Timer;

	void Start()
	{
        //Dynamic reference to our Cube/Player1 GameObject
        //CubeReference = GameObject.Find("Cube");
        Timer = 0;
        Audio = GetComponent<AudioSource>();
        CoolCrowd = 220;

        CloseCall = 0;
        WaveCount = 0;
	}

	void Update()
	{
        Movement();
        EnemyProximity();
        SpawnEnemy();
        CrowdCheer();
	}

    private void Movement()
    {
        //Sphere Tracks position of player1 and follows
        CubeRefPosition = CubeReference.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, CubeRefPosition, Speed);
    }

    private void EnemyProximity()
    {
        //Check Distance between player1 & Enemy
        float x = transform.position.x - CubeRefPosition.x;
        float y = transform.position.y - CubeRefPosition.y;
        Distance = new Vector2(x,y);

        //If Occupying same space as you, you've been eaten!!!
        if (((Distance.x < 0.1f) && (Distance.x > -0.1f)) && ((Distance.y < 0.1f) && (Distance.y > -0.1f)))
        {
            ////Removed to fix null reference in final build
            //GameObject.Destroy(CubeReference);

            //Disable CubeController Script, can't move
            CubeReference.GetComponent<CubeController>().enabled = false;

            //Cube gets "swallowed up" by the Sphere
            CubeReference.transform.localScale = Vector3.Lerp(CubeReference.transform.localScale, new Vector3(0.01f, 0.01f, 0), 0.05f);

            //Cube spins as it's getting swallowed
            CubeReference.transform.rotation = new Quaternion(0, 0, transform.rotation.z * 0.5f, transform.rotation.w);

            GameOverManager.IsGameOver = true;

            //Debug.Log("YOU HAVE BEEN EATEN");
        }

        if (CubeReference.transform.localScale.y < 0.011f)
        {
            GetComponent<SphereController>().enabled = false;
            CubeReference.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void SpawnEnemy()
    {
        //Spawn Duplicates every 500 ticks
        if (Timer > SpawnInterval)
        {
            float x = Random.Range(-6.2f, 6.2f);
            float y = Random.Range(-3.4f, 3.4f);
            float z = transform.position.z;
            GameObject.Instantiate(this.gameObject, new Vector3(x, y, z), transform.rotation);

            WaveCount++;
            Timer = 0;
        }
        Timer++;
    }

    private void CrowdCheer()
    {
        int maxCoolTime = 220;

        //If close to Cube, crowd goes wild!
        if (((Distance.x < 0.9f) && (Distance.x > -0.9f)) && ((Distance.y < 0.9f) && (Distance.y > -0.9f)))
        {
            if (CoolCrowd == maxCoolTime)
            {
                Audio.panStereo = Random.Range(0f, 0.6f) * (Random.Range(0, 2) * 2 - 1);
                Audio.Play((ulong)Random.Range(1,11000));
                CoolCrowd = maxCoolTime - 1;
            }
            CloseCall += 2 * WaveCount;
        }
        if (CoolCrowd < maxCoolTime)
        {
            CoolCrowd--;
            if (CoolCrowd < 0) { CoolCrowd = maxCoolTime; }
        }
    }
}