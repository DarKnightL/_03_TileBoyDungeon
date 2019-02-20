using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidController : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 8f);
    }


    void Update () {
        transform.Translate(Vector3.right * 3f * Time.deltaTime);
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            IDamagable hit = other.GetComponent<IDamagable>();
            if (hit!=null)
            {
                hit.Damage();
                Debug.Log("Acid Attack Player");
            }
        }
    }

}
