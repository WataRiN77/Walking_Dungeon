using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine: MonoBehaviour
{
    public PlayerState currentPlayerState
    {
        get; set;
    }

    public void ChangeState(PlayerState newState)
    {
        currentPlayerState.ExitState();
        currentPlayerState = newState;
        //string content = currentPlayerState != null ? currentPlayerState.name : "null";
        //Debug.Log(content);
        currentPlayerState.EnterState();
    }
    void Start()
    {
        currentPlayerState = GetInitialState();
        if(currentPlayerState != null) currentPlayerState.EnterState();
    }

    void Update()
    {
        if(currentPlayerState != null) currentPlayerState.UpdateLogic();
    }

    void LateUpdate()
    {
        if(currentPlayerState != null) currentPlayerState.UpdatePhysics();
    }

    protected virtual PlayerState GetInitialState()
    {
        return null;
    }

    public void OnGUI()
    {
        string content = currentPlayerState != null ? currentPlayerState.name : "Null";
        GUILayout.Label($"<color='white'><size=40>{content}</size></color>");
    }

}
