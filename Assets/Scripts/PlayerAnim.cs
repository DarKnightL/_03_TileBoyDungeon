using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

    private Animator animator;
    private Animator swordArcAnimator;

	
	void Start () {
        animator = GetComponentInChildren<Animator>();
        swordArcAnimator = transform.GetChild(1).GetComponent<Animator>();
	}
	
	
	void Update () {
		
	}

    public void AnimAlter(float move){

        animator.SetFloat("Move", Mathf.Abs(move));
    }


    public void AnimJump(bool isJump){

        animator.SetBool("isJump", isJump);
    }

    public void AnimRegAttack(){

        animator.SetTrigger("isAttack");
        swordArcAnimator.SetTrigger("SwordArc");
    }


    

}
