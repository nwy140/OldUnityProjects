using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float health = 150;
	public GameObject enemyprojectile;
	public float enemyprojectileSpeed;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 150;
	
	private Scorekeeper scorekeeper;
	
	public AudioClip Firesounenemy;
	public AudioClip death;
	

	void Start (){
		scorekeeper = GameObject.Find ("Score").GetComponent<Scorekeeper>();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log (collider);
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
				missile.Hit();
			if (health<=0) {
			
				AudioSource.PlayClipAtPoint(death,transform.position);
				Destroy(gameObject);
				
				scorekeeper.Score(scoreValue);
			
				
			}
			Debug.Log("hit by a projectile");		}
	}

	
	void Fire() { 
		Vector3 startPosition = transform.position + new Vector3 (0f,-1,0);
		GameObject missile = Instantiate(enemyprojectile,startPosition,Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector2 (0,- enemyprojectileSpeed);
		AudioSource.PlayClipAtPoint(Firesounenemy,transform.position);
		
	}
	// Update is called once per frame
	void Update () { 
		float probability = Time.deltaTime * shotsPerSeconds;
		if(Random.value < probability) {
		
		Fire();
		}
		
		
	}
	
	
}