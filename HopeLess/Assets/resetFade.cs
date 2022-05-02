using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetFade : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            
            anim.SetBool("FADE", false);

        }
    }
   
}
