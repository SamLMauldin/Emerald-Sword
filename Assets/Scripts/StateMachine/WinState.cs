using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : GameState
{
    [SerializeField] GameObject _winText;
    [SerializeField] GameObject _winPanel;
    public override void Enter()
    {
        base.Enter();
        _winText.SetActive(true);
        _winPanel.SetActive(true);
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Tick()
    {
        base.Tick();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Exit the Game");
            Application.Quit();
        }
    }

    public override void Exit()
    {
        ReloadLevel();
        base.Exit();
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
    }

    void OnPressedConfirm()
    {
        StateMachine.ChangeState<SetupGameState>();
    }

    void ReloadLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
}
