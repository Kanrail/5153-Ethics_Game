using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour
{
    // Food Pellet Object
    public GameObject foodPrefab;

    // Border Transformation Variables
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    //Function Name: Start
    //Parameters: None
    //Description: Default Initializer, handles the beginning of the food spawning function
    void Start()
    {
        // Spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
    }

    //Function Name: Spawn
    //Parameters: None
    //Description: Randomly places a food pellet in between the established borders
    void Spawn()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x,
            borderRight.position.x);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y,
            borderTop.position.y);

        // Instantiate the food at (x, y)
        Instantiate(foodPrefab,
            new Vector2(x, y),
            Quaternion.identity); // default rotation
    }
}