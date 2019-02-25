using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canDamaged = true;


    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamagable hit = other.GetComponent<IDamagable>();
        if (hit != null && canDamaged)
        {
           
            hit.Damage();
            canDamaged = false;
            StartCoroutine(ResetCanDamaged());
        }
    }


    IEnumerator ResetCanDamaged()
    {
        yield return new WaitForSeconds(0.5f);
        canDamaged = true;
    }
}
