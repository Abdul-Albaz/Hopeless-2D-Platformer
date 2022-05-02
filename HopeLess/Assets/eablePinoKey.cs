using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eablePinoKey : MonoBehaviour
{
    public GameObject PinoSheet;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PinoSheet.SetActive(true);
            Invoke("destroyD", 1f);

        }
    }

    

    

    void destroyD()
{

    PlayerController.IsMask = true;
    CancelInvoke();
    Destroy(gameObject);



}
}
