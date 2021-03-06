﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public static PlayerController1 instance;
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale = 5f;
    public ParticleSystem dust;

    private float slopeForce = 0.5f;
    private float slopeForceRayLength = 0.4f;

    private Vector3 moveDirection;

    public CharacterController charController;

    private Camera theCam;

    public GameObject playerModel;
    public float rotateSpeed;

    public Animator anim;

    public bool isKnocking;
    public float knockBackLength = .5f;
    private float knockbackCounter;
    public Vector2 knockbackPower;
    public bool updraft;
    public bool swimming;
    public float swimMoveSpeed;
    public float swimJumpForce;

    public GameObject[] playerPieces;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        theCam = Camera.main;
    }
    private void Update()
    {
        if (moveDirection.y < -60f)
        {
            moveDirection.y = 0;
        }
        if (!isKnocking)
        {

        float yStore = moveDirection.y;
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical") + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection.Normalize();
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore;

        if (!Onslope() && charController.isGrounded)
        {

                moveDirection.y = 0f;
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }


                 if ((Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") != 0))
            {

                charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);
                    
            }
            }

           
        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
   
        charController.Move(moveDirection * Time.deltaTime);
        if (Input.GetAxisRaw("Horizontal") !=0f|| Input.GetAxisRaw("Vertical") !=0)
        {
        transform.rotation = Quaternion.Euler(0f, theCam.transform.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation , rotateSpeed * Time.deltaTime);
                CreateDust();
            }
        }


        if (updraft == true)
        {
            anim.SetBool("Swimming",true);
            gravityScale = -2f;
            jumpForce = 0;
            moveSpeed = 10;
        }

        if (swimming == true & updraft == false)
        {
            anim.SetBool("Swimming", true);
            gravityScale = 3f;
            jumpForce = 14;
            moveSpeed = 10;
        }

        if (swimming == false & updraft == false)
        {
            anim.SetBool("Swimming", false);
            gravityScale = 5f;
            jumpForce = 24;
            moveSpeed = 15;
        }

        if (isKnocking)
        {

            knockbackCounter -= Time.deltaTime;
            float yStore = moveDirection.y;
            moveDirection = playerModel.transform.forward * -knockbackPower.x;
            moveDirection.y = yStore;

            if (charController.isGrounded)
            {
                moveDirection.y = 0f;
            }

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
            charController.Move(moveDirection * Time.deltaTime);
            if (knockbackCounter <= 0)
            {
                isKnocking = false;
            }
        }
        anim.SetFloat("Speed", Mathf.Abs(moveDirection.x + Mathf.Abs(moveDirection.z)));
        anim.SetBool("Grounded", charController.isGrounded);
    }
    public void Knockback()
    {
        isKnocking = true;
        knockbackCounter = knockBackLength;
        moveDirection.y = knockbackPower.y;
        charController.Move(moveDirection * Time.deltaTime);
    }

    private bool Onslope()
    {
       
        if (Input.GetButtonDown("Jump") && charController.isGrounded)
        {
            moveDirection.y = jumpForce;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLength));
        {
            if (hit.normal != Vector3.up)
            {
                return true;
            }
            return false;
        }
    }

    public void CreateDust()
    {
        dust.Play();
    }

}
