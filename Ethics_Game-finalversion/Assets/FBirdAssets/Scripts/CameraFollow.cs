using UnityEngine;
using System.Collections;

//*******************************************************************
//                      CameraFollow Class
//
//   Handles making sure that the camera follows the 'bird' target
//   Flappybird game was initially developed from tutorial available at
//   https://noobtuts.com/unity/2d-flappy-bird-game
//********************************************************************
public class CameraFollow : MonoBehaviour
{
    // The Target
    public Transform target;

    //*******************************************************************
    //                    ObjectName:LateUpdate()
    //                    Parameters: N/A
    //
    //      When the bird sprite moves, it ensures that the viewing camera of the 
    //      stays centered horizontally on the bird.
    //********************************************************************
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x,
                                         transform.position.y,
                                         transform.position.z);
    }
}