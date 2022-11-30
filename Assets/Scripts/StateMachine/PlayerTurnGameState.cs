using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnGameState : GameState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] Text _playerAttacksUI = null;

    [SerializeField] Health _enemy;
    [SerializeField] Health _player;

    [SerializeField] AudioClip _attackSFX;
    [SerializeField] AudioClip _defendSFX;
    [SerializeField] AudioClip _chargeSFX;

    private int _damage = 10;
    private bool _charged = false;
    private int _playerTurnCount = 0;

    public bool _defend = false;

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        _playerTurnTextUI.gameObject.SetActive(true);
        _playerAttacksUI.gameObject.SetActive(true);

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
        if (_defend)
        {
            _defend = false;
        }
        //hook into events 
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
    }

    public override void Tick()
    {
        base.Tick();
        if (Input.GetKeyDown(KeyCode.C))
        {
            BasicAttack();
        }
        if (Input.GetKeyDown(KeyCode.X)){
            Defend();
        }
        if (Input.GetKeyDown(KeyCode.Z)){
            ChargeAttack();
        }

        if (_enemy._enemyDied)
        {
            StateMachine.ChangeState<WinState>();
        }
        if (_player._playerDied)
        {
            StateMachine.ChangeState<LoseState>();
        }
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(true);
        _playerAttacksUI.gameObject.SetActive(true);
        //unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        Debug.Log("Player Turn: Exiting...");
    }

    void OnPressedConfirm()
    {
        StateMachine.ChangeState<EnemyTurnGameState>();
    }

    private void BasicAttack()
    {
        Debug.Log("EnemyAttacked");
        BasicAttackFeedback();
        _enemy.TakeDamage(_damage);
        if (_charged)
        {
            _damage = 10;
            _charged = false;
        }
        StateMachine.ChangeState<EnemyTurnGameState>();
    }

    private void Defend()
    {
        Debug.Log("Defend");
        DefendFeedback();
        _defend = true;
        StateMachine.ChangeState<EnemyTurnGameState>();
    }

    private void ChargeAttack()
    {
        if (!_charged)
        {
            Debug.Log("Charged");
            ChargeFeedback();
            _damage = _damage * 3;
            _charged = true;
            StateMachine.ChangeState<EnemyTurnGameState>();
        }
        else
        {
            Debug.Log("You are already charged");
        }
    }
    private void BasicAttackFeedback()
    {
        //audio. TODO - consider Object Pooling for performance
        if (_attackSFX != null)
        {
            AudioHelper.PlayClip2D(_attackSFX, 1f);
        }
    }

    private void DefendFeedback()
    {
        //audio. TODO - consider Object Pooling for performance
        if (_defendSFX != null)
        {
            AudioHelper.PlayClip2D(_defendSFX, 1f);
        }
    }

    private void ChargeFeedback()
    {
        //audio. TODO - consider Object Pooling for performance
        if (_chargeSFX != null)
        {
            AudioHelper.PlayClip2D(_chargeSFX, 1f);
        }
    }
}
