using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class text_totalsides : MonoBehaviour
{

    //public GameManager_script GM;
    public gamemanager_script GMS;
    public TextMeshProUGUI textbox;
    //public TextMeshProUGUI textMeshProUGUI;

    public string totalstat;
    
    // Start is called before the first frame update
    void Start()
    {
        GMS = GameObject.FindWithTag("manager_tag").GetComponent<gamemanager_script>();
        textbox = GetComponent<TextMeshProUGUI>();
        //textMeshProUGUI = GetComponent<TextMeshProUGUI>();
         
        //textMeshProUGUI.text = ""+GMS.total_sides;
        
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = ""+GMS.total_sides;
        //textMeshProUGUI.text = ""+GMS.total_sides;
        
    }
}
