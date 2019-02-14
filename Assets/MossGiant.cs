using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy {

    Vector3 currentTarget;
    Animator mossAnimator;
    SpriteRenderer mossSprite;


    private void Start()
    {
        mossAnimator = GetComponentInChildren<Animator>();
        mossSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (mossAnimator.GetCurrentAnimatorStateInfo(0).IsName("MossGiantIdle"))
        {
            return;
        }

        Movement();
    }



    void Movement() {
        if (currentTarget==pointA.position)
        {
            mossSprite.flipX = true;
        }
        else if (currentTarget==pointB.position)
        {
            mossSprite.flipX = false;
        }
      


        if (transform.position==pointA.position)
        {
            currentTarget = pointB.position;
            mossAnimator.SetTrigger("Idle");
        }
        else if (transform.position==pointB.position)
        {
            currentTarget = pointA.position;
            mossAnimator.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
