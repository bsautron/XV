using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Instruction : List<ABehavior>, IState<StatesManager.EInstruction> {

	protected StatesManager.EInstruction	_state;
	public StatesManager.EInstruction state { get { return this._state; } }
}
