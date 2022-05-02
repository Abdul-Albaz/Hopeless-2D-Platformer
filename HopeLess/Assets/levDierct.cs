using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levDierct : MonoBehaviour
{

    public float timer;


    // Start is called before the first frame update
    private IEnumerator Start()
    {
    yield return new WaitForSeconds(timer);

        SceneManager.LoadScene(3);
    }

    // Update is called once per frame
  
}
