using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************************************
//                      Player_Input_Controller Class
//
//   Handles all of the movement of the 'bats'.
//   Pong game initially developed from tutorial at https://youtu.be/1TULw0ozlK0
//********************************************************************
public class Player_Input_Controller : MonoBehaviour {

	// Script that handles input from two players
	// Player 1 => Controls left bat with W/S keys
	// Player 2 => Controls right bat with arrow keys

	public GameObject leftBat;
	public GameObject rightBat;


    //*******************************************************************
    //                    ObjectName:Start()
    //                    Parameters: N/A
    //
    //      Start is called before the first frame update, like a constructor.
    //      Starts is unnecessary to utilize here.
    //********************************************************************
    void Start () {
		
	}

    //*******************************************************************
    //                    ObjectName:Update()
    //                    Parameters: N/A
    //
    //      Update is called once per frame, checks for player input, w and s for left
    //      player and up and down arrow key for right player. Moves the bats in those same
    //      associated directions on each frame.
    //********************************************************************
    void Update () {

		//Defualt speed of the bat to zero on every frame
		leftBat.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

		//If the player is pressing the W key...
		if (Input.GetKey (KeyCode.W)) {

			//Set the velocity to go up 1
			leftBat.GetComponent<Rigidbody>().velocity = new Vector3(0f, 8f, 0f);
		}

		//If the player is pressing the S key...
		else if (Input.GetKey (KeyCode.S)) {

			//Set the velocity to go down 1 (up -1)
			leftBat.GetComponent<Rigidbody>().velocity = new Vector3(0f, -8f, 0f);
		}

		//If you aren't pressing either key, velocity will stay at zero

		//Defualt speed of the bat to zero on every frame
		rightBat.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

		//If the player is pressing the UpArrow key...
		if (Input.GetKey (KeyCode.UpArrow)) {

			//Set the velocity to go up 1
			rightBat.GetComponent<Rigidbody>().velocity = new Vector3(0f, 8f, 0f);
		}

		//If the player is pressing the DownArrow key...
		else if (Input.GetKey (KeyCode.DownArrow)) {

			//Set the velocity to go down 1 (up -1)
			rightBat.GetComponent<Rigidbody>().velocity = new Vector3(0f, -8f, 0f);
		}

		//If you aren't pressing either key, velocity will stay at zero

	}
}
