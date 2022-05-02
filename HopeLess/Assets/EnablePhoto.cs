using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePhoto : MonoBehaviour
{
    public GameObject Photo,backgroundphoto, Light;
    public GameObject TrigerDilog;
    public PlayerController PlayerController;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.R))
            {
                Photo.SetActive(true);
                backgroundphoto.SetActive(true);
                Camera.main.orthographic = false;
                PlayerController.enabled = false;
                Light.SetActive(false);
                TrigerDilog.SetActive(true);

            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Photo.SetActive(false);
                backgroundphoto.SetActive(false);
                Camera.main.orthographic = true;
                PlayerController.enabled = true;
                Light.SetActive(true);

            }
        }

       
    }
}
