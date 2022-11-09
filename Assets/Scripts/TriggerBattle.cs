using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerBattle : MonoBehaviour
{
    [SerializeField] GameObject _playerHealthBar;
    [SerializeField] GameObject _enemyHealthBar;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("StateController").GetComponent<PlayerMovement>()._triggerBattle = true;
        _playerHealthBar.SetActive(true);
        _enemyHealthBar.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
