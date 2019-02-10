using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

    private Animator animator;

	
	void Start () {
        animator = GetComponentInChildren<Animator>();
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
    }

}
