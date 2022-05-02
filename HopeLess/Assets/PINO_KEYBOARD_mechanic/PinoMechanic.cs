using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinoMechanic : MonoBehaviour
{
    public string sequnce;
    public string pianoInput="";
    public AudioSource source;
    public AudioClip[] clips;

    public Text codeText;
    public Text codeText2;
    string codeTextValue = "";

    public static bool SafeOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        
            pianoInput = "";
            codeTextValue = "";
            codeText2.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if (pianoInput.Length < sequnce.Length)
        {
            codeText.text = codeTextValue;
            string keypressed = Input.inputString.ToLower();
            pianoInput += keypressed;

            if (pianoInput.Length <= 9)
            {
                codeTextValue += keypressed;
            }

            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name == keypressed + "_sound")
                {
                    source.PlayOneShot(clips[i]);

                }
            }

        }


        if (pianoInput == sequnce)
        {
            Debug.Log("Right sequnce...The door is opened");

            codeText2.text = "Good Job";
            codeText2.color = Color.green;
            SafeOpened = true;

            Invoke("chack", 1.0f);
        }

        if (pianoInput != sequnce && pianoInput.Length == 9 )
        {

            codeText2.text = "Wrong";
            codeText2.color = Color.red;

            Invoke("chack", 1.0f);

        }

    }








    void chack()
    {

        if (pianoInput.Length == 9)
        {

            pianoInput = "";
            codeTextValue = "";
            codeText2.text = "";
        }
        CancelInvoke();
    }
}
