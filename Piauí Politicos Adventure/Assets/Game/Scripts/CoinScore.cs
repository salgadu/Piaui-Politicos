using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    public Text scoreTxt;
    private int score;
    
    // Start is called before the first frame update

    private void Start()
    {
        score = 0;
    }
    private void Update()
    {
        scoreTxt.text = score.ToString();
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin")==true)
        {
            score = score + 100;
            
        }

    }
}
