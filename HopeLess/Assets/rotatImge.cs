using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatImge : MonoBehaviour
{
    public float speed;

    public GameObject Background,Photo,Light;
    public PlayerController PlayerController;
    

    // Start is called before the first frame update
    void Start()
    {
        Background.SetActive(true);
        Camera.main.orthographic = false;
        PlayerController.enabled = false;
        Light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * speed );
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.down * speed );
        }

        if (Input.GetKey(KeyCode.Escape))
        {
           
            Camera.main.orthographic = true;
            PlayerController.enabled = true;
            Photo.SetActive(false);
            Background.SetActive(false);
            Light.SetActive(true);
        }

    }
}
