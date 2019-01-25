using UnityEngine;
using System.Collections;

public class RPGController : MonoBehaviour
{
    void Start()
    {
        //MethodInputsAndReturns();
        //ValueVsReference();
        //Polymorphism();
    }

    void MethodInputsAndReturns()
    {
        Wizard wizard = new Wizard();
        wizard.weapon.WeaponType = "wand";

        //string offenseMessage = wizard.weapon.UseWeapon();
        //Debug.Log(offenseMessage);

        Knight knight = new Knight();
        knight.weapon.WeaponType = "sword";

        string defenseMessage = wizard.weapon.Deflect(knight, 30);
        Debug.Log(defenseMessage);
    }

    void ValueVsReference()
    {
        //int num1 = 0;
        //int num2 = num1;
        //num2 = 99;

        //Debug.Log("num1: " + num1); //retains its original value, 0!

        //Wizard wizard1 = new Wizard();
        //wizard1.weapon.WeaponType = "Staff";

        //Wizard wizard2 = wizard1;
        //wizard2.weapon.WeaponType = "Orb";

        //Debug.Log("wizard1: " + wizard1.weapon.WeaponType); //becomes Orb!

        Wizard wizard = new Wizard();
        Knight knight = new Knight();
        knight.weapon.WeaponType = "Sword";

        wizard.weapon.Deflect(knight, 30);
        Debug.Log(knight.weapon.WeaponType);
    }

    void Polymorphism()
    {
        Wizard wizard = new Wizard();
        Knight knight = new Knight();
        Elf elf = new Elf();

        knight.weapon.WeaponType = "Sword";
        elf.weapon.WeaponType = "Arrow";

        Combatant combatant = knight;

        string defenseMessage = wizard.weapon.Deflect(combatant, 30);
        Debug.Log(defenseMessage);

        wizard.weapon.DamageSomething(elf);

        Companion spiritFamiliar = new Companion();
        wizard.weapon.DamageSomething(spiritFamiliar);
    }
}