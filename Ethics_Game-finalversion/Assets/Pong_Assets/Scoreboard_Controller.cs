using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

//*******************************************************************
//                      Scoreboard_Controller Class
//
//   Handles updating the scoreboard at the top of the game
//********************************************************************
public class Scoreboard_Controller : MonoBehaviour {

	public static Scoreboard_Controller instance;

	public Text playerOneScoreText;
	public Text playerTwoScoreText;

	public int playerOneScore;
	public int playerTwoScore;

    //*******************************************************************
    //                    ObjectName:Start()
    //                    Parameters: N/A
    //
    //      Start is called before the first frame update, like a constructor.
    //      Sets the initial scores to 0.
    //********************************************************************
    void Start () {

		instance = this;

		playerOneScore = playerTwoScore = 0;
	}

    //*******************************************************************
    //                    ObjectName:Update()
    //                    Parameters: N/A
    //
    //      Update is called once per frame, was unnecessary, but required.
    //********************************************************************
    void Update () {

		
	}

    //*******************************************************************
    //                    ObjectName:GivePlayerOneAPoint()
    //                    Parameters: N/A
    //
    //      Increases the left player score total by one
    //********************************************************************
    public void GivePlayerOneAPoint () {

		playerOneScore += 1;

		playerOneScoreText.text = playerOneScore.ToString ();

		//Enter player 1 victory
		if (playerOneScore > 0) {

			SceneManager.LoadScene ("Player1Victory");
		}
	}

    //*******************************************************************
    //                    ObjectName:GivePlayerTwoAPoint()
    //                    Parameters: N/A
    //
    //      Increases the right player score total by one
    //********************************************************************
    public void GivePlayerTwoAPoint () {

		playerTwoScore += 1;

		playerTwoScoreText.text = playerTwoScore.ToString ();

		//Enter player 2 victory
		if (playerTwoScore > 0) {

			SceneManager.LoadScene ("Player2Victory");
		}
	}

}
