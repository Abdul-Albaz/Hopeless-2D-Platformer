using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundCat : MonoBehaviour
{
    public GameObject Collistion;
    public GameObject Collistion2;
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
            Invoke("soundon", 5f);
        }
    }

    void soundon()
    {
        FindObjectOfType<DudioManger>().Play("Crash");
        FindObjectOfType<DudioManger>().Play("Cat");
        Collistion.SetActive(false);
        Collistion2.SetActive(true);
    }
}
