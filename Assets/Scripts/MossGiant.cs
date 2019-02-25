using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamagable
{

    public void Damage()
    {
        if (isDead)
        {
            return;
        }


        enemyAnimator.SetTrigger("Hit");
        enemyAnimator.SetBool("InCombat", true);
        Health--;
        isHit = true;
        if (Health <= 0)
        {
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().gems = base.gems;
            isDead = true;
            enemyAnimator.SetTrigger("Death");
            Destroy(this.gameObject, 5f);
        }

    }

    public int Health { get; set; }


    public override void Init()
    {
        base.Init();
        Health = base.health;
    }


    

}
