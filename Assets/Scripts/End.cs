using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("END");
        }
        if(Input.GetKeyUp(KeyCode.Escape))
        {
#if UNITY_EDITOR
UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
