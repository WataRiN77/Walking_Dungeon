using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    //public Tilemap player_color;

    /*float max_x =  7.6f;
    float min_x =  0.1f;
    float max_y = -0.1f;
    float min_y = -3.2f;*/
    public bool LoseFlag = false;
    public int X_Coordinate;
    public int Y_Coordinate;
    public int MovingPoint;
    public bool endFlag = false;
    public bool jumpActivated = false;

    bool checkW;
    bool checkA;
    bool checkS;
    bool checkD;
    bool WallW;
    bool WallA;
    bool WallS;
    bool WallD;
    bool backFlag;
    bool jumpContinueFlag;
    
    private static int  times = 1;
 
    //public LevelManager LevelManager;

    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.UnloadSceneAsync("LEVEL_1");
        //int[,] wall = FindObjectOfType<LevelManager>().wall;
        //for(int i = 0; i < wall.GetLength(0); i ++) for(int j = 0; j < wall.GetLength(1); j ++) Debug.Log(wall[i, j]);
        endFlag = false;
        backFlag = FindObjectOfType<LevelManager>().backFlag;
        jumpContinueFlag = FindObjectOfType<LevelManager>().jumpContinueFlag;

        if(!backFlag)
        {
            X_Coordinate = FindObjectOfType<LevelManager>().start[0];  
            Y_Coordinate = FindObjectOfType<LevelManager>().start[1];
        }
        else
        {
            if(jumpContinueFlag && times == 1)
            {
                X_Coordinate = 7;  
                Y_Coordinate = 3;
                jumpContinueFlag = false;
                times += 1;
            }
            else
            {
                X_Coordinate = FindObjectOfType<LevelManager>().end[0];  
                Y_Coordinate = FindObjectOfType<LevelManager>().end[1];
            }
            
        }
        Debug.Log(X_Coordinate);
        Debug.Log(Y_Coordinate);

        player.position = new Vector3(X_Coordinate * 1.1f, (Y_Coordinate -3) * 1.1f, player.position.z);

        MovingPoint = FindObjectOfType<LevelManager>().MovingPoint;
        if(FindObjectOfType<LevelManager>().LevelCount == 1) MovingPoint = 10;
                   
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Obstacle Cell or Edge of the map.
        RefreshState();
        CheckState();
        
        if(Input.GetKeyUp("w") && checkW && WallW)
        {
            float y = player.position.y;
            float step = 0.0025f/216f;
            
            while(player.position.y <= y + 1.1)
            {
                player.position = new Vector3(player.position.x, player.position.y + step, player.position.z);
            }
            MovingPoint  -= 1;
            Y_Coordinate += 1;

            if(backFlag) backFlag = false;

        }
        if(Input.GetKeyUp("a") && checkA && WallA)
        {
            float x = player.position.x;
            float step = 0.0025f/216f;
            
            while(player.position.x >= x - 1.1)
            {
                player.position = new Vector3(player.position.x - step, player.position.y, player.position.z);
            }
            MovingPoint  -= 1;
            X_Coordinate -= 1;

            if(backFlag) backFlag = false;

        }
        if(Input.GetKeyUp("s") && checkS && WallS)
        {
            float y = player.position.y;
            float step = 0.0025f/216f;
            
            while(player.position.y >= y - 1.1)
            {
                player.position = new Vector3(player.position.x, player.position.y - step, player.position.z);
            }
            MovingPoint  -= 1;
            Y_Coordinate -= 1;

            if(backFlag) backFlag = false;

        }
        if(Input.GetKeyUp("d") && checkD && WallD)
        {
            float x = player.position.x;
            float step = 0.0025f/216f;
            
            while(player.position.x <= x + 1.1)
            {
                player.position = new Vector3(player.position.x + step, player.position.y, player.position.z);
            }
            MovingPoint  -= 1;
            X_Coordinate += 1;

            if(backFlag) backFlag = false;

        }

        // CLIMB
        if((Input.GetKeyUp(KeyCode.Space) && FindObjectOfType<LevelManager>().jumpFlag /* Already get ability */) || jumpActivated)
        {
            if((!WallW) && (!WallA) && (!WallS) && (!WallD))
            {
                Debug.Log("You are not currently by a WALL CELL.");
            }
            else
            {
                jumpActivated = true;
                
                if(Input.GetKeyUp("w"))
                {
                    if(!WallW) Jump('w');
                    else       jumpActivated = false;
                }

                if(Input.GetKeyUp("a"))
                {
                    if(!WallA) Jump('a');
                    else       jumpActivated = false;
                }
                
                if(Input.GetKeyUp("s"))
                {
                    if(!WallS) Jump('s');
                    else       jumpActivated = false;
                }

                if(Input.GetKeyUp("d"))
                {
                    if(!WallD) Jump('d');
                    else       jumpActivated = false;
                }

            }
        }

        // Lose when MovingPoint reaches ZERO and not in END cell.
        if(MovingPoint <= 0 && (X_Coordinate != FindObjectOfType<LevelManager>().end[0] || Y_Coordinate != FindObjectOfType<LevelManager>().end[1]))
        {
            if(!endFlag)
            {
                endFlag = true;
                EndGame();
            }
        }      

        // Go to next level.
        if(MovingPoint >= 0 && (X_Coordinate == FindObjectOfType<LevelManager>().end[0] && Y_Coordinate == FindObjectOfType<LevelManager>().end[1]))
        {
            if(!backFlag)
            {
                if(!endFlag)
                {
                    endFlag = true;
                    FindObjectOfType<LevelManager>().nextLevel();
                }
            }
        }

        // Go to previous level.
        // 1-1 does not have a PREVIOUS LEVEL, apparently.
        if(Input.GetKeyUp(KeyCode.Backspace))
        {
            MovingPoint -= 1;
            if(X_Coordinate == FindObjectOfType<LevelManager>().start[0] &&
               Y_Coordinate == FindObjectOfType<LevelManager>().start[1] && 
               FindObjectOfType<LevelManager>().LevelCount != 1)            FindObjectOfType<LevelManager>().prevLevel();
        }

        // Check if SKILL CELL.
        if( X_Coordinate == FindObjectOfType<LevelManager>().skill[0] &&
            Y_Coordinate == FindObjectOfType<LevelManager>().skill[1] &&
            FindObjectOfType<LevelManager>().LevelCount == 2)               FindObjectOfType<LevelManager>().JumpSkillUnlock();
    }

    bool CheckWall(char direction, int distance)
    {
        int[] up    = new int[] {X_Coordinate, Y_Coordinate + distance}; // W
        int[] left  = new int[] {X_Coordinate - distance, Y_Coordinate}; // A
        int[] down  = new int[] {X_Coordinate, Y_Coordinate - distance}; // S
        int[] right = new int[] {X_Coordinate + distance, Y_Coordinate}; // D

        int[] target = new int[2];
        int[,] wall = FindObjectOfType<LevelManager>().wall;

        switch(direction)
        {
            case 'w': target = up;    break;
            case 'a': target = left;  break;
            case 's': target = down;  break;
            case 'd': target = right; break;
        }

        for(int i = 0; i < wall.GetLength(0); i ++)
        {
            if(target[0] == wall[i,0] && target[1] == wall[i,1]) return false;
        }

        return true;
    }

    void CheckState()
    {
        int[] up    = new int[] {X_Coordinate, Y_Coordinate + 1}; // W
        int[] left  = new int[] {X_Coordinate - 1, Y_Coordinate}; // A
        int[] down  = new int[] {X_Coordinate, Y_Coordinate - 1}; // S
        int[] right = new int[] {X_Coordinate + 1, Y_Coordinate}; // D

        if(   up[1] > 3.1f) checkW = false; // Check EDGE
        //else checkW = true;

        if( left[0] < -0.1f) checkA = false;
        //else checkA = true;

        if( down[1] < -0.1f) checkS = false;
        //else checkS = true;

        if(right[0] > 7.1f) checkD = false;
        //else checkD = true;

        if(FindObjectOfType<LevelManager>().LevelCount != 1) // No walls in 1-1!
        {
            if(!CheckWall('w', 1)) WallW = false; // Check Wall

            if(!CheckWall('a', 1)) WallA = false;

            if(!CheckWall('s', 1)) WallS = false;

            if(!CheckWall('d', 1)) WallD = false;
        }     
    }

    void RefreshState()
    {
        checkW = true;
        checkA = true;
        checkS = true;
        checkD = true;
        WallW  = true;
        WallA  = true;
        WallS  = true;
        WallD  = true;
    }

    // Skill: Climb
    void Jump(char direction)
    {
        jumpActivated = false;

        float step = 0.0025f/216f;
        float x = player.position.x;
        float y = player.position.y;

        switch(direction)
        {
            case 'w':
                if(CheckWall('w', 2))
                {
                    while(player.position.y <= y + 2.2f)
                    {
                        player.position = new Vector3(player.position.x, player.position.y + step, player.position.z);
                    }

                    Y_Coordinate += 2;
                    MovingPoint  -= 1;
                }
                break;
                
            case 'a':
                if(CheckWall('a', 2))
                {
                    while(player.position.x >= x - 2.2f)
                    {    
                        player.position = new Vector3(player.position.x - step, player.position.y, player.position.z);
                    }
                    X_Coordinate -= 2;
                    MovingPoint  -= 1;
                }
                break;

            case 's':
                if(CheckWall('s', 2))
                {
                    while(player.position.y >= y - 2.2f)
                    {
                        player.position = new Vector3(player.position.x, player.position.y - step, player.position.z);
                    }
                    Y_Coordinate -= 2;
                    MovingPoint  -= 1;
                }
                break;

            case 'd':
                if(CheckWall('d', 2))
                {
                    while(player.position.x <= x + 2.2f)
                    {    
                        player.position = new Vector3(player.position.x + step, player.position.y, player.position.z);
                    }
                    X_Coordinate += 2;
                    MovingPoint  -= 1;
                }
                break;
        }
    }

    // Skill: Rush
    void Rush()
    {

    }



    void EndGame()
    {
        SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(FindObjectOfType<LevelManager>().nextlevel);
    }
}
