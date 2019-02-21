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

    protected bool isHit;
    protected bool isDead = false;


    protected PlayerController player;

    [SerializeField]
    protected GameObject diamondPrefab;





    public virtual void Init()
    {
        enemySprite = GetComponentInChildren<SpriteRenderer>();
        enemyAnimator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    private void Start()
    {
        Init();
    }


    public virtual void Update()
    {
        if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !enemyAnimator.GetBool("InCombat"))
        {
            return;
        }

        if (!isDead)
        {
            Movement();
        }
      

    }


    public virtual void Movement()
    {

        float distance = Vector3.Distance(transform.localPosition, player.transform.position);
        if (distance > 2.0f)
        {
            isHit = false;

            enemyAnimator.SetBool("InCombat", false);
        }


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

        if (isHit == false)//Cannot be decided on the Update Loop in case the Movement() not been updated constantly
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }


        Vector3 direction = player.transform.localPosition - transform.position;
        if (direction.x > 0 && enemyAnimator.GetBool("InCombat"))
        {
            enemySprite.flipX = false;
        }
        else if (direction.x <= 0 && enemyAnimator.GetBool("InCombat"))
        {
            enemySprite.flipX = true;
        }


    }
}


