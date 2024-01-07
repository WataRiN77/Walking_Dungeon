using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialize : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadSceneAsync("LevelManager", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("SampleScene",  LoadSceneMode.Additive);
    }
}
