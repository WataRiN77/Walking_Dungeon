using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public int MovingPoint = 10;
    float max_x =  7.6f;
    float min_x =  0.1f;
    float max_y = -0.1f;
    float min_y = -3.2f;
    public bool LoseFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("w") && player.position.y < max_y)
        {
            float y = player.position.y;
            float step = 0.0025f/216f;
            
            while(player.position.y <= y + 1.1)
            {
                player.position = new Vector3(player.position.x, player.position.y + step, player.position.z);
            }
            MovingPoint -=1;

        }
        if(Input.GetKeyUp("a") && player.position.x > min_x)
        {
            float x = player.position.x;
            float step = 0.0025f/216f;
            
            while(player.position.x >= x - 1.1)
            {
                player.position = new Vector3(player.position.x - step, player.position.y, player.position.z);
            }
            MovingPoint -=1;

        }
        if(Input.GetKeyUp("s") && player.position.y > min_y)
        {
            float y = player.position.y;
            float step = 0.0025f/216f;
            
            while(player.position.y >= y - 1.1)
            {
                player.position = new Vector3(player.position.x, player.position.y - step, player.position.z);
            }
            MovingPoint -=1;

        }
        if(Input.GetKeyUp("d") && player.position.x < max_x)
        {
            float x = player.position.x;
            float step = 0.0025f/216f;
            
            while(player.position.x <= x + 1.1)
            {
                player.position = new Vector3(player.position.x + step, player.position.y, player.position.z);
            }
            MovingPoint -=1;

        }
        if(MovingPoint  == 0 && (player.position.x < max_x || player.position.y > min_y)) EndGame();
    }

    void EndGame()
    {
        SceneManager.LoadSceneAsync(3);
        SceneManager.UnloadSceneAsync(2);
    }
}
