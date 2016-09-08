using UnityEngine;
using System.Collections;

public class TurnAI : MonoBehaviour {

	public Character character;

	void Awake()
	{
		this.character = GetComponent<Character>();
	}

	public Command GetMove(Character target)
	{
		return new Command(character, this.character.abilities[Random.Range(0, this.character.abilities.Length)], target);
	}

}
