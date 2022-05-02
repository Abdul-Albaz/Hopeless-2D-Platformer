using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinoKey : MonoBehaviour
{
    private int key=0;
    private bool firstKey =false;
    private bool scoundKey = false;
    private bool thirdKey = false;
    private bool fourthKey = false;

    public AudioClip audio1, audio2, audio3, audio4;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Key();
    }


    void Key()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            Debug.Log("Y");
            firstKey = true;
            audio.PlayOneShot(audio1);



            if (firstKey == true && thirdKey == false && scoundKey == false && fourthKey == false)
            {
                key = 1;
                Debug.Log("firstKeyTRUE");
            }

            else if(key==0)
            {
           

              firstKey =false;
              scoundKey = false;
              thirdKey = false;
              fourthKey = false;

            }

        }


        if (Input.GetKey(KeyCode.U))
        {
            Debug.Log("U");
            scoundKey = true;
            audio.PlayOneShot(audio2);


            if (firstKey == false && thirdKey == false && scoundKey == true && fourthKey == false && key==0)
            {
                key = 0;
                Debug.Log("False");
            }
            if (firstKey == true && thirdKey == false && scoundKey == true && fourthKey == false && key == 0)
            {
                key = 0;
                Debug.Log("False");

            }
            if (firstKey == false && thirdKey == true && scoundKey == true && fourthKey == false && key == 0)
            {
                key = 0;
                Debug.Log("False");
            }
            if (firstKey == false && thirdKey == false && scoundKey == true && fourthKey == true && key == 0)
            {
                key = 0;
                Debug.Log("False");
            }

            if (firstKey == true && thirdKey == false && scoundKey == true && fourthKey == false && key==1)
            {
                key = 2;
                Debug.Log("scoundKeyTRUE");
            }

            else if(key == 0)
            {
                key = 0;
                firstKey = false;
                scoundKey = false;
                thirdKey = false;
                fourthKey = false;
            }
        }


        if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("I");
            thirdKey = true;
            audio.PlayOneShot(audio3);

            if (firstKey == false && thirdKey == true && scoundKey == false && fourthKey == false)
            {
                key = 0;
                Debug.Log("False");
            }
            if (firstKey == true && thirdKey == true && scoundKey == false && fourthKey == false)
            {
                key = 0;
                Debug.Log("False");
            }
            if (firstKey == false && thirdKey == true && scoundKey == true && fourthKey == false)
            {
                key = 0;
                Debug.Log("False");
            }
            if (firstKey == false && thirdKey == true && scoundKey == false && fourthKey == true)
            {
                key = 0;
                Debug.Log("False");
            }


            if (firstKey == true && thirdKey == true && scoundKey == true && fourthKey == false && key == 2)
            {
                key = 3;
                Debug.Log("thirdKeyTRUE");
            }
            else if (key == 0)
            {
                key = 0;
                firstKey = false;
                scoundKey = false;
                thirdKey = false;
                fourthKey = false;
            }
        }


        if (Input.GetKey(KeyCode.O))
        {
            Debug.Log("O");
            fourthKey = true;
            audio.PlayOneShot(audio4);

            if (firstKey == false && thirdKey == false && scoundKey == false && fourthKey == true)
            {
                key = 0;
                Debug.Log("False");
            }
            if (firstKey == false && thirdKey == false && scoundKey == true && fourthKey == true)
            {
                key = 0;
                Debug.Log("False");
            }
            if (firstKey == false && thirdKey == true && scoundKey == false && fourthKey == true)
            {
                key = 0;
                Debug.Log("False");
            }
            if (firstKey == true && thirdKey == false && scoundKey == false && fourthKey == true)
            {
                key = 0;
                Debug.Log("False");
            }


            if (firstKey == true && thirdKey == true && scoundKey == true && fourthKey == true && key == 3)
            {
                key = 4;
                Debug.Log("fourthKeyTRUE");
            }

            else if (key == 0)
            {
                key = 0;
                firstKey = false;
                scoundKey = false;
                thirdKey = false;
                fourthKey = false;
            }
        }




        if (key== 4)
        {
            Debug.Log("Open");
        }

       

    }
}
