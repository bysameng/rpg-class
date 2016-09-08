using UnityEngine;
using System.Collections;

public class BattleTester : MonoBehaviour {

	public BattleSystem system;
	public Character player;
	public Character enemy;

	// Use this for initialization
	void Start () {
		system.StartBattle(player, enemy);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
