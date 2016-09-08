using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleSystem : MonoBehaviour {

	Character player;
	Character enemy;

	MoveChooser moveChooser;

	List<Command> commands;

	List<Character> sortedPlayers;
	bool isGettingCommands;

	void Awake(){
		moveChooser = GetComponentInChildren<MoveChooser>();
	}

	public void StartBattle(Character player, Character enemy){
		this.player = player;
		this.enemy = enemy;
		sortedPlayers = new List<Character>();
		sortedPlayers.Add(player);
		sortedPlayers.Add(enemy);
		PlayTurn();
	}

	void PlayTurn(){
		commands = new List<Command>();
		sortedPlayers.Sort();
		isGettingCommands = true;
		StartCoroutine(GetMoves());
	}

	IEnumerator GetMoves()
	{
		for (int i = 0; i < sortedPlayers.Count; i++){
			var character = sortedPlayers[i];
			GetMove(character);
			yield return new WaitUntil(() => { return HasMoveForCharacter(character);});
		}
		yield return null;
		StartCoroutine(PlayBattle());
	}


	void GetMove(Character character)
	{
		if (character.ai != null){
			commands.Add(character.ai.GetMove(player));
		}
		else {
			moveChooser.StartInput(character, enemy, (obj) => { commands.Add(obj); });
		}
	}


	bool HasMoveForCharacter(Character c){
		for (int i = 0; i < commands.Count; i++){
			if (commands[i].caster == c) { return true;}
		}
		return false;
	}


	IEnumerator PlayBattle()
	{
		for (int i = 0; i < commands.Count; i++){
			var command = commands[i];
			command.caster.animator.PlayAttack();
			yield return new WaitForSeconds(1f);
			var damage = command.caster.ATK * command.ability.power / command.target.DEF;
			command.target.HP -= damage;
			command.target.GetComponent<HPScript>().ChangeHP(-damage, command.target.transform.position + Vector3.up * 5, Color.red);
			command.target.animator.GetHit();
			if (command.target.HP <= 0)
			{
				yield return new WaitForSeconds(.2f);
				command.target.animator.Die();
			}
			CameraShake.shake = 1f;
			yield return new WaitForSeconds(1f);
		}
		PlayTurn();
	}





}
