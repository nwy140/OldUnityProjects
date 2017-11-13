using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	public Projectile projectile;
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D col) {
		
	
		Destroy(col.gameObject); 
		Debug.Log ("Hit Wall");
	}		
}
