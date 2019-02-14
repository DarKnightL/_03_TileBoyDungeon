using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{

    Vector3 currentTarget;
    Animator spiderAnimator;
    SpriteRenderer spiderSprite;


    private void Start()
    {
        spiderAnimator = GetComponentInChildren<Animator>();
        spiderSprite = GetComponentInChildren<SpriteRenderer>();
    }


    public override void Update()
    {
        if (spiderAnimator.GetCurrentAnimatorStateInfo(0).IsName("SpiderIdle"))
        {
            return;
        }
        Movement();
    }


    void Movement()
    {

        if (currentTarget == pointA.position)
        {
            spiderSprite.flipX = true;
        }
        else if (currentTarget == pointB.position)
        {
            spiderSprite.flipX = false;
        }


        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
