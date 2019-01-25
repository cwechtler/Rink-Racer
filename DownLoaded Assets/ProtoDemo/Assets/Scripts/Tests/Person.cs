using UnityEngine;
using System.Collections;

public class Person
{
    public string Name;
    public string Gender;
    public int Age;

    public void DoAging()
    {
        Age++;
    }

    public void DoAging(int amount)
    {
        Age += amount;
    }
}