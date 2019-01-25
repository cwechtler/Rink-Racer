using UnityEngine;

class Conditionals : MonoBehaviour
{
	void Start()
	{
        StateHandler();
	}

    void StateHandler()
    {
        int damageRating; //default
        bool isInvincible = false; //default
        bool grabbedPowerUp = false; //default

        //grabbedPowerUp = true;

        if (grabbedPowerUp)
        {
            isInvincible = true;
        }
        else
        {
            isInvincible = false;
        }

        if (isInvincible)
        {
            damageRating = 0;
            //TODO - put in a countdown timer conditional
        }
        else
        {
            damageRating = 100;
        }

        Debug.Log(isInvincible);
        Debug.Log(damageRating);
    }

	void RunConditionals()
	{
        int x = 100;

        if (x <= 100)
        {
            Debug.Log("x IS GREATER OR EQUAL to 100");
        }
        else
        {
            Debug.Log("x IS LESS than 100");
        }
        //if (x == 100)
        //{
        //    Debug.Log("The operands ARE equivalent");
        //}
        //else if(x == 100 / 2)
        //{
        //    Debug.Log("x is equivalent to HALF of 100");
        //}
        //else
        //{
        //    Debug.Log("The operands ARE NOT equivalent");
        //}
	}

    void RunConditionals2()
    {
        int x = 100;

        if (!(x == 100)) //if x is NOT equivalent to 100
        {
            Debug.Log("x IS NOT equivalent to 100");
        }
        else
        {
            Debug.Log("x is equivalent to 100");
        }
    }

    void RunConditionals3()
    {
        bool val = true;

        val = !val;
        Debug.Log(val);

        val = !val;
        Debug.Log(val);

        val = !val;
        Debug.Log(val);

        //if (!val)
        //{
        //    Debug.Log("val is FALSE!");
        //}
        //else
        //{
        //    Debug.Log("val is TRUE!");
        //}
    }

    void RunConditionals4()
    {
        //SIMULATING button presses
        bool isButtonAPressed = true;
        bool isButtonBPressed = true;

        if (isButtonAPressed)
        {
            Debug.Log("ButtonA evaluates as TRUE");

            if (isButtonBPressed)
            {
                Debug.Log("ButtonA AND ButtonB evaluate as TRUE");
            }
        }
        else
        {
            Debug.Log("Button conditional evaluates as FALSE");
        }

        //if (isButtonAPressed || isButtonBPressed)
        //{
        //    Debug.Log("Button conditional evaluates as TRUE");
        //}
        //else
        //{
        //    Debug.Log("Button conditional evaluates as FALSE");
        //}
    }
}