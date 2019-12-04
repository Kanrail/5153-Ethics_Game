using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame2()
    {
        SceneManager.LoadScene(6);
    }
}
