using UnityEngine;
using System.Collections;

public class PersonFactory : MonoBehaviour
{
	void Start()
	{
        Person person1 = new Person();
        person1.Name = "Mario";
        person1.Gender = "Male";
        person1.Age = 26;

        Debug.Log(person1.Name);
        Debug.Log(person1.Gender);
        Debug.Log(person1.Age);

        Person person2 = new Person();
        person2.Name = "Peach";
        person2.Gender = "Female";
        person2.Age = 17;

        Debug.Log(person2.Name);
        Debug.Log(person2.Gender);
        Debug.Log(person2.Age);

        person1.DoAging();
        person2.DoAging();

        Debug.Log(person1.Age);
        Debug.Log(person2.Age);
    }
}