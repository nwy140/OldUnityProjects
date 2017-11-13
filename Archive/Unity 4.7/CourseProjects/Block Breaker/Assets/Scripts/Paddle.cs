using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {


	public bool autoPlay = false;
	public float minX,maxX;
	float mousePosinBlocks;

	private Ball ball;
	
	
	void Start (){
		ball = GameObject.FindObjectOfType <Ball>();	
	}
	// Update is called once per frame
	void Update () {
	if (!autoPlay) {
			MoveWithMouse() ; 
	
	} else  {

		AutoPlay(); 
		}
		}
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballpos = ball.transform.position;	
		paddlePos.x = Mathf.Clamp (ballpos.x,minX, maxX);
		//		print (mousePosinBlocks);	
		this.transform.position = paddlePos;
	}
	  
	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosinBlocks=Input.mousePosition.x/Screen.width    *16;		
		paddlePos.x = Mathf.Clamp (mousePosinBlocks, minX, maxX);
		//		print (mousePosinBlocks);	
		this.transform.position = paddlePos;
	}
}
