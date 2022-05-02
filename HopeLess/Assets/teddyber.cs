using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teddyber : MonoBehaviour
{
    public Animator anim;
    public string Bool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool(Bool, true);
        }
    }
}
