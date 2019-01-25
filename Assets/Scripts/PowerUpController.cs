using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{

    private GameObject player;
    public Timer killTimer;

 
    void Start()
    {
        player = GameObject.Find("Player 1");
        killTimer = new Timer(0);
    }

    void Update()
    {
        AnimatePowerUp();
        DestroyPowerUp();
    }

    private bool AtePowerUp() {
        Vector2 distance = new Vector2(
            transform.position.x - player.transform.position.x,
            transform.position.y - player.transform.position.y
            );

        if (((distance.x < 0.5f) && (distance.x > -0.5f)) && ((distance.y < 0.5f) && (distance.y > -0.5f)))
            return true;
        else
            return false;
    }

    private void DestroyPowerUp() {
    
        if (AtePowerUp())
        {
            GameObject.Destroy(gameObject);
            PowerUpManager.powerUpMeter.Counter += 100;

            AudioSource[] audioSource = GetComponentsInParent<AudioSource>();
            int Rand = Random.Range(0, 3);
            audioSource[Rand].Play();
        }
        if (killTimer.Counter == 140) {
            GameObject.Destroy(gameObject);
        }
        killTimer.RunForwarTo(140);
    }

    private void AnimatePowerUp() {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1,1,1), .05f * Timer.DeltaTimeMod);
    }
}

