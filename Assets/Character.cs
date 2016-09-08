using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour, IComparable<Character>{

	public int HP;

	public int SPD;
	public int ATK;
	public int DEF;

	public CharacterAnimator animator;
	public Ability[] abilities;

	public TurnAI ai;


	void Start(){
		animator = GetComponent<CharacterAnimator>();
		ai = GetComponent<TurnAI>();
	}

	public int CompareTo(Character obj)
	{
		return SPD.CompareTo(obj.SPD);
	}

	public void DoTurn()
	{

	}
}
