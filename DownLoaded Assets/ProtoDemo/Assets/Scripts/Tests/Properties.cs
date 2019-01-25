using UnityEngine;
using System.Collections;

public class Properties : MonoBehaviour
{ 
    //string AutoImplementedProperty { get; set; }

    private string _autoImplementedProperty;
    public string AutoImplementedProperty
    {
        get { return _autoImplementedProperty; }
        set { _autoImplementedProperty = value; }
    }


    private string _userMessage;
    public string UserMessage
    {
        get
        {
            return _userMessage;
        }

        private set
        {
            if (value == "I h4x0r You!")
                _userMessage = "Hacking Attempt Prevented!";
            else
                _userMessage = value;
        }
    }

	void Start()
	{
        UserMessage = "I h4x0r You!";
        Debug.Log(UserMessage);

        UserMessage = "Hi There!";
        Debug.Log(UserMessage);
	}

	void Update()
	{
	}
}