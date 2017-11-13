using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

//Enum var sets
 	private enum States {cell,mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom } ;
	private States myState;
//Enum var sets END

	public Text text;
	
	void Start () {
		myState = States.cell;
	 }//Start END

	void Update () {
		print (myState);
		if (myState == States.cell) {
			state_cell ();
		} else if (myState == States.sheets_0){state_sheets_0();}
		

		}//Update END
//v		
	
		void state_cell () {						
			text.text = "You are in a prison cell, and you want to escape. There are " +
						"some dirty sheets on the bed, a mirror on the wall, and the door " +
						"is locked from the outside.\n\n" +
						"Press S to view Sheets, M to view Mirror and L to view Lock" ;
			if (Input.GetKeyDown (KeyCode.S)) {
				myState = States.sheets_0;
				
				
			}					 
		
		}//state_cell END
//v
		void state_sheets_0 () {
		
		
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasure of prison life " +
					"I guess!.\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
			}
			
		}	
		//v					


}//END	








































