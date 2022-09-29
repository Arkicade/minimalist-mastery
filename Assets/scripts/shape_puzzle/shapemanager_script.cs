using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapemanager_script : MonoBehaviour
{
    //public GameObject[] shapes;
    public List<GameObject> shapes = new List<GameObject>();
    
    public List<GameObject> show_shapes = new List<GameObject>();

    public List<GameObject> cov_shapes = new List<GameObject>();
    //public List<GameObject> shapes;

    private gamemanager_script GMS;

    void Start()
    {
        GMS = GameObject.FindGameObjectWithTag("manager_tag").GetComponent<gamemanager_script>();
        //shapes = GameObject.FindGameObjectsWithTag("shape_tag");
        //shapes = new List<GameObject>(GameObject.FindGameObjectsWithTag("shape_tag"));

        foreach (GameObject item in shapes)
        {
            shape_script SC = item.GetComponent<shape_script>();

            if (SC.iscovered == true)
            {
                cov_shapes.Add(item);
            }
            else{
                show_shapes.Add(item);
            }

        }

        GMS.UpdateScenario(show_shapes);


        //shapes.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void resetshape()
    {
        show_shapes.Clear();

        foreach (GameObject item in shapes)
        {
            shape_script shapescript = item.GetComponent<shape_script>();
            shapescript.sprite.color = shapescript.o_color;
            //shapescript.bc2d.enabled = true;
            shapescript.pc2d.enabled = true;
            shapescript.isactive = true;

            

            //if (shapescript.iscovered == false)
            //{
            show_shapes.Add(item);
            //
            
        }

        foreach(GameObject item in cov_shapes)
        {
            shape_script shapescript = item.GetComponent<shape_script>();
            shapescript.iscovered = true;
            shapescript.isactive = false;
            //BoxCollider2D bc = item.GetComponent<BoxCollider2D>();
            PolygonCollider2D pc = item.GetComponent<PolygonCollider2D>();
            pc.enabled = false;
            //bc.enabled = false;

            show_shapes.Remove(item);
            
        }

        GMS.UpdateScenario(show_shapes);

    }

    public void activatechild(Transform c)
    {
        shape_script cs = c.GetComponent<shape_script>();
        cs.iscovered = false;
        cs.isactive = true;
        //BoxCollider2D bc = c.GetComponent<BoxCollider2D>();
        //bc.enabled = true;
        PolygonCollider2D pc = c.GetComponent<PolygonCollider2D>();
        pc.enabled = true;
        GameObject cgo = c.gameObject;
        show_shapes.Add(cgo);
        //show_shapes.Remove(p);
        GMS.UpdateScenario(show_shapes);



    }

    public void deleteparent(GameObject p)
    {
        show_shapes.Remove(p);
        GMS.UpdateScenario(show_shapes);
    }




}
