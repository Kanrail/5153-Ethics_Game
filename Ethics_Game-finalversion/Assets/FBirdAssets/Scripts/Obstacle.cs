using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//*******************************************************************
//                      Obstacle Class
//
//   Handles the movement of all of the logs that bob up and down in the Fbird minigame.
//   Flappybird game was initially developed from tutorial available at
//   https://noobtuts.com/unity/2d-flappy-bird-game
//********************************************************************
public class Obstacle : MonoBehaviour
{
    // Movement Speed (0 means don't move)
    public float speed = 0;

    // Switch Movement Direction every x seconds
    public float switchTime = 2;

    //*******************************************************************
    //                    ObjectName:Start()
    //                    Parameters: N/A
    //
    //      Start is called before the first frame update, like a constructor.
    //      Starts the movement of the all the logs up and down.
    //********************************************************************
    void Start()
    {
        // Initial Movement Direction
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

        // Switch every few seconds
        InvokeRepeating("Switch", 0, switchTime);
    }

    //*******************************************************************
    //                    ObjectName:Switch()
    //                    Parameters: N/A
    //
    //      Reverses the direction of the logs. Down becomes up, up becomes down.
    //********************************************************************
    void Switch()
    {
        GetComponent<Rigidbody2D>().velocity *= -1;
    }
}