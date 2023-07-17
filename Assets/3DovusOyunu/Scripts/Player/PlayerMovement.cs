using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CAN
{
    public class  PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private Animator _animator;
    public float runSpeed = 40f;
    private bool jump = false;
    private float horizontalMove = 0f;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
/*
    private void Start()
    {
        StartCoroutine(CanJumpAgain());
    }
*/
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        _animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            jump = true;
            _animator.SetBool("IsJumping",true);
            //CanJumpAgain();
        }
        
    }
    public void OnLanding ()
    {
        _animator.SetBool("IsJumping", false);
        
    }
    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
/*
    private IEnumerator CanJumpAgain()
    { 
        jumpEnabled = false;
       yield return new WaitForSeconds(3f);
       jumpEnabled = true;
    }
    */
}
}