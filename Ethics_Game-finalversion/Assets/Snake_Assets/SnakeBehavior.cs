using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

//*******************************************************************
//                      SnakeBehavior Class
//
//   Handles all of the behavior for the snake to include movement (player input using arrow keys),
//   collision handling, and tracking the snake's tail and total state.
//   Constructed initially from tutorial available at https://noobtuts.com/unity/2d-snake-game
//********************************************************************
public class SnakeBehavior : MonoBehaviour
{
    // Current Movement Direction
    // (by default it moves to the right)
    Vector2 direction = Vector2.right;

    List<Transform> tail = new List<Transform>();

    //Instantiate Game2Actions for updating game pieces
    public Game2Actions numLeftToGo;
    //Crate_Forward script = GameObject.Find("crate").GetComponent<Crate_Forward>();

    // Did the snake eat something?
    bool ate = false;

    // Did the snake hit a wall or itself?
    bool hitObstacle = false;

    // Tail Prefab
    public GameObject tailPrefab;

    //*******************************************************************
    //                    ObjectName:Start()
    //                    Parameters: N/A
    //
    //      Start is called before the first frame update, like a constructor.
    //      Starts the movement of the snake, initially left.
    //********************************************************************
    void Start()
    {
        // Move the Snake every 300ms
        InvokeRepeating("Move", 0.08f, 0.08f);

        numLeftToGo = GameObject.Find("NumLeftLabel").GetComponent<Game2Actions>();
    }

    //*******************************************************************
    //                    ObjectName:Update()
    //                    Parameters: N/A
    //
    //      Update is called once per frame, if an arrow key is pressed on any
    //      frame, change the snakes direction to associate with the pressed
    //      arrow key.
    //********************************************************************
    void Update()
    {
        // Move in a new Direction?
        if (Input.GetKey(KeyCode.RightArrow))
            direction = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            direction = -Vector2.up;    // '-up' means 'down'
        else if (Input.GetKey(KeyCode.LeftArrow))
            direction = -Vector2.right; // '-right' means 'left'
        else if (Input.GetKey(KeyCode.UpArrow))
            direction = Vector2.up;
    }

    //*******************************************************************
    //                    ObjectName:Move()
    //                    Parameters: N/A
    //
    //      Updates and tracks the current location of the snake head and tail.
    //      When updating, if 'ate' flag is true, it will spawn a new tail at end of snake.
    //********************************************************************
    void Move()
    {
        // Save current position
        Vector2 v = transform.position;

        // Move head into new direction
        transform.Translate(direction);

        // Ate something? Then insert new Element into gap
        if (ate)
        {
            // Load Prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab,
                v,
                Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }
        // Do we have a Tail?
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    //*******************************************************************
    //                    ObjectName:OnTriggerEnter2D()
    //                    Parameters: Collider2d coll
    //
    //      This function is called when colliding with any object designated a 2D
    //      collidable object. If that object is a food pellet, it decrements the label
    //      and sets the 'ate' flag to true and destroys the food pellet sprite.
    //      If the collision is anything else, it sends the player to game over.
    //********************************************************************
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("FoodPrefab"))
        {
            // Get longer in next Move call
            ate = true;

            // Remove the Food
            Destroy(coll.gameObject);

            // Decrease the number left
            numLeftToGo.DecreaseNumLeftToWin();

            // Check to see if enough to win
            numLeftToGo.EnoughToWin();
        }
        // Collided with Tail or Border
        else
        {
            SceneManager.LoadScene("Game2GameOver");
        }
    }
}