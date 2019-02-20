using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAcidAnimEvent : MonoBehaviour {

    private Spider spider;


    private void Start()
    {
        spider = GetComponentInParent<Spider>();
    }



    public void Fire() {
        spider.Fire();
    }
}
