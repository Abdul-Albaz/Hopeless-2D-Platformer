using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diloges : MonoBehaviour
{
    public GameObject diloges;
    public float TimeItTake;
   
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            diloges.SetActive(true);
          
            Invoke("destroyD", TimeItTake);
        }
    }

  void destroyD()
    {
        diloges.SetActive(false);
        
        CancelInvoke();
        gameObject.SetActive(false);
    }
}
