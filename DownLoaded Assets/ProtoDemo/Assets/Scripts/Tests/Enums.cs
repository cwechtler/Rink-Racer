using UnityEngine;
using System.Collections;

public class Enums : MonoBehaviour
{
    PlayerStates PlayerState;
    int MoveSpeed;

	void Start()
	{
        MoveSpeed = 0;
        PlayerState = PlayerStates.Idle;
	}

	void Update()
	{
        if (PlayerState == PlayerStates.Running)
            MoveSpeed = 2;
        else if (PlayerState == PlayerStates.Walking)
            MoveSpeed = 1;
        else
            MoveSpeed = 0;

        Debug.Log(MoveSpeed);
	}
}

public enum PlayerStates
{
    Idle,
    Walking,
    Running,
    Attacking,
    Defending,
    Jumping,
    Falling
}