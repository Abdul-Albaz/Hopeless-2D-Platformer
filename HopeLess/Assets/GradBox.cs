using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradBox : MonoBehaviour
{
    [SerializeField]
    private Transform grabDetect;
    [SerializeField]
    private Transform boxHandler;
    public Animator Anim;
    //public GameObject uib;

    public float rayDist;

   
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position,  transform.right, rayDist);


        if (grabCheck.collider != null && grabCheck.collider.tag == "Book")
        {

            if (Input.GetKey(KeyCode.Q))
            {
                grabCheck.collider.gameObject.transform.parent = boxHandler;
                grabCheck.collider.gameObject.transform.position = boxHandler.position;
                grabCheck.collider.gameObject.transform.GetComponent<Rigidbody2D>().isKinematic = true;
                PlayerController.jumpForce = 0f;
                PlayerController.canFlip = false;

                PlayerController.movementSpeed = 1.2f;
               




            }

            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                PlayerController.jumpForce = 20;
                PlayerController.canFlip = true;
               
                grabCheck.collider.gameObject.transform.parent = null;
                PlayerController.movementSpeed = 7f;
                Anim.SetBool("IsPushing", false);
                Anim.SetBool("isWalking", true);
                
            }


        }








    }
}
