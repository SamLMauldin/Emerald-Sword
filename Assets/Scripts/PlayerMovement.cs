using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GameState
{
    [SerializeField] CharacterController _controller;

    [SerializeField] float speed = 10f;

    public bool _canLook = true;

    Vector3 _velocity;

    public bool _triggerBattle = false;
    public bool _activated = false;

    public override void Enter()
    {
        _activated = true;
        Debug.Log("You can Walk!");
    }
    private void Update()
    {
        if (_activated)
        {
            PlayerMove();
            if (_triggerBattle)
            {
                Debug.Log("should Work");
                StateMachine.ChangeState<PlayerTurnGameState>();
            }
        }
    }

    public override void Exit()
    {
        _triggerBattle = false;
        _activated = false;
        _canLook = false;
        Debug.Log("GoodBye!");
    }
    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(_velocity * Time.deltaTime);

        _controller.Move(move * speed * Time.deltaTime);
    }
}
