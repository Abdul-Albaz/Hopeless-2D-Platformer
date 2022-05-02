using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPic : MonoBehaviour
{
    public static int NumPart = 0;
    public GameObject collectDilog;

    private void Update()
    {
        if (NumPart == 4)
        {
            collectDilog.SetActive(true);

        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PicPart")
        {
            FindObjectOfType<DudioManger>().Play("hit");
            NumPart++;
        }

        
    }
}
