using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class reset_script : MonoBehaviour
{
    public bool isreset;
    private shapemanager_script SMS;
    //private Animator anim;
    //private bool hovering;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();

        isreset=false;
        SMS = GameObject.FindGameObjectWithTag("manager_tag").GetComponent<shapemanager_script>();
        //anim.SetBool("isHover",false);
        //hovering = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (isreset)
        //{
            //isreset=false;
        //}

        //if (hovering == false)
        //{
            //anim.SetBool("isHover",false);
        //}
        //else
        //{
            //anim.SetBool("isHover",true);
            
        //}

        //Debug.Log(hovering);
        
    }

    void OnMouseOver()
    {
        //hovering = true;
        //anim.SetBool("isHover",true);

        if (Input.GetMouseButtonDown(0))
        {
            isreset=true;
            StartCoroutine(waittoreset());
            SMS.resetshape();


        }
            
    }

    void OnMouseExit()
    {
        //hovering = false;
        //anim.SetBool("isHover",false);

    }

    public void ClickButton()
    {
        FindObjectOfType<AudioManager>().Play("pop2");
        isreset=true;
        //StartCoroutine(waittoreset());
        SMS.resetshape();

    }
      

    IEnumerator waittoreset()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.1f);
        isreset=false;
    }



}
