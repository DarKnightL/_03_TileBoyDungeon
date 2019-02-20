using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamagable
{

    public void Damage() {
        enemyAnimator.SetTrigger("Hit");
        enemyAnimator.SetBool("InCombat", true);
        Health--;
        isHit = true;
        if (Health<=0)
        {
            isDead = true;
            enemyAnimator.SetTrigger("Death");
            Destroy(this.gameObject,5f);
        }

    }

    public int Health { get; set; }


    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

}
