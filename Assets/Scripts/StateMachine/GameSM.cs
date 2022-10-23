using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSM : StateMachine
{
    void Start()
    {
        ChangeState<SetupGameState>();
    }
}
