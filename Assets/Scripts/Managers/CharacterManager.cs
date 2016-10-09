using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : Singleton<CharacterManager> {
	
	public Character character;
	public AObject photocopier;

	private GameObject _ObjectBehavior;

	public void Start() {
		CharacterManager.instance.AddCommand (this.photocopier.GetComponent<Behaviors>().dic["Taking"]);
		character = FindObjectOfType<Character> ();
	}

	public void Update () {
		checkCurrentCommand ();
	}

	public void AddCommand (ABehavior finalCommand) {
		if (finalCommand) {
			this.InterpretCommand(finalCommand);
		}
	}

	private void InterpretCommand(ABehavior finalCommand) {
		Instruction instruction = new Instruction ();

		Walking walking = character.GetComponent<Behaviors> ().dic ["Walking"] as Walking;
		walking.SetTargetPosition (finalCommand.parent.transform.position);
		finalCommand.target = character.gameObject;
		instruction.Add (walking);
		instruction.Add (finalCommand);
		character.stackInstructions.Enqueue (instruction);
	}	

	public void checkCurrentCommand () {
		Instruction currentInstruction;

		if (character.stackInstructions.Count > 0) {
			currentInstruction = character.stackInstructions.Peek ();
			if (currentInstruction.state == StatesManager.EInstruction.FINISHED) {
				character.stackInstructions.Dequeue ();
			} else {
				currentInstruction.LaunchCommand ();
			}
		}
	}
}
