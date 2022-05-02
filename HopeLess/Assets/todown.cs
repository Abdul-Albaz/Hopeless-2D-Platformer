using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class todown : MonoBehaviour
{
    public GameObject player;
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
        player.transform.position = new Vector3(-46.48f, -24.26f, 0f);
      
    }
}
