using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyTurnGameState : GameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] float _pauseDuration = 1.5f;

    [SerializeField] int[] _enemyAttacks;

    [SerializeField] Health _player;
      

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exit...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy performs action");
        ChooseEnemyAttack();
        EnemyTurnEnded?.Invoke();
        //turn over. Go back to Player.
        StateMachine.ChangeState<PlayerTurnGameState>();
    }
    private void ChooseEnemyAttack()
    {
        int _attack = Random.Range(0, _enemyAttacks.Length);
        if(_attack == 0)
        {
            EnemyAttack1(10);
        }
        else if(_attack == 1)
        {
            EnemyAttack2(20);
        }
    }

    private void EnemyAttack1(int damage)
    {
        Debug.Log("EnemyAttack1");
        _player.TakeDamage(damage);

    }

    private void EnemyAttack2(int damage)
    {
        Debug.Log("EnemyAttack2");
        _player.TakeDamage(damage);
    }
}
