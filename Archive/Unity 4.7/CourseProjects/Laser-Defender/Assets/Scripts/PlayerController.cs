using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public bool player1;
	public bool player2;
	public float speed =15;
	public float projectileSpeed;
	public float firingRate=0.2f;
	
	public GameObject projectile;
	public float projectiledistance;
	public int activate2playermode=3;
	
	public float health=250f;
	
	public AudioClip Firesound;
	public AudioClip deathplayer;
	
	public GameObject p2suicide;
	public GameObject p2suicide2;
	
	public static int losegamevar;
	 
	
	
	float xmin=-5;
	float xmax=5;
	float padding = 1f;
	
	// Use this for initialization
	void Start () {
			float distance = this.transform.position.z - Camera.main.transform.position.z;
			Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distance));
			Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distance));
			
			xmin=leftmost.x + padding ;
			xmax=rightmost.x - padding;
	}
	
	void Fire() { 
		Vector3 offset = new Vector3(0,projectiledistance,0);
		GameObject beam = Instantiate (projectile, this.transform.position + offset, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3 (0f,projectileSpeed,0f);
		AudioSource.PlayClipAtPoint(Firesound,transform.position);
	
	}
	
	// Update is called once per frame
	void Update () {  	

				
	   if (player1) {//playernumber==1  
	   if (Input.GetKey(KeyCode.LeftArrow)) {//left
			this.transform.position = this.transform.position + new Vector3 (-speed * Time.deltaTime,0f,0f);
		}//left
	   else if (Input.GetKey(KeyCode.RightArrow)) {//right
			this.transform.position = this.transform.position + new Vector3 (speed * Time.deltaTime,0f,0f);
		}//right
	   else if (Input.GetKey(KeyCode.DownArrow)) {//down
			this.transform.position = this.transform.position + new Vector3 (0f,-speed * Time.deltaTime,0f);
		}//down
	   else if (Input.GetKey(KeyCode.UpArrow)) {//up
			this.transform.position = this.transform.position + new Vector3 (0f,speed * Time.deltaTime,0f);
		}//up
	   else if (Input.GetKeyDown ( KeyCode.Space) ){//space
				
				InvokeRepeating ("Fire", 0.000001f, firingRate);
				
		}//space
	   else if (Input.GetKeyUp ( KeyCode.Space) ){ //space2
				CancelInvoke ("Fire"); 
		}//space2	
		projectiledistance=1;																						
		}//playernumber==1 
	   else if (player2 ){//playernumber==2	
	   if (Input.GetKey(KeyCode.A)) {//a
				this.transform.position = this.transform.position + new Vector3 (-speed * Time.deltaTime,0f,0f);
		}//a
	   else if (Input.GetKey(KeyCode.D)) {//d
				this.transform.position = this.transform.position + new Vector3 (speed * Time.deltaTime,0f,0f);
		}//d
	   else if (Input.GetKey(KeyCode.S)) {//s
				this.transform.position = this.transform.position + new Vector3 (0f,-speed * Time.deltaTime,0f);
		}//s
	   else if (Input.GetKey(KeyCode.W)) {//w
				this.transform.position = this.transform.position + new Vector3 (0f,speed * Time.deltaTime,0f);
		}//w
	   else if (Input.GetKeyDown ( KeyCode.R) ){ //r
				
				InvokeRepeating ("Fire", 0.000001f, firingRate);
				
		}//r
	   else if (Input.GetKeyUp ( KeyCode.R) ){//r
				CancelInvoke ("Fire"); 
		}//r
		projectiledistance=1.5f;
		
		
			
		}//playernumber==2 
			else if (player1==false){this.transform.position = this.transform.position + new Vector3 (0f,80088f,0f);}
		
	
		
		
		//restrict player to gamespace			  	} 								
		float newX = Mathf.Clamp (this.transform.position.x,xmin,xmax);
		transform.position = new Vector3 (newX, this.transform.position.y, transform.position.z); 																							
	  
		
					  	}

		

	
			
		
		void OnTriggerEnter2D (Collider2D collider) { 
		Debug.Log ("player collided with missile");
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
				missile.Hit();
			if (health<=0) {
				AudioSource.PlayClipAtPoint(deathplayer,transform.position);
				Destroy(gameObject);
				LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
			
				
				if (player1==true && player2==false  ) {losegamevar-=1; if (losegamevar<=0){man.LoadLevel("win");}print (losegamevar);};
				if (player1==false && player2==true) {losegamevar-=1;if (losegamevar<=0){man.LoadLevel("win");}print (losegamevar);};
				
				
				 
			}
			Debug.Log("hit by a projectile");		}
	
				
	

	}//Update ends
	

	


								
	public void disablep2 () {
	{losegamevar=1;}
		
		
		
	}
	public void enablep2() { 
		losegamevar=2;
	}	

 


	





/*

public PlayerController playerNo;

void Update () {
	if (Input.GetKey(KeyCode.A)) {
		playerNo.transform.position = playerNo.transform.position + new Vector3 (-speed,0f,0f);
	}
	if (Input.GetKey(KeyCode.D)) {
		playerNo.transform.position = playerNo.transform.position + new Vector3 (speed,0f,0f);
	}
	if (Input.GetKey(KeyCode.S)) {
		playerNo.transform.position = playerNo.transform.position + new Vector3 (0f,-speed,0f);
	}
	if (Input.GetKey(KeyCode.W)) {
		playerNo.transform.position = playerNo.transform.position + new Vector3 (0f,speed,0f);
	}
*/

/*
if (Input.GetKey(KeyCode.lefta)) {
	this.transform.position = this.transform.position + new Vector3 (-speed,0f,0f);
}
if (Input.GetKey(KeyCode.D)) {
	this.transform.position = this.transform.position + new Vector3 (speed,0f,0f);
}
if (Input.GetKey(KeyCode.S)) {
	this.transform.position = this.transform.position + new Vector3 (0f,-speed,0f);
}
if (Input.GetKey(KeyCode.W)) {
	this.transform.position = this.transform.position + new Vector3 (0f,speed,0f);
}
*/


}// END ALL




