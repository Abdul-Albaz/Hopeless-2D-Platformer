using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTrigeer : MonoBehaviour
{
    public GameObject dilog;
    public GameObject PinoSloution;
    public GameObject trigger, trigger2;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dilog.SetActive(true);
            trigger.SetActive(true);
            trigger2.SetActive(true);
            PinoSloution.SetActive(true);
            Invoke("destroyD", 1f);
        }
    }

    void destroyD()
    {

        PlayerController.IsMask = true;
        CancelInvoke();
        this.gameObject.SetActive(false);
        



    }
}
