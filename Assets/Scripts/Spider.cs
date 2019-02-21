using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{


    public void Damage()
    {
        if (isDead)
        {
            return;
        }

        Health--;

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

    public override void Movement()
    {
        //BLANK
    }


    public GameObject spiderAcid;

    public void Fire()
    {
        Instantiate(spiderAcid, transform.position, Quaternion.identity);
    }


    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
}
