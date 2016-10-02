using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Instruction {

	private ABehavior _behavior;
	private bool _endOfInstruction = false;

	public Instruction(ABehavior behavior) {
		this._behavior = behavior; 
	}

	public bool checkIfEndOfCommand() {
		return (this._endOfInstruction);
	}

	public ABehavior GetBehavior () {
		return (_behavior);
	}
}
