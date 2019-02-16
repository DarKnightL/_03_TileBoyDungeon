using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }


    public int Health { get; set; }


    public void Damage()
    {
        enemyAnimator.SetTrigger("Hit");
        enemyAnimator.SetBool("InCombat", true); //After Hitted then Freeze
        Health--;
        isHit = true;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    //public override void Movement()
    //{
    //    base.Movement();
    //    float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
    //    Debug.Log("SkeletonDistance:" + distance);
    //}


}
