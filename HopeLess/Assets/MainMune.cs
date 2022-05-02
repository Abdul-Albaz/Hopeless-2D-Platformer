using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMune : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyicOpration());
    }

    // Update is called once per frame

    IEnumerator LoadAsyicOpration()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(4);

        while (gameLevel.progress < 1)
        {
            _progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
        
    }
  
}
