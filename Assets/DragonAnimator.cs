using UnityEngine;
using System.Collections;

public class DragonAnimator : CharacterAnimator {

	Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			PlayAttack();
		}
	}

	public override void PlayAttack()
	{
		anim.Play("attack_1");
	}

	public override void GetHit()
	{
	}

	public override void Die()
	{
		anim.Play("dead");
	}

}
