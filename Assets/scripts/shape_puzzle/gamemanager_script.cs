using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using System;
using UnityEngine.SceneManagement;

public class gamemanager_script : MonoBehaviour
{

    [Header("TOTAL COUNT OF SIDES AND COLOR")]
    public int total_sides;
    public int total_col1;
    public int total_col2;
    public int total_col3;

    [Header("TOTAL COUNT TYPE OF SHAPES")]
    public int total_rect;
    public int total_tri;
    public int total_pent;
    public int total_circ;

    [Header("GOAL COUNT OF SIDES AND COLOR")]
    public int goal_sides;
    public int goal_col1;
    public int goal_col2;
    public int goal_col3;

    [Header("GOAL COUNT TYPE OF SHAPES")]
    public int goal_rect;
    public int goal_tri;
    public int goal_pent;
    public int goal_circ;

    [Header("EVAL OF SIDES AND COLOR")]
    public int eval_sides;
    public int eval_col1;
    public int eval_col2;
    public int eval_col3;

    [Header("EVAL TYPE OF SHAPES")]
    public int eval_rect;
    public int eval_tri;
    public int eval_pent;
    public int eval_circ;




    private int winpoints;

    public bool PSdone;
    public string painting_name;

    public TextMeshProUGUI goaltext;

    private GameObject puzzlesection;
    private GameObject namingsection;

    private palette_manager_script palman;

    // Start is called before the first frame update
    
    void Start()
    {
        palman = GameObject.FindWithTag("palettemanager_tag").GetComponent<palette_manager_script>();
        puzzlesection = GameObject.Find("puzzlesection");
        puzzlesection.SetActive(true);
        namingsection = GameObject.Find("namingsection");
        namingsection.SetActive(false);

        goaltext = GameObject.FindWithTag("goaltext").GetComponent<TextMeshProUGUI>();
        
        MakeGoalText();
        winpoints = 0;

        PSdone = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScenario(List<GameObject> obj_list)
    {
        total_sides=0;
        total_col1=0;
        total_col2=0;
        total_col3=0;
        total_rect=0;
        total_tri=0;
        total_pent=0;
        total_circ=0;

        foreach(GameObject item in obj_list)
        {
            shape_script SS = item.GetComponent<shape_script>();
            total_sides += SS.shape_sides;

            if (SS.shape_color==1)
            {
                total_col1+=1;}
            else if (SS.shape_color ==2)
            {
                total_col2+=1;}
            else
            {
                total_col3+=1;}

            if(SS.shape_sides==3)
            {
                total_tri+=1;
            }
            else if (SS.shape_sides==4)
            {
                total_rect+=1;
            }
            else if (SS.shape_sides==5)
            {
                total_pent+=1;
            }
            else{
                total_circ+=1;
            }

        }

    }

    void evaluatescore(int eval, int total, int goal)
    {
        switch (eval)
        {
            case 0:
                winpoints += 1;
                break;
            case 1:
                if (total == goal)
                    winpoints += 1;
                break;
            case 2:
                if (total < goal)
                    winpoints += 1;
                break;
            case 3:
                if (total > goal)
                    winpoints += 1;
                break;
        }

        //return winpoints;


    }

    public void ClickPalette()
    {
        if (PSdone)
        {
            TMP_InputField tMP_Input = GameObject.Find("InputPainting").GetComponent<TMP_InputField>();
            painting_name = tMP_Input.text;
            //Debug.Log("painting name is: "+painting_name);
            palman.paintingnames.Add(painting_name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        else
        {
            winpoints = 0;

            evaluatescore(eval_sides, total_sides, goal_sides);
            evaluatescore(eval_col1, total_col1, goal_col1);
            evaluatescore(eval_col2, total_col2, goal_col2);
            evaluatescore(eval_col3, total_col3, goal_col3);
        

            if (winpoints == 4)
            {
                puzzlesection.SetActive(false);
                namingsection.SetActive(true);
                PSdone = true;
            }
            else{
                Debug.Log("whoops you lost");
            }
            
        }


    }

    public string TextMake(int eval, string ST, string goal,int g)
    {
        string returnval = "";
        switch(eval)
        {
            case 0:
                return "";
                break;
            case 1:
                returnval = "\n•"+goal;
                break;
            case 2:
                returnval = "\n•less than "+goal;
                break;
            case 3:
                returnval = "\n•greater than "+goal;
                break;
        }

        if (g != 1)
        {
            returnval = returnval + "s";
        }

        return returnval;

    }

    public void MakeGoalText()
    {
        string sidetext = "";
        string onetext = "";
        string twotext = "";
        string threetext = "";
        //GL.text = "";

        string recttext = "";
        string tritext ="";
        string penttext = "";
        string circtext ="";

        string goalsidetext = goal_sides+" side";
        string shapetext1 = goal_col1+" color A shape";
        string shapetext2 = goal_col2+" color B shape";
        string shapetext3 = goal_col3+" color C shape";

        string sidestext1 = goal_rect + " rectangle";
        string sidestext2 = goal_tri + " triangle";
        string sidestext3 = goal_pent +" pentagon";
        string sidestext4 = goal_circ + " circle";

        sidetext= TextMake(eval_sides,sidetext,goalsidetext,goal_sides);
        onetext = TextMake(eval_col1, onetext, shapetext1,goal_col1);
        twotext = TextMake(eval_col2, twotext, shapetext2,goal_col2);
        threetext = TextMake(eval_col3, threetext, shapetext3,goal_col3);

        recttext = TextMake(eval_rect,recttext,sidestext1,goal_rect);
        tritext = TextMake(eval_tri,tritext,sidestext2,goal_tri);
        penttext = TextMake(eval_pent,penttext,sidestext3,goal_pent);
        circtext = TextMake(eval_circ,circtext,sidestext4,goal_circ);

        goaltext.text = sidetext + onetext + twotext + threetext + recttext + tritext + penttext + circtext;
        //goaltext.text = "sdagjlkjasfdjkasfdjlkasfdjlkasfdjasldf";
        //Debug.Log(sidetext + " " + onetext + " " + twotext + " " + threetext);

    }



}
