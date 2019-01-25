using UnityEngine;
using System.Collections;

public class AnimalFactory : MonoBehaviour
{
	void Start()
	{
        //Human person = new Human();
        //Human.BiPedal = true;

        //Human Steven = new Human();
        //Steven.ChangeFreeWill(); //Doesn't work!

        Human.FreeWill = false;
        Human.ChangeFreeWill();
        Debug.Log(Human.FreeWill);
	}
}