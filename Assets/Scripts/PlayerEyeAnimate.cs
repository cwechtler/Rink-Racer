using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEyeAnimate : MonoBehaviour {

    GameObject enemy;
    void Start()
    {
        enemy = GameObject.Find("Enemy");
    }


    void Update () {
        Vector3 enemyPos = enemy.transform.position;
        Vector3 lookPos = enemyPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg - 145f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
