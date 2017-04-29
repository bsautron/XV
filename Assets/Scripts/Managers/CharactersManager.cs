using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharactersManager : Singleton<CharactersManager> {
	
	public ACharacter character;
	private GameObject _ObjectBehavior;


	public void Update () {
	}

	public void AddCommand (ABehavior finalCommand) {
		if (finalCommand) {
			this.InterpretCommand(finalCommand);
		}
	}

	private void InterpretCommand(ABehavior finalCommand) {
		Instruction instruction = new Instruction ();

		Walking walking = character.GetComponent<Behaviors> ().InvokeBehavior("Walking", finalCommand.transform.parent.transform.position) as Walking;
		
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
