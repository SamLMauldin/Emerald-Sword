using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : GameState
{
    [SerializeField] GameObject _winText;
    [SerializeField] GameObject _winPanel;
    [SerializeField] AudioClip _winSound;
    public override void Enter()
    {
        base.Enter();
        _winText.SetActive(true);
        _winPanel.SetActive(true);
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        AudioFeedback();
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

    private void AudioFeedback()
    {
        //audio. TODO - consider Object Pooling for performance
        if (_winSound != null)
        {
            AudioHelper.PlayClip2D(_winSound, 1f);
        }
    }
}
