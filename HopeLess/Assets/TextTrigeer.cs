using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigeer : MonoBehaviour
{
    
    public GameObject text;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }
   
}
