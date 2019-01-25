using UnityEngine;
using System.Collections;

public class Mammal
{
    public bool LaysEggs = false;
}

public class Dog : Mammal
{
    public bool BiPedal = false;
}

public class Human : Mammal
{
    public static bool BiPedal = true;
    public string Gender;
    public int Age;

    public static bool FreeWill;

    public static void ChangeFreeWill()
    {
        FreeWill = !FreeWill;
    }
}