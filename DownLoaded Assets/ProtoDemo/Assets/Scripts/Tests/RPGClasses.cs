using UnityEngine;
using System.Collections;

public class NPC { }
public class Companion : NPC { }

public class Combatant
{
    public Weapon weapon = new Weapon("rusty sword", 100);
}

public class Wizard : Combatant { }
public class Knight : Combatant { }
public class Elf : Combatant { }

public class Weapon
{
    public string WeaponType;
    private int Degradation;

    public Weapon(string weaponType, int degradation)
    {
        this.WeaponType = weaponType;
        this.Degradation = degradation;
    }

    public string UseWeapon()
    {
        string phrase = "The player has struck with the weapon: ";
        string combinedPhrase = phrase + WeaponType;
        return combinedPhrase;
    }

    public string Deflect(Combatant combatant, int degradation)
    {
        Degradation -= degradation;

        string phrase = string.Format(
            "You deflected the {0}'s {1} and degraded your weapon to {2}",
            combatant.GetType(),
            combatant.weapon.WeaponType,
            Degradation
            );

        combatant.weapon.WeaponType = "Broken " + combatant.weapon.WeaponType;

        return phrase;

        //Below is for a string input parameter, rather than an object
        //return weaponType = "Broken " + weaponType;

    }

    public void DamageSomething(object anObject)
    {
        //do something that damages the object
    }
}