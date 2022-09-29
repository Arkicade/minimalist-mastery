using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class sfxmanager_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hoverpalette()
    {
        FindObjectOfType<AudioManager>().Play("collect");
    }

    public void Selectpalette()
    {
        FindObjectOfType<AudioManager>().Play("pop");

    }

}
