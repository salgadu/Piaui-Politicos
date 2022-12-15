using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePenSound : MonoBehaviour
{   
    private BoxCollider2D col ;
    private AudioSource sound;

    // Start is called before the first frame update
    void Awake()
    {
        col= GetComponent<BoxCollider2D>();
        sound=GetComponent <AudioSource>();
    
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            sound.volume = 0.16f;
            sound.Play();
         }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            InvokeRepeating("SoundDown", 0f, 0.3f);
                 


        }

    }
    void SoundDown()
    {
        sound.volume -= 0.02f;

    }


}
