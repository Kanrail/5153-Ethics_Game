using EazyTools.SoundManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************************************
//                      AudioController Class
//
//   Handles all of the music for the entire game
//********************************************************************
public class AudioController : MonoBehaviour {

    public static AudioController instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public AudioClip menuMusicAudioClip;
    public AudioClip snakeGameMusicAudioClip;
    public AudioClip pongGameMusicAudioClip;
    public AudioClip flappyGameMusicAudioClip;

    public int menuMusicFileId;
    public Audio menuMusicFileAudio;

    public int snakeGameMusicFileId;
    public Audio snakeGameMusicFileAudio;

    public int pongGameMusicFileId;
    public Audio pongGameMusicFileAudio;

    public int flappyGameMusicFileId;
    public Audio flappyGameMusicFileAudio;

    //*******************************************************************
    //                    ObjectName:Start()
    //                    Parameters: N/A
    //
    //      Start is called before the first frame update, like a constructor.
    //      Binds the audio files to their associated member variables.
    //********************************************************************
    void Start()
    {
        instance.menuMusicFileId = SoundManager.PlayMusic(instance.menuMusicAudioClip, 0.0f, true, true, 1.0f, 1.0f, 1.0f, null);
        menuMusicFileAudio = SoundManager.GetAudio(instance.menuMusicFileId);

        instance.snakeGameMusicFileId = SoundManager.PlayMusic(instance.snakeGameMusicAudioClip, 0.0f, true, true, 1.0f, 1.0f, 1.0f, null);
        snakeGameMusicFileAudio = SoundManager.GetAudio(instance.snakeGameMusicFileId);

        instance.pongGameMusicFileId = SoundManager.PlayMusic(instance.pongGameMusicAudioClip, 0.0f, true, true, 1.0f, 1.0f, 1.0f, null);
        pongGameMusicFileAudio = SoundManager.GetAudio(instance.pongGameMusicFileId);

        instance.flappyGameMusicFileId = SoundManager.PlayMusic(instance.flappyGameMusicAudioClip, 0.0f, true, true, 1.0f, 1.0f, 1.0f, null);
        flappyGameMusicFileAudio = SoundManager.GetAudio(instance.flappyGameMusicFileId);

    }

    //*******************************************************************
    //                    ObjectName:PlayMenuMusic()
    //                    Parameters: N/A
    //
    //      Stops all currently playing music and changes to the menu music
    //********************************************************************
    public void PlayMenuMusic()
    {
        SoundManager.StopAllMusic();
        instance.menuMusicFileId = SoundManager.PlayMusic(instance.menuMusicAudioClip, 1.0f, true, true, 1.0f, 1.0f, 1.0f, null);
    }

    //*******************************************************************
    //                    ObjectName:PlaySnakeMusic()
    //                    Parameters: N/A
    //
    //      Stops all currently playing music and changes to the snake music
    //********************************************************************
    public void PlaySnakeGameMusic()
    {
        SoundManager.StopAllMusic();
        instance.snakeGameMusicFileId = SoundManager.PlayMusic(instance.snakeGameMusicAudioClip, 1.0f, true, true, 1.0f, 1.0f, 1.0f, null);
    }

    //*******************************************************************
    //                    ObjectName:PlayPongGameMusic()
    //                    Parameters: N/A
    //
    //      Stops all currently playing music and changes to the pong music
    //********************************************************************
    public void PlayPongGameMusic()
    {
        SoundManager.StopAllMusic();
        instance.pongGameMusicFileId = SoundManager.PlayMusic(instance.pongGameMusicAudioClip, 1.0f, true, true, 1.0f, 1.0f, 1.0f, null);
    }

    //*******************************************************************
    //                    ObjectName:PlayFlappyGameMusic()
    //                    Parameters: N/A
    //
    //      Stops all currently playing music and changes to the flappybird music
    //********************************************************************
    public void PlayFlappyGameMusic()
    {
        SoundManager.StopAllMusic();
        instance.flappyGameMusicFileId = SoundManager.PlayMusic(instance.flappyGameMusicAudioClip, 1.0f, true, true, 1.0f, 1.0f, 1.0f, null);
    }

    //*******************************************************************
    //                    ObjectName:StopAllMusic()
    //                    Parameters: N/A
    //
    //      Stops all currently playing music
    //********************************************************************
    public void StopAllMusic()
    {
        SoundManager.StopAllMusic();
    }

    //*******************************************************************
    //                    ObjectName:PauseAllMusic()
    //                    Parameters: N/A
    //
    //      Sets volume to 0
    //********************************************************************
    public void PauseAllMusic()
    {
        SoundManager.globalMusicVolume = 0.0f;
    }

    //*******************************************************************
    //                    ObjectName:ResumeAllMusic()
    //                    Parameters: N/A
    //
    //      Sets volume back to normal
    //********************************************************************
    public void ResumeAllMusic()
    {
        SoundManager.globalMusicVolume = 1.0f;
    }  
}
