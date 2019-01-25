using UnityEngine;

class VariablesAndOperations : MonoBehaviour
{
	void Start()
	{
        //MyMethod();
        //MyMethod2();
        MyMethod3();
	}

    void MyMethod()
    {
        //Debug.Log("Hello World");
        //string str1;
        //str1 = "Hello";
        //string str2 = "World";
        //Debug.Log(str1);

        int x = 5;
        //x = 5;
        //x = 22;
        //Debug.Log(x);

        //Debug.Log(x * x);
        //Debug.Log(x / x);
        //Debug.Log(x - x);
        x = x * (x - x);
        Debug.Log(x);
    }

    void MyMethod2()
    {
        int x = 3;
        int y = 2;
        float z = (float)x / (float)y;
        Debug.Log(z);
    }

    void MyMethod3()
    {
        bool val;
        val = true;
        val = false;

        Debug.Log(val);
    }
}