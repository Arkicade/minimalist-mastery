using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newcolor_script : MonoBehaviour
{
    public int thiscolor;
    private palette_manager_script palman;
    public SpriteRenderer changecolor;
    // Start is called before the first frame update
    void Start()
    {
        palman = GameObject.FindGameObjectWithTag("palettemanager_tag").GetComponent<palette_manager_script>();
        changecolor = this.gameObject.GetComponent<SpriteRenderer>();
        switch (thiscolor)
        {
            case 1:
                //Debug.Log("is SUPPOSED TO WORK AHHA");
                changecolor.color = palman.col_1;
                break;
            case 2:
                changecolor.color = palman.col_2;
                break;
            case 3:
                changecolor.color = palman.col_3;
                break;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
