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
    [SerializeField] PlayerTurnGameState _playerDefended;

    [SerializeField] Health _enemyHealth;
    [SerializeField] Health _playerHealth;

    [SerializeField] ParticleSystem _attackParticles1;
    [SerializeField] ParticleSystem _attackParticles2;

    [SerializeField] AudioClip _attack1SFX;
    [SerializeField] AudioClip _attack2SFX;
    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Tick()
    {
        base.Tick();
        if (_enemyHealth._enemyDied)
        {
            StateMachine.ChangeState<WinState>();
        }
        if (_playerHealth._playerDied)
        {
            StateMachine.ChangeState<LoseState>();
        }
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
        if (_playerDefended._defend)
        {
            _player.TakeDamage(damage / 3);
        }
        else
        {
            _player.TakeDamage(damage);
        }
        FeedBackAttack1();

    }

    private void EnemyAttack2(int damage)
    {
        Debug.Log("EnemyAttack2");
        if (_playerDefended._defend)
        {
            _player.TakeDamage(damage / 3);
        }
        else
        {
            _player.TakeDamage(damage);
        }
        FeedBackAttack2();
    }
    private void FeedBackAttack1()
    {
        //particles 
        if (_attackParticles1 != null)
        {
            _attackParticles1 = Instantiate(_attackParticles1, transform.position, Quaternion.identity);
        }
        //audio. TODO - consider Object Pooling for performance
        if (_attack1SFX != null)
        {
            AudioHelper.PlayClip2D(_attack1SFX, 1f);
        }
    }

    private void FeedBackAttack2()
    {
        //particles 
        if (_attackParticles2 != null)
        {
            _attackParticles2 = Instantiate(_attackParticles2, transform.position, Quaternion.identity);
        }
        //audio. TODO - consider Object Pooling for performance
        if (_attack2SFX != null)
        {
            AudioHelper.PlayClip2D(_attack2SFX, 1f);
        }
    }
}
