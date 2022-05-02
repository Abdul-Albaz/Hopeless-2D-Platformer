using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePino : MonoBehaviour
{
    [SerializeField]
    GameObject codePanel, closedSafe, openedSafe;

    public PinoMechanic script;
    public PlayerController PlayerController;

    public static bool isOut =false;

   
    void Start()
    {
        script = GetComponent<PinoMechanic>();
       
        codePanel.SetActive(false);
        closedSafe.SetActive(true);
        openedSafe.SetActive(false);
        isOut = true;
    }

    // Update is called once per frame
    void Update()
    {

        
        

            if (PinoMechanic.SafeOpened)
            {

                codePanel.SetActive(false);
                PlayerController.enabled = true;

            }


        
        if (Input.GetKey(KeyCode.Escape))
        {
            PlayerController.enabled = true;
            codePanel.SetActive(false);
            script.enabled = false;
        }

        if (PinoMechanic.SafeOpened )
        {

            Invoke("dsiable", 1f);
        }
       

    }

   void dsiable()
    {
        codePanel.SetActive(false);
        closedSafe.SetActive(false);
        if( colect.istake == false)
        {

        openedSafe.SetActive(true);
        }
        if (colect.istake == true)
        {

            openedSafe.SetActive(false);
        }

        script.enabled = false;
    }

void OnTriggerStay2D(Collider2D collision)
    {
      
            


        if (collision.gameObject.tag == "Player" && !PinoMechanic.SafeOpened)
        {
            
            if (Input.GetKey(KeyCode.R))
            {

                codePanel.SetActive(true);
                isOut = false;
                Invoke("Pino", 1f);
                PlayerController.enabled = false;

                }

           
        }




    }

    void OnTriggerExit2D(Collider2D col)
    {
        
            codePanel.SetActive(false);
            script.enabled = false;
            isOut = true;

    }



    void Pino()
    {
        script.enabled = true;
    }
}
