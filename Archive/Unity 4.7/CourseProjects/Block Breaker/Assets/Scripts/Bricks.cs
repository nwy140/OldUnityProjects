using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	public AudioClip crack;
	public Sprite [] HitSprites ;
	public static int breakableCount=0;
	
	
	// public int maxHits;
	private int timesHit;
	
	private LevelManager levelmanager;
	private bool isBreakable;
	
	
	
	
	// Use this for initialization
	void Start () { levelmanager=GameObject.FindObjectOfType <LevelManager>();
		isBreakable = (this.tag =="Breakable");
		if (isBreakable) {
			breakableCount++;
			
		//	print (breakableCount);
		}
		
		timesHit = 0;
		
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionExit2D (Collision2D hit) {
			AudioSource.PlayClipAtPoint (crack, transform.position);

		if (isBreakable) {	
			Handlehits ();
		}
	}
	
	void Handlehits (){
		timesHit++ ; 
		int maxHits=HitSprites.Length + 1;
		if (timesHit>=maxHits){
			breakableCount--; print (breakableCount);	
			
			
			Destroy(gameObject); print (breakableCount);
			levelmanager.BrickDestroyed ();}
			
		else {
			LoadSprites();
		}
	
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit -1;
		if (HitSprites[spriteIndex]){
		this.GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
		}
	}
	
	
	//?TODO  Remove this method once we can actually win!
	void SimulateWin() {
		levelmanager.LoadNextLevel ();
		
	}

	
	
	
	
	
	
	
	
	
	
}
