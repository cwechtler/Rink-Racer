using UnityEngine;
using System.Collections;

public class CubeEyesAnimate : MonoBehaviour
{
    GameObject SphereReference;

	void Start()
	{
        SphereReference = GameObject.Find("Sphere");
	}

	void Update()
	{
        Vector3 sphereRefPos = SphereReference.transform.position;

        Vector3 lookPos = sphereRefPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg - 145f;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}