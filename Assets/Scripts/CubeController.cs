using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
	Vector3 Move;
	public static float Speed = 0.09f;
	const float CamWidthX = 6.2f;
	const float CamHeightY = 3.4f;

	float LeftEdge;
	float RightEdge;
	float BottomEdge;
	float TopEdge;

	float Teleport;
	public bool isDisappear;
	public static Timer TeleportCool;

	private void Awake(){
		TeleportCool = new Timer(0);
	}

	void Start(){		
		Move = transform.position;
		isDisappear = false;

		LeftEdge = CamWidthX * -1;
		RightEdge = CamWidthX;
		BottomEdge = CamHeightY * -1;
		TopEdge = CamHeightY;
	}

	void Update(){
		TeleportCheck();
		Movement();
		BoundryCheck();
	}

	private void Movement(){
		//Movement
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("DPad_Horizontal") < 0)
			Move.x -= Speed * Timer.DeltaTimeMod + Teleport;
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("DPad_Horizontal") > 0)
			Move.x += Speed * Timer.DeltaTimeMod + Teleport;
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") < 0 || Input.GetAxis("DPad_Vertical") < 0)
			Move.y += Speed * Timer.DeltaTimeMod + Teleport;
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") > 0 || Input.GetAxis("DPad_Vertical") > 0)
			Move.y -= Speed * Timer.DeltaTimeMod + Teleport;

		transform.position = Move;
	}

	private void TeleportCheck(){
		AudioSource audioSource = GetComponent<AudioSource>();
		//Teleport
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Teleport")){
			if (TeleportCool.Counter == 0){
				audioSource.Play();
				Teleport = 2f;
				isDisappear = true;
				TeleportCool.Counter = 500;
			}
		}else{
			Teleport = 0;
			isDisappear = false;
		}

		TeleportCool.RunReverse();
	}

	void BoundryCheck(){
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