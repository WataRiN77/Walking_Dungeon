using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine playerStateMachine;
    public string name;

    public PlayerState(string name, PlayerStateMachine playerStateMachine)
    {
        this.name = name;
        this.playerStateMachine = playerStateMachine;
    }

    public virtual void EnterState()
    {

    }

    public virtual void UpdateLogic()
    {

    }

    public virtual void UpdatePhysics()
    {

    }

    public virtual void ExitState()
    {

    }
}
