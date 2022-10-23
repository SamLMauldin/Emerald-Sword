using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController _controller;

    [SerializeField] float speed = 10f;

    [SerializeField] MouseLook _mouse = null;

    Vector3 _velocity;

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
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
