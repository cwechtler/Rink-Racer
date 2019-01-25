using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour
{
    public GameObject cubeReference;

    public static float Speed = 0.05f;

    public float closeCall;

    public int waveCount;
    public int spawnInterval = 500;

    private Vector3 cubeRefPosition;
    private Vector2 distance;

    public Timer spawnTimer;
    private Timer coolCrown;
 
	void Start(){
        spawnTimer = new Timer(0);
        coolCrown = new Timer(220);       
        waveCount = 0;
        closeCall = 0;      
    }

	void Update(){
        Movement();
        EnemyProximity();
        SpawnEnemy();
        CrownCheer();
    }

    private Vector3 Movement(){
        //Sphere Tracks position of player1 and follows
        cubeRefPosition = cubeReference.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, cubeRefPosition, Speed * Timer.DeltaTimeMod);
        return cubeRefPosition;
    }

    private void EnemyProximity(){
        //Check Distance between player1 & Enemy
        float x = transform.position.x - cubeRefPosition.x;
        float y = transform.position.y - cubeRefPosition.y;
        distance = new Vector2(x, y);

        //If Occupying same space as you, you've been eaten!!!
        if (((distance.x < 0.1f) && (distance.x > -0.1f)) && ((distance.y < 0.1f) && (distance.y > -0.1f))){
            cubeReference.GetComponent<CubeController>().enabled = false;
            cubeReference.transform.localScale = Vector3.Lerp(cubeReference.transform.localScale, new Vector3(0.01f, 0.01f, 0), 0.05f * Timer.DeltaTimeMod);
            cubeReference.transform.rotation = new Quaternion(0, 0, transform.rotation.z * 0.5f, transform.rotation.w);
            GameOverManager.isGameOver = true;

            PowerUpManager powerUpManager = GameObject.Find("PowerUpSpawn").GetComponent<PowerUpManager>();
            powerUpManager.isPowered = false;
            powerUpManager.enabled = false;
        }

        if (cubeReference.transform.localScale.y < 0.011f) {
            GetComponent<SphereController>().enabled = false;
            cubeReference.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void SpawnEnemy(){
        //Spawn Duplicates every 500 ticks
        if (spawnTimer.Counter > spawnInterval){
            float x = Random.Range(-6.2f, 6.2f);
            float y = Random.Range(-3.4f, 3.4f);
            float z = transform.position.z;
            GameObject.Instantiate(this.gameObject, new Vector3(x, y, z), transform.rotation);
            waveCount++;
        }
        spawnTimer.RunForwarTo(spawnInterval);
    }

    private void CrownCheer(){
        AudioSource audioSource = GetComponent<AudioSource>();
        int maxCoolTime = 220;
        if (((distance.x < 0.9f) && (distance.x > -0.9f)) && ((distance.y < 0.9f) && (distance.y > -0.9f)))
        {
            if (coolCrown.Counter == maxCoolTime)
            {
                audioSource.panStereo = Random.Range(0f, 0.6f) * (Random.Range(0, 2) * 2 - 1);
                audioSource.PlayDelayed(Random.Range(0.1f, 0.3f));
                coolCrown.Counter = maxCoolTime - 1;
            }
            closeCall += 2 * waveCount * Timer.DeltaTimeMod;
        }
        if (coolCrown.Counter < maxCoolTime)
        {
            coolCrown.RunReverseFrom(maxCoolTime);          
        }
    }
}