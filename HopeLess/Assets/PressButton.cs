using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    public Animator anim,anim2;
    public GameObject box,button;
    private Collider2D Collider2D;
    public GameObject collider, collider2;

    private void Start()
    {
        Collider2D = button.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Press", true);
            anim2.SetBool("IsBox", true);
            
        }

        if(box.transform.position.x <= 2.611 && collision.gameObject.tag == "Player")
        {
            anim2.SetBool("isOping", true);
            collider.SetActive(true);
            collider2.SetActive(false);
            Collider2D.enabled = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("Press", false);
        anim2.SetBool("IsBox", false);
    }
}
