﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight;
    Vector3 velocity;
    bool isGrounded;
     public Animator anim;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded&& velocity.y<0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.Play("MeleeHit");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="AmmoBox")
        {
            other.gameObject.SetActive(false);
            PlayerController.Instance.ammo = 50;
            SoundManager.Instance.AmmoLoadSound();
            CanvasManager.Instance.RefreashAmmo();
        }     
    }
}
