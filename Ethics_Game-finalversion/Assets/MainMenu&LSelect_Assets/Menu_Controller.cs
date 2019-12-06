using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine;

//*******************************************************************
//                      Menu_Controller Class
//
//   Handles Most of the buttons that go to the different scenes, and acts
//   as the first class persistent across the game to play music.
//********************************************************************
public class Menu_Controller : MonoBehaviour {

    //*******************************************************************
    //                    ObjectName:Start()
    //                    Parameters: N/A
    //
    //      Start is called before the first frame update, like a constructor.
    //      Calls the method to start playing music.
    //********************************************************************
    public void Start()
    {
        PlaySoundFile();

        Debug.Log("Start");
    }

    //*******************************************************************
    //                    ObjectName:StartGame()
    //                    Parameters: N/A
    //
    //      Loads the Level Select scene
    //********************************************************************
    public void StartGame () {

		SceneManager.LoadScene ("Level Select Screen");
	}

    //*******************************************************************
    //                    ObjectName:HelpScreen()
    //                    Parameters: N/A
    //
    //      Loads the Help scene
    //********************************************************************
    public void HelpScreen()
    {
        SceneManager.LoadScene("Help");
    }

    //*******************************************************************
    //                    ObjectName:CreditsScreen()
    //                    Parameters: N/A
    //
    //      Loads the Credits scene
    //********************************************************************
    public void CreditsScreen()
    {
        SceneManager.LoadScene("Credits");
    }

    //*******************************************************************
    //                    ObjectName:StartGame_Easy()
    //                    Parameters: N/A
    //
    //      Loads the Snake minigame scene
    //********************************************************************
    public void StartGame_Easy()
    {
        SceneManager.LoadScene("Game2");
    }

    //*******************************************************************
    //                    ObjectName:StartGame_Medium()
    //                    Parameters: N/A
    //
    //      Loads the Pong minigame startmenu scene
    //********************************************************************
    public void StartGame_Medium()
    {
        SceneManager.LoadScene("StartMenu");
    }

    //*******************************************************************
    //                    ObjectName:StartGame_Hard()
    //                    Parameters: N/A
    //
    //      Loads the Flappy Bird minigame scene
    //********************************************************************
    public void StartGame_Hard()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    //*******************************************************************
    //                    ObjectName:PongStartGame()
    //                    Parameters: N/A
    //
    //      Loads the Pong minigame scene
    //********************************************************************
    public void PongStartGame()
    {
        SceneManager.LoadScene("Game");
    }

    //*******************************************************************
    //                    ObjectName:GoMainMenu()
    //                    Parameters: N/A
    //
    //      Loads the Main Menu scene
    //********************************************************************
    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //*******************************************************************
    //                    ObjectName:SnakeGameRestart()
    //                    Parameters: N/A
    //
    //      Loads the Snake minigame scene
    //********************************************************************
    public void SnakeGameRestart()
    {
        SceneManager.LoadScene("Game2");
    }

    //*******************************************************************
    //                    ObjectName:LoadEthicsQuestion()
    //                    Parameters: N/A
    //
    //      Loads the Ethics Question scene
    //********************************************************************
    public void LoadEthicsQuestion()
    {
        SceneManager.LoadScene("EthicsQuestion");
    }

    //*******************************************************************
    //                    ObjectName:Rematch()
    //                    Parameters: N/A
    //
    //      Loads the Pong minigame scene
    //********************************************************************
    public void Rematch()
    {
        SceneManager.LoadScene("Game");
    }

    //*******************************************************************
    //                    ObjectName:QuitGame()
    //                    Parameters: N/A
    //
    //      Force closes the application
    //********************************************************************
    public void QuitGame()
    {
        Application.Quit();
    }

    //*******************************************************************
    //                    ObjectName:PlaySoundFile()
    //                    Parameters: N/A
    //
    //      Plays different music associated with whichever scene is loaded.
    //********************************************************************
    public void PlaySoundFile()
    {
        string sceneName = SceneManager.GetActiveScene().name.ToString();

        Debug.Log(sceneName.ToString());

        switch (sceneName)
        {
        case "Menu":
                AudioController.instance.PlayMenuMusic();
            break;
        case "Game":
                AudioController.instance.PlayPongGameMusic();
                break;
        case "Game2":
                AudioController.instance.PlaySnakeGameMusic();
                break;
        case "FlappyBird":
                AudioController.instance.PlayFlappyGameMusic();
                break;
        }
    }

}
