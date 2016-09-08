using UnityEngine;
using System.Collections;

public abstract class CharacterAnimator : MonoBehaviour {


	public abstract void PlayAttack();
	public abstract void GetHit();
	public abstract void Die();

}
