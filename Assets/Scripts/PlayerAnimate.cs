using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour {

 
    void Update()
    {
        PlayerFade();
    }

    private void PlayerFade() {
        SpriteRenderer[] playerRenderers = GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer renderer in playerRenderers)
        {
            Color color = renderer.color;

            if (GetComponent<CubeController>().isDisappear)
                color.a = 0;
            else
                color.a = Mathf.Lerp(color.a, 1f, 0.029f * Timer.DeltaTimeMod);

            renderer.color = color;
        }
    }
}
