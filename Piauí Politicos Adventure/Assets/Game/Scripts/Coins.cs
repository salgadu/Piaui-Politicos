using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coins : MonoBehaviour
{
    
   

    // Start is called before the first frame update
   
   

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider) 
    {   
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().ReceiveCoin(100);
            Destroy(gameObject);
         }
        
    }
}
