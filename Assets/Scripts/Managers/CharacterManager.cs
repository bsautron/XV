using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : Singleton<CharacterManager> {
	
	public Character character;
	public AObject photocopier;

	private GameObject _ObjectBehavior;

	public void Start() {
		CharacterManager.instance.AddCommand (this.photocopier.GetComponent<Behaviors>().dic["Booting"]);
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

		instruction.Add (walking);
		instruction.Add (finalCommand);
		character.stackInstructions.Enqueue (instruction);
	}	

}
