using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPic : MonoBehaviour
{
    public GameObject Pic,triggerLastDil;
    public GameObject plainblack;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" && CollectPic.NumPart==4)
        {
            if (Input.GetKey(KeyCode.R))
                {

            Pic.SetActive(true);
            triggerLastDil.SetActive(true);
            FindObjectOfType<DudioManger>().Play("laf");

                Invoke("nextlevel", 3F);
            
            }

        }
    }

    public void nextlevel()
    {
        plainblack.SetActive(true);
        Invoke("nextlevel2", 2F);
        
    }

    public void nextlevel2()
    {
        
        SceneManager.LoadScene(5);
        CancelInvoke();
    }
}
