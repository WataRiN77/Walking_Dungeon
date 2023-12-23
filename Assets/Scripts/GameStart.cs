using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    void Start()
    {
        int c = SceneManager.sceneCount;
        for(int i = 0; i < c; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if(scene.name != "SampleScene")
            {
                SceneManager.UnloadSceneAsync(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level_1");
            SceneManager.UnloadScene("SampleScene");
        }
    }
}
