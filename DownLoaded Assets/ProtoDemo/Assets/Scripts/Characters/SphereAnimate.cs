using UnityEngine;
using System.Collections;

public class SphereAnimate : MonoBehaviour
{
    int RandRotateDir;
    float RandRotateSpeed;

	void Start()
	{
        RandRotateDir = Random.Range(0, 2) * 2 - 1;
        RandRotateSpeed = Random.Range(3.0f, 9.0f);
	}

	void Update()
	{
        transform.Rotate(0f, 0f, RandRotateSpeed * RandRotateDir);
	}
}