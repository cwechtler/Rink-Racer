using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour
{
    GameObject CubeReference;
    public int Timer;

	void Start()
	{
        Timer = 1;
        CubeReference = GameObject.Find("Cube");
	}

	void Update()
	{
        AnimatePowerUp();
        DestroyPowerUp();
    }

    private bool AtePowerUp()
    {
        //Eat or Destroy PowerUp
        Vector2 distance = new Vector2(
            transform.position.x - CubeReference.transform.position.x,
            transform.position.y - CubeReference.transform.position.y
        );

        //Determines whether or not Cube is near the PowerUp (some leniency within 0.5 units)
        if (((distance.x < 0.5f) && (distance.x > -0.5f)) && ((distance.y < 0.5f) && (distance.y > -0.5f)))
            return true;
        else
            return false;
    }

    private void DestroyPowerUp()
    {
        Timer++;

        if (AtePowerUp())
        {
            GameObject.Destroy(gameObject);
            PowerUpManager.PowerUpMeter += 100;

            AudioSource[] audio = GetComponentsInParent<AudioSource>();
            int rand = Random.Range(0, 3);
            audio[rand].Play();
        }

        if (Timer % 140 == 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void AnimatePowerUp()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1,1,1), 0.05f);
    }
}