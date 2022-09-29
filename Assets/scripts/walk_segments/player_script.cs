using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    private Rigidbody2D rb2d;  
    private SpriteRenderer sprite;
    public float walkingspeed;
    public float maxspeed;

    private Animator anim;
    private Transform trans;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) )
        {
            anim.SetBool("isWalking",true);
        }
        else{
            anim.SetBool("isWalking",false);

        }
        
    }

    void Move()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2 (hori, 0);
        //rb2d.velocity = new Vector2(hori,0);
        rb2d.AddForce (movement * walkingspeed);
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxspeed);

        if (hori <0)
        {
            trans.eulerAngles = new Vector3(0, 0 ,0);
        }
        else if (hori > 0)
        {
            trans.eulerAngles = new Vector3(0, 180, 0);

        }

        //if (hori==0)
        //{
            //anim.SetBool("isWalking",false);
        //}
        //else{
            //anim.SetBool("isWalking",true);
        //}
    }


}
