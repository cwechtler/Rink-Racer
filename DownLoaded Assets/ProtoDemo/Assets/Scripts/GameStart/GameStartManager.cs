using UnityEngine;
using System.Collections;

public class GameStartManager : MonoBehaviour
{
    int _loopTimer;
    int LoopTimer
    {
        get
        {
            _loopTimer = (_loopTimer > 1000) ? 0 : _loopTimer + 1;
            return _loopTimer;
        }
        set
        {
            _loopTimer = value;
        }
    }

	void Start()
	{
        LoopTimer = 1;
	}

	void Update()
	{
        if (LoopTimer % 30 == 0)
        {
            SpriteRenderer pressEnterRenderer = GetComponent<SpriteRenderer>();
            pressEnterRenderer.enabled = !pressEnterRenderer.enabled;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Start"))
        {
            Application.LoadLevel("ProtoScene");
            CubeController.Speed = 0.07f;
            SphereController.Speed = 0.06f;
        }
	}
}