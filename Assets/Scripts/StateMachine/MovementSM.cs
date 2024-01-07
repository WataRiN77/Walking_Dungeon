using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : PlayerStateMachine
{
    [HideInInspector]
    public NormalState normalState;

    [HideInInspector]
    public ClimbState  climbState;

    public Transform player;

    private void Awake()
    {
        normalState = new NormalState(this);
        climbState  = new ClimbState (this);
    }

    protected override PlayerState GetInitialState()
    {
        return normalState;
    }

}
