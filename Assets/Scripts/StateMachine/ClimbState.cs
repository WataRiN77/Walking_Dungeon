using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : PlayerState
{
    public ClimbState(MovementSM stateMachine): base("ClimbState", stateMachine){}

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateLogic()
    {
        if(Input.GetKeyUp("p"))
        {
            playerStateMachine.ChangeState(((MovementSM)playerStateMachine).normalState);
            Debug.Log("Normal");
        }
    }

    public override void UpdatePhysics()
    {
        
    }
}
