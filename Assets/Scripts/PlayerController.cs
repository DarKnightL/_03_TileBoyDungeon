﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;


public class PlayerController : MonoBehaviour, IDamagable
{

    public Rigidbody2D rigidbody;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float moveSpeed = 2.5f;

    private bool resetJumpNeeded = false;

    private PlayerAnim playerAnim;
    private SpriteRenderer playerSprite;
    private SpriteRenderer arcSprite;

    private bool animGrounded = false;
    public bool canMove = true;

    public int gemsOwn;

    public int Health { get; set; }



    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnim>();
        //playerAnim = FindObjectOfType<PlayerAnim>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        arcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }


    void Update()
    {
        if (Health < 1)
        {
            return;
        }


        Movement();


        if (ETCInput.GetButtonDown("ButtonB") && CheckGrounded())
        {
            playerAnim.AnimRegAttack();
        }
    }


    void Movement()
    {
        if (!canMove)
        {
            return;
        }

        float moveLeftRight = ETCInput.GetAxis("Horizontal");



        animGrounded = CheckGrounded(); //Constantly check the raycast;

        SpriteFlip(moveLeftRight);


        if (ETCInput.GetButtonDown("ButtonA") && CheckGrounded())
        {
            playerAnim.AnimJump(true);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            StartCoroutine(ResetJumpCo());
        }

        rigidbody.velocity = new Vector2(moveLeftRight * moveSpeed, rigidbody.velocity.y);
        playerAnim.AnimAlter(moveLeftRight);
    }


    void SpriteFlip(float moveLeftRight)
    {
        if (moveLeftRight > 0)
        {
            playerSprite.flipX = false;
            arcSprite.transform.localScale = Vector3.one;
        }
        else if (moveLeftRight < 0)
        {
            playerSprite.flipX = true;
            //Vector2 newPos = arcSprite.transform.localPosition; //Remember to use localAxis
            //newPos.x = 0f;
            //arcSprite.transform.localPosition = newPos;
            arcSprite.transform.localScale = new Vector3(-1f, -1f, 0f); //when the target of flip is animation, the flipX function will be disable;
        }
    }


    IEnumerator ResetJumpCo()
    {
        resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }


    bool CheckGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);

        if (hitInfo.collider != null)
        {
            if (resetJumpNeeded == false)
            {
                playerAnim.AnimJump(false);
                return true;
            }
        }
        return false;
    }


    public void Damage()
    {
        Debug.Log("Player Damage Function has been triggered");
        if (Health < 1)  //Stop DeathAnim been triggered multi times
        {
            return;
        }

        Health--;
        UIManager.Instance.PlayerHealthUpdate(Health);
        if (Health < 1)
        {
            playerAnim.AnimDeath();
        }
    }





    public void AddGems(int num)
    {
        gemsOwn += num;
        UIManager.Instance.PlayerGemTextUpdate(gemsOwn);
    }
}


