using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    SpriteRenderer gameOver;
    public static bool isGameOver;

	void Start () {
        gameOver = GetComponent<SpriteRenderer>();
        isGameOver = false;
	}
	
	void Update () {
        if (isGameOver) {
            gameOver.color = Color.Lerp(gameOver.color, new Color(1, 1, 1, 1f), 0.006f * Timer.DeltaTimeMod);

            GameStartManager reStart = GetComponentInChildren<GameStartManager>();
            reStart.enabled = true;
        }
	}
}
