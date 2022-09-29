using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_script : MonoBehaviour
{
    void Update()
    {
        //if (isreset)
        //{
            //isreset=false;
        //}
        if (Input.GetKeyDown("space") && SceneManager.GetActiveScene().buildIndex==0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        else if (Input.GetKeyDown("space") && SceneManager.GetActiveScene().buildIndex==20)
        {
            SceneManager.LoadScene(3);

        }
        
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
