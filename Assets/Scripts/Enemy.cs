using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA;
    [SerializeField]
    protected Transform pointB;

    protected SpriteRenderer enemySprite;
    protected Animator enemyAnimator;

    private Vector3 currentTarget;



    


    public virtual void Init() {
        enemySprite = GetComponentInChildren<SpriteRenderer>();
        enemyAnimator = GetComponentInChildren<Animator>();
    }


    private void Start()
    {
        Init();
    }


    public virtual void Update()
    {
        if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
    }


    public virtual void Movement() {


        if (currentTarget == pointA.position)
        {
            enemySprite.flipX = true;
        }
        else if (currentTarget == pointB.position)
        {
            enemySprite.flipX = false;
        }



        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            enemyAnimator.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            enemyAnimator.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}


