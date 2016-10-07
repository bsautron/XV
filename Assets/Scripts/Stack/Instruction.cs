using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Instruction : List<ABehavior>, IState<StatesManager.EInstruction> {

	protected StatesManager.EInstruction	_state;
	public StatesManager.EInstruction state { get { return this._state; } }
//	private ABehavior _behavior;
//	private bool _endOfInstruction = false;
//
//	public Instruction() {
//
//	}

//	public bool checkIfEndOfCommand() {
//		return (this._endOfInstruction);
//	}

//	public ABehavior GetBehavior () {
//		return (_behavior);
//	}
}
