using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class interact_script : MonoBehaviour
{
    public TextMeshProUGUI yourText; // Insert your text object inside unity inspector
    public TextMeshProUGUI dialoguebox;
    private Animator boxanim;
    private palette_manager_script palman;

    public Image box;
    public string dialogue;
    public bool istouching;

    public int YPindex;
    public bool isYours;

    public bool talkison;
    public bool gotonextscene;
    public bool istyping;
    // Start is called before the first frame update
    void Start()
    {
        istyping = false;
        yourText.enabled = false;
        istouching = false;
        talkison = false;
        palman = GameObject.FindGameObjectWithTag("palettemanager_tag").GetComponent<palette_manager_script>();
        dialoguebox = GameObject.FindGameObjectWithTag("dialogue_tag").GetComponent<TextMeshProUGUI>(); 
        boxanim = GameObject.FindGameObjectWithTag("box_tag").GetComponent<Animator>(); 
        dialoguebox.enabled = false;
        box = GameObject.FindGameObjectWithTag("box_tag").GetComponent<Image>(); 
        //box.enabled = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && istouching)
        {
            boxanim.SetBool("triggerPop",true);
            dialoguebox.enabled = true;
            //box.enabled = true;
            if (isYours && istyping == false)
            {
                //dialoguebox.text = "It's your piece called "+ palman.paintingnames[0];
                dialoguebox.text = "";
                StartCoroutine(Type("It's your piece called "+ palman.paintingnames[YPindex]));
                istyping=true;
            }
            else if (istyping == false)
            {
                //dialoguebox.text = ""+dialogue;
                dialoguebox.text = "";
                StartCoroutine(Type(dialogue));
                istyping=true;
                
            }
            
            talkison = true;
            yourText.enabled = false;
            

        }

        if ((Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.D)) && talkison)
        {
            boxanim.SetBool("triggerPop",false);
            dialoguebox.enabled = false;
            //box.enabled = false;
            dialoguebox.text = "";
            talkison = false;
            yourText.enabled = true;

            if (gotonextscene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }
            


        } 
        
    }

    IEnumerator Type(string sentence){
        foreach(char letter in sentence)
        {
            dialoguebox.text += letter;
            yield return new WaitForSeconds(0.02f);
            
        }
        istyping=false;
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        yourText.enabled = true; // May need to use .SetActive(true);
        istouching = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        boxanim.SetBool("triggerPop",false);
        yourText.enabled = false; // May need to use .SetActive(true);
        istouching = false;
        dialoguebox.enabled = false;
        //box.enabled = false;
        dialoguebox.text = "";
        talkison = false;
        

    }


}
