using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine;

public class Button_Controller : MonoBehaviour {

    public void StartGame () {

		SceneManager.LoadScene ("Level Select Screen");
	}

    public void StartGame_Easy()
    {

    }

    public void StartGame_Medium()
    {

        SceneManager.LoadScene(3);
    }

    public void StartGame_Hard()
    {

    }

    public void Rematch()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame () {

		Application.Quit ();
	}

}
