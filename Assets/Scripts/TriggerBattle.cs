using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerBattle : MonoBehaviour
{
    [SerializeField] GameObject _playerHealthBar;
    [SerializeField] GameObject _enemyHealthBar;
    [SerializeField] private Animator _playerHBAnimator = null;
    [SerializeField] private Animator _enemyHBAnimator = null;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("StateController").GetComponent<PlayerMovement>()._triggerBattle = true;
        _playerHealthBar.SetActive(true);
        _enemyHealthBar.SetActive(true);
        _playerHBAnimator.Play("PlayerHealthBarIntro", 0, 0.0f);
        _enemyHBAnimator.Play("EnemyHealthBarIntro", 0, 0.0f);
        this.gameObject.SetActive(false);
    }
}
