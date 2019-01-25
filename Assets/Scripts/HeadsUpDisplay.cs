using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsUpDisplay : MonoBehaviour {

    private int FontSize;
    public GUIStyle fontStyleResources = new GUIStyle();
    public GUIStyle fontStyleScore = new GUIStyle();

    public int offSet;

    private void Start()
    {
        fontStyleResources.font = fontStyleScore.font = Resources.Load<Font>("Fonts/Bubblegum");
    }

    void OnGUI(){
        ScaleFontSize();
        FontBloom(fontStyleScore);

        GUI.Label(new Rect(Screen.width / 25f + offSet, Screen.height / 1.17f + offSet, Screen.width, Screen.height),
            WorldManager.grandTotalScore.ToString(), fontStyleScore);

        GUI.Label(new Rect(Screen.width / 25f + offSet, Screen.height / 29f + offSet, Screen.width, Screen.height),
            string.Format("PowerUp: {0}", Mathf.RoundToInt(PowerUpManager.powerUpMeter.Counter).ToString()), fontStyleResources);

        GUI.Label(new Rect(Screen.width / 25f + offSet, Screen.height / 12f + offSet, Screen.width, Screen.height),
           string.Format("CoolDown: {0}", Mathf.RoundToInt(CubeController.TeleportCool.Counter).ToString()), fontStyleResources);
    }

    private void ScaleFontSize()
    {
        FontSize = Screen.width / 45;
        fontStyleResources.fontSize = FontSize;
    }
   

    private void FontBloom(GUIStyle fontToScale) {
        int sizeFactor = (WorldManager.isScoring) ? FontSize * 3 : FontSize * 2;
        fontToScale.fontSize = (int)Mathf.Lerp(fontToScale.fontSize, sizeFactor, 0.09f);
    }
}
