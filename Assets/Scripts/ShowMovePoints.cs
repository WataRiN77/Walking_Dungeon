using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowMovePoints : MonoBehaviour
{
    public PlayerMovement player;
    [SerializeField] private TextMeshProUGUI textToUse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textToUse.text = "Available Moving Points:" + player.MovingPoint.ToString();
    }
}
