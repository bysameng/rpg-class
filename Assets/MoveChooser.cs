using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveChooser : MonoBehaviour {

	bool isInputting;
	Character currentCharacter;
	CanvasGroup cGroup;
	Button[] buttons;

	void Awake()
	{
		cGroup = GetComponent<CanvasGroup>();
		buttons = GetComponentsInChildren<Button>();
		isInputting = false;
	}

	public void StartInput(Character character, Character target, System.Action<Command> onSelect)
	{
		currentCharacter = character;
		var moves = currentCharacter.abilities;
		for (int i = 0; i < buttons.Length; i++)
		{
			buttons[i].gameObject.SetActive(false);
		}
		for (int i = 0; i < moves.Length; i++)
		{
			var move = moves[i];
			var button = buttons[i];
			button.gameObject.SetActive(true);
			var text = button.GetComponentInChildren<Text>();
			text.text = move.name;
			button.onClick.RemoveAllListeners();
			button.onClick.AddListener(
				() =>{
				onSelect(new Command(character, move, target));
					isInputting = false;
				}
			);
		}

		isInputting = true;
	}


	void Update(){
		cGroup.alpha = Mathf.Lerp(cGroup.alpha, isInputting ? 1 : 0, Time.deltaTime * 5f);
		cGroup.interactable = cGroup.alpha > .1f;
	}

}
