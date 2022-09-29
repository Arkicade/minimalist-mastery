using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    ///FindObjectOfType<AudioManager>().Play("reroll");
    ////FindObjectOfType<AudioManager>().Play("collect");


    Scene scene;
    public Sound[] sounds;
    public static AudioManager instance;

    // Start is called before the first frame update

    void Awake(){
        if (instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();

    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (scene.buildIndex ==0)
        {
            Play("title_theme");
        }
        else if (scene.buildIndex ==1)
        {
            Play("select_theme");
        }
  /*       if (scene.buildIndex == 0)
        {
            Play("menu_theme");

        }
        else if (scene.buildIndex == 1)
        {
            Play("tutorial_theme");
            
            
        }
        else
        {
            Play("game_theme");
            GameM = GameObject.FindWithTag("GameController");
            GM = GameM.GetComponent<GameManager_script>();
            
        }
         */
        
    }

    //private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    //{
        //if (scene.buildIndex ==1)
        //{
            //Play("select_theme");

        //}
     // do whatever you like
    //}

    void OnEnable()
    {
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex ==2)
        {
            StopPlaying("puzzle1");
            StopPlaying("title_theme");
            Play("select_theme");

        }
        else if (scene.buildIndex ==3)
        {
            StopPlaying("puzzle1");
            StopPlaying("select_theme");
            Play("puzzle3");

        }
        else if(scene.buildIndex == 11)
        {
            StopPlaying("puzzle3");

        }
        else if (scene.buildIndex == 12)
        {
            Play("strolling");
        }
        else if (scene.buildIndex == 13)
        {
            StopPlaying("strolling");
            Play("GO");
        }
        else if (scene.buildIndex == 14)
        {
            StopPlaying("GO");
            Play("puzzle2");
        }
        else if (scene.buildIndex == 17)
        {
            StopPlaying("puzzle2");
            Play("avantart");
        }
        else if (scene.buildIndex == 18)
        {
            StopPlaying("avantart");
        }
        else if (scene.buildIndex == 19)
        {
            Play("imposter");
        }
        else if (scene.buildIndex == 20)
        {
            StopPlaying("imposter");
            Play("puzzle1");
        }

        //Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log(mode);
    }

    // Update is called once per frame
    void Update()
    {
        
/*         if (scene.buildIndex == 1)
        {
            if(GM.gameover)
            {
                Debug.Log("play lost theme");
                //StopPlaying("game_theme");
                /// THIS IS A PROBLEM WITH THE UPDATE FUNCTION, check if the game is ALREADY playing it, if not, THEN play the theme otherwise you do
        
                
               Play("gameover");
            }
            else if(GM.gamewon)
            {
                Debug.Log("play win theme");
                //StopPlaying("game_theme");
                Play("gamewon");

            }

        } */

        
    }
}
