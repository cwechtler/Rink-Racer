using UnityEngine;

class DamageTest : MonoBehaviour {

    int HealthPoints = 100;

	void Start()
    {
        DealDamage();
        DealDamage();
        Debug.Log(HealthPoints);
	}
	
	void DealDamage()
    {
        HealthPoints -= 5;
	}
}
