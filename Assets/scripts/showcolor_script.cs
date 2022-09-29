using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class showcolor_script : MonoBehaviour
{
    public int iscolor;
    private palette_manager_script palman;
    public Graphic thiscolor;
    // Start is called before the first frame update
    void Awake()
    {
        palman = GameObject.FindGameObjectWithTag("palettemanager_tag").GetComponent<palette_manager_script>();
        thiscolor = GetComponent<Graphic>();
        switch (iscolor)
        {
            case 1:
                //Debug.Log("is SUPPOSED TO WORK AHHA");
                thiscolor.color = palman.col_1;
                break;
            case 2:
                thiscolor.color = palman.col_2;
                break;
            case 3:
                thiscolor.color = palman.col_3;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
