using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameracontroller : MonoBehaviour
{
    public GameObject virualCamera;
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            virualCamera.SetActive(true);
            anim.SetBool("FADE",true);
          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virualCamera.SetActive(false);
            
        }
    }

   
}
