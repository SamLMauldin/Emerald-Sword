using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGameState : GameState
{
    bool _activated = false;
    public override void Enter()
    {
        Debug.Log("Setup: ...Entering");
        Debug.Log("You can now walk around");
        _activated = false;
    }

    public override void Tick()
    {
        if(_activated == false)
        {
            _activated = true;
            StateMachine.ChangeState<PlayerTurnGameState>();
        }
    }
    public override void Exit()
    {
        _activated = false;
        Debug.Log("Setup: Exiting...");
    }
}
