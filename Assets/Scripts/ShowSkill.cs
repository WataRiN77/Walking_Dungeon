using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowSkill : MonoBehaviour
{
   void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadSceneAsync("1-2", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("JumpSkill");
        }
    }

}
