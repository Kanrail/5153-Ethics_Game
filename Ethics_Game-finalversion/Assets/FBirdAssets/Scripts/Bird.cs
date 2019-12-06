using UnityEngine;
using UnityEngine.SceneManagement;
//using System.Collections;

//*******************************************************************
//                      Bird Class
//
//   Handles all of the behavior for the bird to include movement (player input using spacebar),
//   collision handling, and tracking the bird's total state.
//   Flappybird game was initially developed from tutorial available at
//   https://noobtuts.com/unity/2d-flappy-bird-game
//********************************************************************
public class Bird : MonoBehaviour
{
    // Movement speed
    public float speed = 2;

    // Flap force
    public float force = 300;

    //*******************************************************************
    //                    ObjectName:Start()
    //                    Parameters: N/A
    //
    //      Start is called before the first frame update, like a constructor.
    //      Starts the movement of the bird, initially right and slightly falling.
    //********************************************************************
    void Start()
    {
        // Fly towards the right
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    //*******************************************************************
    //                    ObjectName:Update()
    //                    Parameters: N/A
    //
    //      Update is called once per frame, if the spacebar is pressed on any
    //      frame, provide an upward force to the board to act as the 'flap'.
    //********************************************************************
    void Update()
    {
        // Flap
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }

    //*******************************************************************
    //                    ObjectName:OnTriggerEnter2D()
    //                    Parameters: Collider2d coll
    //
    //      This function is called when colliding with any object designated a 2D
    //      collidable object. If that object is the goal line, it sends the player
    //      to the Ethics Question scene.
    //      If the collision is anything else, it resets the minigame back to start of scene.
    //********************************************************************
    void OnCollisionEnter2D(Collision2D coll)
    {
        // Reached the goal line
        if (coll.gameObject.name.StartsWith("Goal"))
        {
            SceneManager.LoadScene("EthicsQuestion");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            // Restart
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("FlappyBird");
        }

    }
}