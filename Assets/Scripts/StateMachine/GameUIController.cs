using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUIController : MonoBehaviour
{
    [SerializeField] Text _enemyThinkingTextUI = null;

    private void OnEnable()
    {
        EnemyTurnGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnGameState.EnemyTurnEnded += OnEnemyTurnEnded;
    }

    private void OnDisable()
    {
        EnemyTurnGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
    }

    private void Start()
    {
        //make sure this text is disabled on start
        _enemyThinkingTextUI.gameObject.SetActive(false);
    }

    void OnEnemyTurnBegan()
    {
        _enemyThinkingTextUI.gameObject.SetActive(true);
    }

    void OnEnemyTurnEnded()
    {
        _enemyThinkingTextUI.gameObject.SetActive(false);
    }
}
