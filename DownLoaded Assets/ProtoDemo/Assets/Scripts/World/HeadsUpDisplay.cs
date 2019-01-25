using UnityEngine;
using System.Collections;

public class HeadsUpDisplay : MonoBehaviour
{
    void OnGUI()
    {
        GUI.contentColor = Color.magenta;


        GUI.Label(new Rect(300, 15, Screen.width, Screen.height),
            string.Format("<b>SCORE: {0}</b>", WorldManager.GrandTotalScore.ToString())
            );

        GUI.Label(new Rect(15, 15, Screen.width, Screen.height),
            string.Format("<b>PowerUP: {0}</b>", PowerUpManager.PowerUpMeter.ToString())
            );

        GUI.Label(new Rect(15, 35, Screen.width, Screen.height),
            string.Format("<b>CoolDown: {0}</b>", CubeController.CoolCounter.ToString())
            );
    }
}