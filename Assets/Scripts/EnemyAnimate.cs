using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimate : MonoBehaviour {


    int randRotateDir;
    float randRotateSpeed;

	void Start () {
        randRotateDir = Random.Range(0, 2) * 2 - 1;
        randRotateSpeed = Random.Range(3.0f, 9.0f);
	}
	
	void Update () {
        transform.Rotate(0f, 0f, (randRotateSpeed * randRotateDir) * Timer.DeltaTimeMod);
	}
}
