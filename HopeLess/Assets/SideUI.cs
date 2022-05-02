using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SideUI : MonoBehaviour
{
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close()
    {
        UI.SetActive(false);
    }

    public void Open()
    {
        UI.SetActive(true);
    }

    public void Conttroal(int Level2)
    {
        SceneManager.LoadScene(Level2);
    }
}
