using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

    public int gems = 1;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player!=null)
            {
                player.AddGems(gems);
                //player.gemsOwn += gems;
                Destroy(this.gameObject);
            }
            
        }
    }


  

}
