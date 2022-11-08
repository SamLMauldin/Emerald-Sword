using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : GameState
{
    [SerializeField] GameObject _winText;
    public override void Enter()
    {
        base.Enter();
        _winText.SetActive(true);
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Exit()
    {
        base.Exit();
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
    }

    void OnPressedConfirm()
    {
        StateMachine.ChangeState<SetupGameState>();
    }
}
