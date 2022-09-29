using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class palette_manager_script : MonoBehaviour
{
    static palette_manager_script instance;

    public Color col_1;
    public Color col_2;
    public Color col_3;

    public List<string> paintingnames;

    // Start is called before the first frame update
    
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
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("escape key has been pressed");
            Application.Quit();
        }

        if (Input.GetKeyDown("space") && SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        
    }

    public void changepalette()
    {
        Debug.Log("changing palette");
        GameObject pal = EventSystem.current.currentSelectedGameObject;
        
        //for(int i=0; i < pal.transform.childCount; i++)
        //{
            //Transform child = pal.transform.GetChild(i);
        //}
        Transform child1 = pal.transform.GetChild(2);
        Transform child2 = pal.transform.GetChild(1);
        Transform child3 = pal.transform.GetChild(0);
        Color color1 = child1.GetComponent<Image>().color;
        Color color2 = child2.GetComponent<Image>().color;
        Color color3 = child3.GetComponent<Image>().color;

        col_1 = color1;
        col_2 = color2;
        col_3 = color3;


    }


}
