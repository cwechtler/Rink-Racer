using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
    Vector3 Move;
    public static float Speed = 0.07f;
    const float CamWidthX = 6.2f;
    const float CamHeightY = 3.4f;

    float LeftEdge;
    float RightEdge;
    float BottomEdge;
    float TopEdge;

    float Teleport;
    public bool IsDisappear;
    public static int CoolCounter { get; private set; }

    void Start()
    {
        Move = transform.position;
        IsDisappear = false;

        LeftEdge = CamWidthX * -1;
        RightEdge = CamWidthX;
        BottomEdge = CamHeightY * -1;
        TopEdge = CamHeightY;
    }

    void Update()
    {
        TeleportCheck();
        Movement();
        BoundaryCheck();
    }

    private void TeleportCheck()
    {
        //Teleport
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Teleport"))
        {
            if (CoolCounter == 0)
            {
                Teleport = 2f;
                IsDisappear = true;
                CoolCounter = 500;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            Teleport = 0;
            IsDisappear = false;
        }

        CoolCounter--;
        if (CoolCounter < 0)
        {
            CoolCounter = 0;
        }
    }

    private void Movement()
    {
        //Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("DPad_Horizontal") < 0)
            Move.x -= Speed + Teleport;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("DPad_Horizontal") > 0)
            Move.x += Speed + Teleport;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") < 0 || Input.GetAxis("DPad_Vertical") < 0)
            Move.y += Speed + Teleport;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") > 0 || Input.GetAxis("DPad_Vertical") > 0)
            Move.y -= Speed + Teleport;

        transform.position = Move;
    }

    private void BoundaryCheck()
    {
        //Check if at the edge of screen and constrain movement if reached

        if (transform.position.x < LeftEdge)
            Move.x = LeftEdge;
        if (transform.position.x > RightEdge)
            Move.x = RightEdge;
        if (transform.position.y < BottomEdge)
            Move.y = BottomEdge;
        if (transform.position.y > TopEdge)
            Move.y = TopEdge;

        transform.position = Move;
    }
}