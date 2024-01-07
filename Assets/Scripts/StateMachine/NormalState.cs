using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : PlayerState
{
    private MovementSM _sm;

    public NormalState(MovementSM stateMachine): base("NormalState", stateMachine)
    {
        _sm = (MovementSM)playerStateMachine;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();        
        if(Input.GetKeyUp("p"))
        {
            playerStateMachine.ChangeState(_sm.climbState);
            Debug.Log("Climb");
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        if(Input.GetKeyUp("w"))
        {
            _sm.player.position = new Vector3(_sm.player.position.x, _sm.player.position.y + 1.1f, _sm.player.position.z);
        }
        if(Input.GetKeyUp("a"))
        {
            _sm.player.position = new Vector3(_sm.player.position.x - 1.1f, _sm.player.position.y, _sm.player.position.z);
        }
        if(Input.GetKeyUp("s"))
        {
            _sm.player.position = new Vector3(_sm.player.position.x, _sm.player.position.y - 1.1f, _sm.player.position.z);
        }
        if(Input.GetKeyUp("d"))
        {
            _sm.player.position = new Vector3(_sm.player.position.x + 1.1f, _sm.player.position.y, _sm.player.position.z);
        }
    }

/*
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
*/

}
