using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private int coins = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Movements p = collision.GetComponent<Movements>();
            p.coinsObtained += coins;
            Debug.Log("I found " + coins + " coins");
            Debug.Log("I have " + p.coinsObtained + " coins");
            gameObject.SetActive(false);
        }
        /*
                 if (collision.name == ("Knight"))
                {
                    Debug.Log("I found " + coins + " coins");
                    gameObject.SetActive(false);
                } 
        */
    }
}
