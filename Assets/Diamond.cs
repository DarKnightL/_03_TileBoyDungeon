using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

    public int gems = 1;

    private Rigidbody2D rigidbody;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.gemsOwn += gems;
            Destroy(this.gameObject);
        }
    }


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Vector3.up * 200f);
    }

}
