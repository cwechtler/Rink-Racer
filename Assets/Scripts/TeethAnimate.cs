using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeethAnimate : MonoBehaviour {

    public GameObject powerUpManager;
    private Animator animator;


	void Start () {
        animator = GetComponent<Animator>();
       
	}
	
	
	void Update () {
        bool isPowered = powerUpManager.GetComponent<PowerUpManager>().isPowered;
        animator.SetBool("IsPoweredUp", isPowered);
    }
}
