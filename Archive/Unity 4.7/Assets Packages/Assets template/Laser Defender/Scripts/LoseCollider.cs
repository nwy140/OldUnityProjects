using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
private LevelManager levelmanager;
		
		
		
	void Start () {
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}	
	void OnTriggerEnter2D (Collider2D triggername01) {
		print ("Trigger"); 
		levelmanager.LoadLevel ("lose");
	}
	void OnCollisionExit2D (Collision2D collidername01) {
		print ("Collision");
		
	}
	
}
