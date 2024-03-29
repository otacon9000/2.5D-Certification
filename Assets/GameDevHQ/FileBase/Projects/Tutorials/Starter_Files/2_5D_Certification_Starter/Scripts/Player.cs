﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;    
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 10.0f;
    private Vector3 _direction;
    private CharacterController _cc;
    private Animator _anim;
    private bool _jumping = false;
    private bool _OnLedge = false;
    private Ledge _lastLedge;

    private void Start()
    {
        _cc = GetComponent<CharacterController>();
        _anim = GetComponentInChildren<Animator>();
        if(_cc == null)
        {
            Debug.LogError("CharacterController is NULL");
        }
        if(_anim == null)
        {
            Debug.LogError("Animator is NULL");
        }
    }

    private void Update()
    {
        PlayerMove();  
        if(_OnLedge == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _anim.SetTrigger("ClimbUp");
            }
        }
    }

    void PlayerMove()
    {
        if (_cc.isGrounded == true)
        {
            if(_jumping == true)
            {
                _jumping = false;
                _anim.SetBool("Jumping", _jumping);
                

            }

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _direction = new Vector3(0, 0, horizontalInput) * _speed;
            _anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
            
            if(horizontalInput != 0)
            {
                Vector3 facing = transform.localEulerAngles;
                facing.y = _direction.z > 0 ? 0 : 180;
                transform.localEulerAngles = facing;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumping = true;
                _anim.SetBool("Jumping", _jumping);
                _direction.y += _jumpHeight;

            }

        }

        _direction.y -= _gravity * Time.deltaTime;
        _cc.Move(_direction * Time.deltaTime);
    }

    public void GrabLedge(Vector3 grabPosition, Ledge currentLedge)
    {
        _cc.enabled = false;
        _anim.SetBool("GrabLedge", true);
        _anim.SetBool("Jumping", false);
        _anim.SetFloat("Speed", 0.0f);
        _OnLedge = true;
        _lastLedge = currentLedge;
        transform.position = grabPosition;
       
    }

    public void ClimbUp()
    {
        transform.position = _lastLedge.GetStandPosition();
        _anim.SetBool("GrabLedge", false);
        _cc.enabled = true; ;

    }

}
