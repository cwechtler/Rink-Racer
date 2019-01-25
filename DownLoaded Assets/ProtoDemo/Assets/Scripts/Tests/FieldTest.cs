using UnityEngine;

class FieldTest : MonoBehaviour
{
    string Message = "Hello";

	void Start()
    {
        Debug.Log(Message);
        Method();
        Debug.Log(Message);
        Method();
        Debug.Log(Message);
    }

	void Method()
    {
        Message = Message + "World";
	}
}
