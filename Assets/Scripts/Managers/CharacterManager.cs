using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : Singleton<CharacterManager> {
	
	public Character character;
	public AObject photocopier;

	public GameObject target2;

	private GameObject _ObjectBehavior;

	public void Start() {
		CharacterManager.instance.AddCommand (this.photocopier.GetComponent<Behaviors>().InvokeBehavior("Taking"));
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

		Walking walking1 = character.GetComponent<Behaviors> ().InvokeBehavior("Walking", finalCommand.transform.parent.transform.position) as Walking;
		Walking walking2 = character.GetComponent<Behaviors> ().InvokeBehavior("Walking", target2.transform.position) as Walking;
		Walking walking3 = character.GetComponent<Behaviors> ().InvokeBehavior("Walking", this.character.transform.position) as Walking;
		
//		finalCommand.target = character.gameObject;

		instruction.Add (walking1);
//		instruction.Add (finalCommand);
		instruction.Add (walking2);
//		instruction.Add (this.photocopier.GetComponent<Behaviors> ().InvokeBehavior("Droping"));
		instruction.Add (walking3);

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
