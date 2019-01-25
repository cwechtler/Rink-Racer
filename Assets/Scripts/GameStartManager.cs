using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour {

	Timer loopTimer;

	void Start () {
		loopTimer = new Timer(0);
	}
	
	void Update () {
		if (loopTimer.Counter == 0) {
			SpriteRenderer pressEnterRenderer = GetComponent<SpriteRenderer>();
			pressEnterRenderer.enabled = !pressEnterRenderer.enabled;
		}
		loopTimer.RunForwarTo(30);

		if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Start")) {
			SceneManager.LoadScene("Rink Racer");
			CubeController.Speed = 0.09f;
			SphereController.Speed = 0.05f;
			if (CubeController.TeleportCool != null) {
				CubeController.TeleportCool.Counter = 0;
			}		
		}
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Back")) {
			Application.Quit();
		}
	}
}
