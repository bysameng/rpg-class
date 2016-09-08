using UnityEngine;
using System.Collections;

public class CactusAnimator : CharacterAnimator {

	Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public override void PlayAttack()
	{		
		anim.Play("Attack");
	}

	public override void GetHit()
	{
		anim.Play("Get hit");
	}

	public override void Die()
	{
		anim.Play("Die");
	}

}
