using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int LevelCount;
    public int maxLevel;
    public string nextlevel;
    public string prevlevel;
    public MapInfo MapInfo;
    public int MovingPoint;
    public bool backFlag = false;
    public bool jumpFlag = false;
    public bool jumpContinueFlag = false;
    //public bool jumpActivated = false;

    public int[]   start  =   new int[2];
    public int[]   end    =   new int[2];
    //public int[] normal =   new int[32]; No Need!
    public int[,]  wall   =   new int[2,16];
    public int[]   skill  =   new int[2];


    void Start()
    {
        LevelCount = 1;
        maxLevel = 1;
    }

    void Update() // Refresh Map Info Here.
    {
        nextlevel = "1-" +  LevelCount     .ToString();
        prevlevel = "1-" + (LevelCount - 1).ToString();
        switch(LevelCount)
        {
            case 1:
                start = new int[] {0, 3};
                end   = new int[] {7, 0};
                break;

            case 2:
                start = new int[] {0, 3};
                end   = new int[] {7, 0};
                wall  = new int[,] {{1, 1}, {1, 2}, {1, 3},
                                    {3, 0}, {3, 1}, {3, 2},
                                    {5, 1}, {5, 2}, {5, 3}};
                skill = new int[] {7, 3};
                break;
            
            case 3:
                start = new int[] {0, 3};
                end   = new int[] {7, 0};
                wall  = new int[,] {{2, 0}, {2, 1}, {2, 2}, {2, 3},
                                    {5, 0}, {5, 1}, {5, 2}, {5, 3},};
                                    
                break;

        }
        if(LevelCount > maxLevel) maxLevel = LevelCount;

    }

    public void nextLevel()
    {
        //Debug.Log("Next Level");
        LevelCount += 1;
        prevlevel = "1-" + (LevelCount - 1).ToString();
        SceneManager.LoadSceneAsync("LEVEL_1", LoadSceneMode.Additive);
        Debug.Log(prevlevel);
        SceneManager.UnloadSceneAsync(prevlevel);
        switch(LevelCount)
        {
            case 1: MovingPoint = 10; break;
            case 2: MovingPoint = 16; break;
            case 3: MovingPoint =  8; break;
        }
        backFlag = false;

    }

    public void prevLevel()
    {
        MovingPoint = FindObjectOfType<PlayerMovement>().MovingPoint;
        SceneManager.UnloadSceneAsync(nextlevel);
        LevelCount -= 1;
        nextlevel = "1-" + LevelCount.ToString();
        SceneManager.LoadSceneAsync("LEVEL_1", LoadSceneMode.Additive);
        Debug.Log(prevlevel);
        //SceneManager.UnloadSceneAsync(nextlevel);
        backFlag = true;
    }

    public void JumpSkillUnlock()
    {
        if(!jumpFlag)
        {
            MovingPoint = FindObjectOfType<PlayerMovement>().MovingPoint;
            jumpFlag = true;
            jumpContinueFlag = true;
            SceneManager.LoadSceneAsync("JumpSkill", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("1-2");
            //jumpContinueFlag = false;
        }
        
    }

}
