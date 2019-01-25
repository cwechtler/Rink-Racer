using UnityEngine;
using System.Collections;

public class ArraysAndLoops : MonoBehaviour
{
	void Update()
	{
        int[] arrayExample = new int[5];
        arrayExample[0] = 22;
        arrayExample[1] = 33;
        arrayExample[2] = 36;
        arrayExample[3] = 2;
        arrayExample[4] = 8;

        //Debug.Log(arrayExample[2]);

        ////Increments Through the Array
        //for (int i = 0; i < arrayExample.Length; i++)
        //{
        //    Debug.Log(arrayExample[i]);
        //}

        ////Decrements Through the Array
        //for (int i = arrayExample.Length - 1; i >= 0 ; i--)
        //{
        //    Debug.Log(arrayExample[i]);
        //}

        ////Decrements and Outputs Only even Indexed Array Items
        //for (int i = arrayExample.Length - 1; i >= 0; i--)
        //{
        //    if (i % 2 == 0)
        //    {
        //        Debug.Log(arrayExample[i]);
        //    }
        //}

        //Decrements and Outputs Only Odd Values
        for (int i = arrayExample.Length - 1; i >= 0; i--)
        {
            if (arrayExample[i] % 2 == 1)
            {
                Debug.Log(arrayExample[i]);
            }
        }

    }
}