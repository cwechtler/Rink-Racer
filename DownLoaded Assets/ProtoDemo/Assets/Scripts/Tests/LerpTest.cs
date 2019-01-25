using UnityEngine;
using System.Collections;

public class LerpTest : MonoBehaviour
{
    float Accumulator = 0.001f;
    float Output = 0f;

    void Start()
    {
        //Dynamically create, attach and set properties of SpriteRenderer
        SpriteRenderer renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load<Sprite>("Images/Tabors");
        renderer.sortingLayerName = "Player1";
        renderer.color = new Color(0, 1, 0.3f, 1);
    }

    void OnGUI()
    {
        GUI.contentColor = Color.magenta;

        GUI.Label(
            new Rect(105, 250, Screen.width, Screen.height),
            string.Format("<b>LERP Accumulator: {0}</b>", Accumulator.ToString())
            );
        GUI.Label(
            new Rect(105, 270, Screen.width, Screen.height),
            string.Format("<b>LERP Output: {0}</b>", Output.ToString())
            );
    }

    void Update()
    {
        transform.position = new Vector3(LerpTypes(), 1, 1);
    }

    float LerpTypes()
    {
        #region - ACCUMULATOR TYPES
            ////Accumulator Type1: Exponetial, Doubling Accumulator
            Accumulator += Accumulator * 0.08f;

            ////Accumulator Type2: Linear, Fixed Accumulator
            //Accumulator += 0.004f;
        #endregion

        #region - LERP TYPES
            ////Lerp Type1: Constant Transition, Fixed "From"
            //Output = Mathf.Lerp(-5f, 5f, Accumulator);

            ////Lerp Type2: Smooth Transition, No Accumulator Required
            Output = Mathf.Lerp(Output, 5f, 0.02f);
        #endregion

        return Output;
    }
}