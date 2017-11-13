                                                      using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	
	public float  width = 10f;
	public float height = 5f;
	public float speed = 5;
	
	public float spawndelay = 0.5f;
	
	private float Xmin =-5;
	private float Xmax =5;
	

	float nexX;
	
	bool movingright=false;
	
	
	
	//float padding = 1f;
	//int gamestart=1;

	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z 	- Camera.main.transform.position.z;	
		Vector3 leftboundary = Camera.main.ViewportToWorldPoint(new Vector3 (0,0,distanceToCamera));
		Vector3 rightboundary = Camera.main.ViewportToWorldPoint(new Vector3 (1,0,distanceToCamera));
		Xmin=leftboundary.x;
		Xmax=rightboundary.x;
		
		SpawnUntilFull();
		

	}
	

	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition();
		if(freePosition){
			GameObject enemy =	Instantiate (enemyPrefab,freePosition.position,Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
	 	}
	 	if (NextFreePosition()){
	 	
	 	Invoke ("SpawnUntilFull" ,spawndelay);
		}	 
	 } 
	
	
	public void OnDrawGizmos () {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width,height));
	}
	
	// Update is called once per frame
	void Update () {
		if (movingright) {
			transform.position+= Vector3.right *speed*Time.deltaTime;
			} else {
				transform.position+= Vector3.left *speed*Time.deltaTime;
			  }
			  
		float rightEdgeofFormation = transform.position.x + width*0.5f;
		float leftEdgeofFormation = transform.position.x - width*0.5f;
		
		if (leftEdgeofFormation <= Xmin){
			movingright = true;
		} else if (rightEdgeofFormation >Xmax) {
			movingright = false;
			
		}
	
		if (AllMembersDead()) {
			Debug.Log ("Empty Formation");
			SpawnUntilFull();
		
		}//AllMembersDead
		}//Update
		
		
		Transform NextFreePosition(){
			foreach(Transform childPositionGameObject in transform){
				if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
				}
			}
			return null;
		}
		
		bool AllMembersDead(){
	
			foreach(Transform childPositionGameObject in transform){
				if (childPositionGameObject.childCount > 0) {
					return false;
				}
			}
			return true;
			
		}
		
	
	
	
		

}


/*	Vector3 leftmost  = Camera.main.ViewportToWorldPoint (new Vector3 (0,0));
Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0));
Xmin = leftmost.x + padding;
Xmax = rightmost.x - padding;
float newX = Mathf.Clamp (transform.position.x, Xmin, Xmax);

if (transform.position.x <Xmax && changemove=="left") {transform.position = new Vector3 (newX +(speed * Time.deltaTime) , enemyPrefab.transform.position.y,enemyPrefab.transform.position.z);
} else if (transform.position.x ==Xmax) { changemove = "right";transform.position = new Vector3 (newX -(speed * Time.deltaTime) , enemyPrefab.transform.position.y,enemyPrefab.transform.position.z);
	
*/			
		
		
		
//	void SpawnEnemies () {
//		foreach(Transform child in transform){
//			GameObject enemy =	Instantiate (enemyPrefab,child.transform.position,Quaternion.identity) as GameObject;
//		enemy.transform.parent = child;
//		} 
//	}
		
	