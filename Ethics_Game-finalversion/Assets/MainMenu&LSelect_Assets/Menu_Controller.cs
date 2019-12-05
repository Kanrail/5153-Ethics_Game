using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu_Controller : MonoBehaviour {

    public void Start()
    {
        PlaySoundFile();

        Debug.Log("Start");
    }

    public void StartGame () {

		SceneManager.LoadScene ("Level Select Screen");
	}

    public void StartGame_Easy()
    {
        SceneManager.LoadScene("Game2");
    }

    public void StartGame_Medium()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void StartGame_Hard()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    public void PongStartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SnakeGameRestart()
    {
        SceneManager.LoadScene("Game2");
    }

    public void LoadEthicsQuestion()
    {
        SceneManager.LoadScene("EthicsQuestion");
    }

    public void Rematch()
    {
        SceneManager.LoadScene("Game");
    }

    
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
