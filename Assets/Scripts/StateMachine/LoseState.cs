using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : GameState
{
    [SerializeField] GameObject _loseText;
    [SerializeField] GameObject _losePanel;
    [SerializeField] AudioClip _loseSound;
    public override void Enter()
    {
        base.Enter();
        _loseText.SetActive(true);
        _losePanel.SetActive(true);
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        AudioFeedback();
    }

    public override void Tick()
    {
        base.Tick();
        if (Input.GetKeyDown(KeyCode.Escape))
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
        if (_loseSound != null)
        {
            AudioHelper.PlayClip2D(_loseSound, 1f);
        }
    }
}
