using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    void Awake()
    {
        //SceneManager.LoadSceneAsync("LevelManager", LoadSceneMode.Additive);
        FindObjectOfType<LevelManager>().LevelCount = 1;
        FindObjectOfType<LevelManager>().jumpFlag   = false;
        FindObjectOfType<LevelManager>().jumpContinueFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadSceneAsync("Level_1", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("SampleScene");
        }
    }
}