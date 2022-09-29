using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private bool nottyping;
    private GameObject optionmenu;
    Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        //optionmenu = GameObject.Find("optionboxes");
        //optionmenu.SetActive(false);
        textDisplay.text = "";
        nottyping = false;
        StartCoroutine(Type());
        
    }

    IEnumerator Type(){
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            
        }
        nottyping = true;
        
    }



    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Z)|| Input.GetKeyDown(KeyCode.DownArrow)) && nottyping)
        {
            if(index < sentences.Length -1){
                index ++;
                textDisplay.text = "";
                StartCoroutine(Type());
                nottyping = false;
            }
            else if (index >= sentences.Length -1) {
                //if (SceneManager.GetActiveScene().buildIndex==1 || SceneManager.GetActiveScene().buildIndex==11 || SceneManager.GetActiveScene().buildIndex==13)
                //{
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);}
                //else
                //{
                    //optionmenu.SetActive(true);}
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }

        }
        //else if (index >= sentences.Length -1) {
                //if (SceneManager.GetActiveScene().buildIndex==1)
                //{
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);}
                //else
                //{
                //if (SceneManager.GetActiveScene().buildIndex!=1 && SceneManager.GetActiveScene().buildIndex!=11 & SceneManager.GetActiveScene().buildIndex!=13 & )
                //{
                    //optionmenu.SetActive(true);

                //}
                //}
        //}
 
    }
}
