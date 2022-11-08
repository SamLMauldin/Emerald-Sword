using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : GameState
{
    [SerializeField] GameObject _loseText;
    public override void Enter()
    {
        base.Enter();
        _loseText.SetActive(true);
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
