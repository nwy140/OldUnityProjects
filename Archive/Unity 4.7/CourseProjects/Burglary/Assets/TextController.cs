using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	
	private enum States { entrance_0 ,mask_0, dining_0,nothing_0, secondfloor_0 ,bed_0, destroy_0,take_0, lose,escape,jump,win , loserman ,winnerman , Null}  ;
	private States mystate;
	public Text text;
	
	
	public string obj;
	
	//addons public objective ; objective obj="Objective : Break in the house and escape \n\n"; 
	//unused enums States {window_0,lock_0,}
	
	//end addons
	
	// Use this for initialization
	void Start () { print (mystate);
		mystate=States.entrance_0;
		
	}
	
	// Update is called once per frame
	void Update () { print (mystate);
		if (mystate==States.entrance_0) { Entrance_0(); obj=""; }
		else if (mystate==States.mask_0)     { Mask_0();} 
		else if (mystate==States.dining_0)   { Dining_0( );}
		else if (mystate==States.nothing_0)  {Nothing_0();}
		else if (mystate==States.secondfloor_0){Secondfloor_0();}
		else if (mystate==States.bed_0) {Bed_0();}
		else if (mystate==States.destroy_0) {loserman();}
		else if (mystate==States.take_0) {Take_0();}
		else if (mystate==States.winnerman) {replay();}
		
	}
	#region  State handler methods
	void Entrance_0 () {text.text =  "Wow man, the window beside the  entrance's door is opened, \nlooks like somebody's asking to be robbed.  \nI am running low on cash, so I am absolutely going to break in this place." + "\n\n"+obj+  "Press C to climb in the window, L to pick the door's lock to enter , M to remove mask";
		if (Input.GetKeyDown (KeyCode.M)){text.text = "Why did you remove your mask? Put it back on now! \n\n Press R to put on your mask";mystate = States.mask_0; }	
		else if (Input.GetKeyDown (KeyCode.C ) || Input.GetKeyDown(KeyCode.L)) {mystate=States.dining_0; }	
		
	}
	void Mask_0 () { if (Input.GetKeyDown (KeyCode.R )){ mystate = States.entrance_0;  } }
	
	void Dining_0 () {text.text= "You are now in the dining room" +",there aren't anything valuable here. "+ "\nSearch the other rooms for valuables" + "\n\nPress K to search the Kitchem, T to search the Toilet, S to search the Store room, U to go to the second floor"; 
		if (Input.GetKeyDown (KeyCode.K)|| Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.S) ) {mystate=States.nothing_0;} 
		else if (Input.GetKeyDown (KeyCode.U)) { mystate=States.secondfloor_0 ; }
	}
	
	
	
	void Nothing_0 () {text.text = "Nothing worth stealing here. Man , this guy is really poor!" + "\n\nPress R to go back to Dining room";	
		if (Input.GetKeyDown (KeyCode.R)) {mystate=States.dining_0;}
	}
	
	void Secondfloor_0 () {text.text = "Maybe I should take a risk and see what's in the bed room" + "\n\nPress R to go back to Dining room, B to sneak in bed room";	
		if (Input.GetKeyDown (KeyCode.R)) {mystate=States.dining_0;}
		else if (Input.GetKeyDown (KeyCode.B)) {mystate=States.bed_0;}
	}
	
	void Bed_0 () {text.text = "There's a huge glass box beside the guy who is sleeping, what the ? Its full of hot valuables, I could name a few : iphone 7, samsung s8, wallet, gold apple watch,  and in golden keychain" + "\n\nPress D to destroy the glass box and steal everything in it, T to take the glass box";	
		if (Input.GetKeyDown (KeyCode.D)) {mystate=States.destroy_0;}
		else if (Input.GetKeyDown (KeyCode.T)) {mystate=States.take_0;}
		
		///finally completed this game!!!!!
	}
	
	
	void Take_0 () { text.text="Alright, fantastic.\n\nYou got what you needed. Now get the hell out of here before you are seen" + "\n\nPress W to jump out of bedroom's window, R to carefully bring the glass box out of the entrance back into your getaway car";
		if (Input.GetKeyDown (KeyCode.W)){ text.text="You fell to your death. Its your own fault that you died. \n\nYou lose!!!" + "\n\nPress P to replay the game"; mystate=States.winnerman;}
		else if (Input.GetKeyDown (KeyCode.R) )	{			
			text.text= "You brought the luxurious glass box out of the house with ease, and place it in the trunk of your getaway car as you drive out of this neighbourhood without causing a ruckus." +		 "\n\nYou WON!!!!   "+	"\n\nValue of Stolen Goods: $100000" 		+"\n\n" + "Press P to replay the game" ;
			mystate=States.winnerman;
			
			
		}										
	}
	
	
	
	
	void loserman () { text.text="The destruction of the glass box alerted the inhabitant as he wakes up and punches you in the face. \n\nYou have been spotted, you are supposed to be stealthy, your cover is blown." + "\n\nYou Lose" + "\n\nPress P to replay the game"; mystate=States.winnerman;}
	
	void replay () {if (Input.GetKeyDown (KeyCode.P)) {mystate=States.entrance_0;}}
	
	#endregion
	
	
}
