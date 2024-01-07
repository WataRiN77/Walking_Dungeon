using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadytoJump : MonoBehaviour
{
    public PlayerMovement player;
    [SerializeField] private TextMeshProUGUI textToUse;
    // Start is called before the first frame update
    void Start()
    {
        textToUse.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<PlayerMovement>().jumpActivated) textToUse.text = "Ready to climb!";
        else textToUse.text = "";
    }
}
