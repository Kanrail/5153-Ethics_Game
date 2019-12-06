using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//*******************************************************************
//                      Game2Actions Class
//
//   Handles all of the background labels and win conditions for the 
//   Snake minigame
//   Constructed initially from tutorial available at https://noobtuts.com/unity/2d-snake-game
//********************************************************************
public class Game2Actions : MonoBehaviour
{
    private int numLeftToWin;
    public Text numLeftLabel;

    //*******************************************************************
    //                    ObjectName:Start()
    //                    Parameters: N/A
    //
    //      Start is called before the first frame update, like a constructor.
    //      Sets the initial number of pellets needed to win and updates that label.
    //********************************************************************
    void Start()
    {
        numLeftToWin = 10;
        numLeftLabel.text = numLeftToWin.ToString();
    }

    //*******************************************************************
    //                    ObjectName:Update()
    //                    Parameters: N/A
    //
    //      Update is called once per frame, was unnecessary, but required.
    //********************************************************************
    void Update()
    {
        
    }

    //*******************************************************************
    //                    ObjectName:DecreaseNumLeftToWin()
    //                    Parameters: N/A
    //
    //      Decrements the number of pellets needed to win and updates that label
    //********************************************************************
    public void DecreaseNumLeftToWin()
    {
        numLeftToWin--;
        numLeftLabel.text = numLeftToWin.ToString();
    }

    //*******************************************************************
    //                    ObjectName:EnoughToWin()
    //                    Parameters: N/A
    //
    //      Checks to see if the number needed to win has reached 0, and if so,
    //      Send the user to the Ethics Question scene.
    //********************************************************************
    public void EnoughToWin()
    {
        if (numLeftToWin == 0)
        {
            //Will eventually progress to ethics question
            SceneManager.LoadScene("EthicsQuestion");
        }
    }
}
