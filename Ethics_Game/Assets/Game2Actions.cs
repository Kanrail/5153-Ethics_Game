using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game2Actions : MonoBehaviour
{
    private int numLeftToWin;
    public Text numLeftLabel;

    // Start is called before the first frame update
    void Start()
    {
        numLeftToWin = 10;
        numLeftLabel.text = numLeftToWin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseNumLeftToWin()
    {
        numLeftToWin--;
        numLeftLabel.text = numLeftToWin.ToString();
        EnoughToWin();
    }

    public void EnoughToWin()
    {
        if (numLeftToWin == 0)
        {
            //Will eventually progress to ethics question
            SceneManager.LoadScene(0);
        }
    }
}
