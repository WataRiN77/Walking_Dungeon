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
    }

    void TextFadeOut()
    {
        textToUse.color = new Color(textToUse.color.r, textToUse.color.g, textToUse.color.b, 0);
        while (textToUse.color.a > 0.0f)
        {
            textToUse.color = new Color(textToUse.color.r, textToUse.color.g, textToUse.color.b, textToUse.color.a - (Time.deltaTime * timeMultiplier));
        }
    }
    
    void TextReset()
    {
        textToUse.text = "Use WASD to move around.\nEach step costs you 1 Moving Point.";
        textToUse.color = new Color(35, 35, 35, 1);
        textToUse.fontSize = 96;
        textToUse.alignment = TextAlignmentOptions.Left;
        changeFlag = true;
        
    }

    void EnterWorld()
    {
        SceneManager.LoadSceneAsync(2);
    }

    void Awake()
    {
        Invoke("TextFadeIn",  2.0f);
        Invoke("TextFadeOut", 2.0f);
        //Invoke("TextReset",   2.0f);
        Invoke("EnterWorld", 2.0f);

        
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
