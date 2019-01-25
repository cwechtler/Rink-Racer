using UnityEngine;
using System.Collections;

public class CubeAnimate : MonoBehaviour
{
	void Update()
	{
        TeleportFadeForEach();
	}

    private void TeleportFadeForEach()
    {
        SpriteRenderer[] cubeRenderers = GetComponentsInChildren<SpriteRenderer>();

        CubeController controller = GetComponent<CubeController>();

        foreach (SpriteRenderer renderer in cubeRenderers)
        {
            Color color = renderer.color;

            if (controller.IsDisappear)
                color.a = 0;
            else
                color.a = Mathf.Lerp(color.a, 1f, 0.029f);

            renderer.color = color;
        }
    }

    private void TeleportFadeFor()
    {
        SpriteRenderer[] cubeRenderers = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < cubeRenderers.Length; i++)
        {
            Color color = cubeRenderers[i].color;

            if (GetComponent<CubeController>().IsDisappear)
                color.a = 0;
            else
                color.a = Mathf.Lerp(color.a, 1f, 0.029f);

            cubeRenderers[i].color = color;
        }
    }

    private void CubeFade()
    {
        SpriteRenderer cubeRenderer = GetComponent<SpriteRenderer>();
        Color color = cubeRenderer.color;

        if (GetComponent<CubeController>().IsDisappear)
            color.a = 0;
        else
            color.a = Mathf.Lerp(color.a, 1f, 0.029f);

        cubeRenderer.color = color;
    }
}