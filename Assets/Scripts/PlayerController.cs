using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float moveSpeed = 2.5f;

    private bool resetJumpNeeded = false;

    private PlayerAnim playerAnim;
    private SpriteRenderer playerSprite;
    private SpriteRenderer arcSprite;

    private bool animGrounded = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnim>();
        //playerAnim = FindObjectOfType<PlayerAnim>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        arcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        Movement();
        if (Input.GetMouseButtonDown(0) && CheckGrounded())
        {
            playerAnim.AnimRegAttack();
        }
    }


    void Movement()
    {
        float moveLeftRight = Input.GetAxisRaw("Horizontal");

        animGrounded = CheckGrounded(); //Constantly check the raycast;

        SpriteFlip(moveLeftRight);


        if (Input.GetKeyDown("space") && CheckGrounded())
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




}
