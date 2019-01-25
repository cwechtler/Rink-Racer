using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    SpriteRenderer GameOverRenderer;
    public static bool IsGameOver;

	void Start()
	{
        GameOverRenderer = GetComponent<SpriteRenderer>();
        IsGameOver = false;
	}

	void Update()
	{
        if (IsGameOver)
        {
            GameOverRenderer.color = Color.Lerp(GameOverRenderer.color, new Color(255, 255, 255, 0.8f), 0.006f);

            GameStartManager reStart = GetComponentInChildren<GameStartManager>();
            reStart.enabled = true;
        }
	}
}