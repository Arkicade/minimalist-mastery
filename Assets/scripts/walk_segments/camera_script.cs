using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player_tag").GetComponent<Transform>(); 
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3 (player.position.x , player.position.y+2.5f, transform.position.z); // Camera follows the player with specified offset position
        
    }
}
