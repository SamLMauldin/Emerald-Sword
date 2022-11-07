using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnGameState : GameState
{
    [SerializeField] Text _playerTurnTextUI = null;

    [SerializeField] Health _enemy;

    private int _damage = 10;
    private bool _charged = false;
    private int _playerTurnCount = 0;

    public bool _defend = false;

    public override void Enter()
    {
        Debug.Log("Player Turn: ...Entering");
        _playerTurnTextUI.gameObject.SetActive(true);

        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
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
    }

    public override void Exit()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
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
        _defend = true;
        StateMachine.ChangeState<EnemyTurnGameState>();
    }

    private void ChargeAttack()
    {
        if (!_charged)
        {
            Debug.Log("Charged");
            _damage = _damage * 2;
            _charged = true;
            StateMachine.ChangeState<EnemyTurnGameState>();
        }
        else
        {
            Debug.Log("You are already charged");
        }
    }
}
