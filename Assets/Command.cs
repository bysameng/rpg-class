using UnityEngine;
using System.Collections;

public class Command {

	public Ability ability;
	public Character caster;
	public Character target;

	public Command(Character caster, Ability ability, Character target)
	{
		this.caster = caster;
		this.ability = ability;
		this.target = target;
	}

}
