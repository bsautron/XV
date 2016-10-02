using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : Singleton<CharacterManager> {

//	[SerializeField] protected Dictionary<int,string> = new Dictionary<int, string> () {
//		{0, "Character.GoTo"},
//		{1, "Character.GetObject"},
//		{2, "Character.DepositObject"},
//		{3, ""}
//	}
	private StackInstruction _StackInsruction = new StackInstruction ();

	public void InterpretCommand(ABehavior Command) {
		//if (Command.GetInstanceID) {
			this._StackInsruction.AddIstruction (Command);
	//	}
	}
}
