using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick(int Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Conttroal(int Level2)
    {
        SceneManager.LoadScene(Level2);
    }
}
