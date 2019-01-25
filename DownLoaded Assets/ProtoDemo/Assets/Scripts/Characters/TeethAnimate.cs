using UnityEngine;
using System.Collections;

public class TeethAnimate : MonoBehaviour
{
    public GameObject PowerUpManagerReference;
    Animator AnimatorReference;

	void Start()
	{
        AnimatorReference = GetComponent<Animator>();
	}

	void Update()
	{
        bool IsPowered = PowerUpManagerReference.GetComponent<PowerUpManager>().IsPowered;
        AnimatorReference.SetBool("IsPoweredUp", IsPowered);
	}
}