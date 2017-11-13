using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {


    // Use this for initialization
    bool clicked;

    void Start () {
        clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(clicked=true)
        {
            if (this.name == "Cube")
                SceneManager.LoadScene("Scene1");
            else 
                Debug.Log("quit")
        }
	}

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Scene1");
    }
}
