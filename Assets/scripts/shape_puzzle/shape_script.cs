using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shape_script: MonoBehaviour,IDragHandler, IEndDragHandler
{
    public SpriteRenderer sprite;
    public Color o_color;
    private reset_script reset_go;
    //public BoxCollider2D bc2d;

    public PolygonCollider2D pc2d;


    public bool iscovered;
    public bool isactive;


    public int shape_color;
    public int shape_sides;


    //public List<Collider2D> results;

    public int colliderCount;

    private shapemanager_script SMS;

    private palette_manager_script palman;

    //public bool istouching;


    
    // Start is called before the first frame update

    void Awake()
    {
        palman = GameObject.FindGameObjectWithTag("palettemanager_tag").GetComponent<palette_manager_script>();

        switch (shape_color)
        {
            case 1:
                o_color = palman.col_1;
                break;
            case 2:
                o_color = palman.col_2;
                break;
            case 3:
                o_color = palman.col_3;
                break;
        }


        //bc2d = this.GetComponent<BoxCollider2D>();
        pc2d = this.GetComponent<PolygonCollider2D>();
        Collider2D[] colliders = new Collider2D[2];
        ContactFilter2D contactFilter = new ContactFilter2D();

        //colliderCount = bc2d.OverlapCollider(contactFilter, colliders);
        colliderCount = pc2d.OverlapCollider(contactFilter, colliders);

        if (iscovered)
        {   isactive = false;
        }
        else{
            isactive = true;
        }

  
    }
    void Start()
    {
        
        reset_go = GameObject.FindGameObjectWithTag("reset_tag").GetComponent<reset_script>();
        sprite = GetComponent<SpriteRenderer>();
        //o_color = sprite.color;
        sprite.color = o_color;

        SMS = GameObject.FindGameObjectWithTag("manager_tag").GetComponent<shapemanager_script>();
        
        //LayerMask mask = new LayerMask();
        //istouching = bc2d.IsTouchingLayers(LayerMask.GetMask("Default"));
 
    }

    // Update is called once per frame
    void Update()
    {
        //if (reset_go.isreset)
        //{
            //sprite.color = o_color;
            //bc2d.enabled = true;
            //isactive = true;
        //}
        if (iscovered)
        {
            disableb2d();
        }
        
    }

    void disableb2d()
    {
        pc2d.enabled = false;
        //bc2d.enabled = false;
        isactive = false;

    }

    void OnMouseOver()
    {
        //Debug.Log(this.transform.childCount);
        ///////// getting rid of the color
        if (Input.GetMouseButtonDown(0) && iscovered==false && isactive==true)
        {
            FindObjectOfType<AudioManager>().Play("pop3");
            //Debug.Log("object is invisible");
            sprite.color = new Color (1, 1, 1, 0); 
            disableb2d();
            SMS.deleteparent(this.gameObject);

            if(colliderCount > 0 && sprite.sortingOrder > 1)
            {
                for(int i=0; i < this.transform.childCount; i++)
                {
                    Transform child = this.transform.GetChild(i);
                    SMS.activatechild(child);

                }
                
            }



        }
            
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = Input.mousePosition;
        //
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.localPosition = Vector2.zero;
    }
}
