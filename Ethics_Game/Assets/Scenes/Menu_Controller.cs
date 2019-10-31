using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame () {

		SceneManager.LoadScene (1);
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
