using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colect : MonoBehaviour
{
    public static int Pic;

    public static bool istake =false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Pic += 1;
            this.gameObject.SetActive(false);
            istake = true;
        }
    }


}
