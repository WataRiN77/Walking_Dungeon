using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TextFading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textToUse;
    [SerializeField] private float timeMultiplier;
    RectTransform m_RectTransform;
    float m_XAxis;
    float m_YAxis;
    bool changeFlag = false;

    void TextFadeIn()
    {
        textToUse.color = new Color(textToUse.color.r, textToUse.color.g, textToUse.color.b, 0);
        while (textToUse.color.a < 1.0f)
        {
            textToUse.color = new Color(textToUse.color.r, textToUse.color.g, textToUse.color.b, textToUse.color.a + (Time.deltaTime * timeMultiplier));
        }
        //Debug.Log("TextFadeIn Done.");
    }

    void TextFadeOut()
    {
        textToUse.color = new Color(textToUse.color.r, textToUse.color.g, textToUse.color.b, 0);
        while (textToUse.color.a > 0.0f)
        {
            textToUse.color = new Color(textToUse.color.r, textToUse.color.g, textToUse.color.b, textToUse.color.a - (Time.deltaTime * timeMultiplier));
        }
        //Debug.Log("TextFadeOut Done.");
    }

    void EnterWorld()
    {
        //Debug.Log("Enter World Successfully.");
        SceneManager.LoadSceneAsync(FindObjectOfType<LevelManager>().nextlevel, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("LEVEL_1");
    }

    void Start()
    {
        //SceneManager.UnloadSceneAsync("SampleScene");
        
        Debug.Log(textToUse.text);
        Debug.Log(FindObjectOfType<LevelManager>().nextlevel);
        Invoke("TextFadeIn",  2.0f);
        Invoke("TextFadeOut", 2.0f);
        //Invoke("TextReset",   2.0f);
        Invoke("EnterWorld", 2.0f);
        
    }

    void Update()
    {
        textToUse.text = FindObjectOfType<LevelManager>().nextlevel;
    }

    void OnGUI()
    {
        if(changeFlag)
        {
            m_RectTransform = GetComponent<RectTransform>();
            m_RectTransform.transform.position = new Vector3(m_RectTransform.transform.position.x + (100f/216f), m_RectTransform.transform.position.y - (930f/216f), m_RectTransform.transform.position.z);
            changeFlag = false;
        }
    }


}
