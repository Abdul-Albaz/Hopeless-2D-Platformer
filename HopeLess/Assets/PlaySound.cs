using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public string SoundName;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        FindObjectOfType<DudioManger>().Play(SoundName);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
