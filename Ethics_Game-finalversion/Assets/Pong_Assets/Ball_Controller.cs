using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************************************
//                      Ball_Controller Class
//
//   Handles all of the behavior for the ball to include movement,
//   collision handling, and tracking the ball's total state.
//********************************************************************
public class Ball_Controller : MonoBehaviour
{

    //Get a reference to the rigidbody attached to the gameObject
    Rigidbody rb;

    float speed = 1.5f;

    //*******************************************************************
    //                    ObjectName:Start()
    //                    Parameters: N/A
    //
    //      Start is called before the first frame update, like a constructor.
    //      Starts the movement of the ball after a 10 second delay.
    //********************************************************************
    void Start()
    {

        //Get shortcut to rigidbody component
        rb = GetComponent<Rigidbody>();

        //Pause ball logic for 2.5 seconds, delay launch
        StartCoroutine(Pause());
    }

    //*******************************************************************
    //                    ObjectName:Update()
    //                    Parameters: N/A
    //
    //      Update is called once per frame, tracks position of ball on each frame
    //      And if ball has left screen, it gives the appropriate player a point.
    //********************************************************************
    void Update()
    {

        //If ball goes too far left...
        if (transform.position.x < -25f)
        {

            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;

            //Give player 2 a point
            Scoreboard_Controller.instance.GivePlayerTwoAPoint();


            StartCoroutine(Pause());
        }


        //If ball goes too far right...
        if (transform.position.x > 25f)
        {

            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;

            //Give Player 1 a point
            Scoreboard_Controller.instance.GivePlayerOneAPoint();

            StartCoroutine(Pause());
        }


    }

    //*******************************************************************
    //                    ObjectName:Pause()
    //                    Parameters: N/A
    //
    //      Calls the LaunchBall function after 2.5 seconds.
    //********************************************************************
    IEnumerator Pause()
    {


        //Wait for 2.5 seconds
        yield return new WaitForSeconds(2.5f);

        //Call function that launches the ball
        LaunchBall();
    }

    //*******************************************************************
    //                    ObjectName:LaunchBall()
    //                    Parameters: N/A
    //
    //      Launches the ball in a random direction.
    //********************************************************************
    void LaunchBall()
    {

        transform.position = Vector3.zero;

        //Ball Chooses a direction
        //Flies that direction

        //Flip a coin, determine direction in x-axis
        int xDirection = Random.Range(0, 2);

        //Flip another coin, determine direction in y-axis
        int yDirection = Random.Range(0, 3);


        Vector3 launchDirection = new Vector3();

        //Check results of one coin toss
        if (xDirection == 0)
        {

            launchDirection.x = -8f;
        }
        if (xDirection == 1)
        {

            launchDirection.x = 8f;
        }

        //Check results of second coin toss
        if (yDirection == 0)
        {

            launchDirection.y = -8f;
        }
        if (yDirection == 1)
        {

            launchDirection.y = 8f;
        }
        if (yDirection == 2)
        {

            launchDirection.y = 0f;
        }

        //Assign velocity based off of where we launch ball
        rb.velocity = launchDirection * speed;
    }

    //*******************************************************************
    //                    ObjectName:OnCollisionEnter()
    //                    Parameters: Collision hit
    //
    //      Handles collision with sides and 'bats'. Randomly selects a direction
    //      on collision with bats, and selects a subvector from the same direction the
    //      ball was already traveling if collision with the top or bottom.
    //********************************************************************
    void OnCollisionEnter(Collision hit)
    {

        //If it was the top or bottom of the screen...
        if (hit.gameObject.name == "TopBounds")
        {

            float speedInXDirection = 0f;

            if (rb.velocity.x > 0f)
                speedInXDirection = 8f;

            if (rb.velocity.x < 0f)
                speedInXDirection = -8f;

            rb.velocity = new Vector3(speedInXDirection * speed, -8f, 0f);
        }

        if (hit.gameObject.name == "BottomBounds")
        {

            float speedInXDirection = 0f;

            if (rb.velocity.x > 0f)
                speedInXDirection = 8f;

            if (rb.velocity.x < 0f)
                speedInXDirection = -8f;

            rb.velocity = new Vector3(speedInXDirection * speed, 8f, 0f);
        }

        //If it was one of the bats
        if (hit.gameObject.name == "Left_Bat")
        {

            rb.velocity = new Vector3(13f, 0f, 0f) * speed;


            //Check if we hit lower half of the bat...
            if (transform.position.y - hit.gameObject.transform.position.y < -1)
            {

                rb.velocity = new Vector3(8f, -8f, 0f) * speed;
            }
            //Check if we hit lower half of the bat...
            if (transform.position.y - hit.gameObject.transform.position.y > 1)
            {

                rb.velocity = new Vector3(8f, 8f, 0f) * speed;
            }
        }
        if (hit.gameObject.name == "Right_Bat")
        {

            rb.velocity = new Vector3(-13f, 0f, 0f) * speed;


            //Check if we hit lower half of the bat...
            if (transform.position.y - hit.gameObject.transform.position.y < -1)
            {

                rb.velocity = new Vector3(-8f, -8f, 0f) * speed;
            }
            //Check if we hit lower half of the bat...
            if (transform.position.y - hit.gameObject.transform.position.y > 1)
            {

                rb.velocity = new Vector3(-8f, 8f, 0f) * speed;
            }
        }

    }

}
