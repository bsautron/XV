using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StackInstruction : Queue<Instruction> {
	

//	public void lauchInstruction() {
//		if (nextInstruction) {
//			this._stackInstruction.Enqueue (new Instruction (nextInstruction));
//		}
//	}

//	public void CheckStack() {
//		Instruction nextInstruction;
//		ABehavior behavior;
//
//		if (_stackInstruction.Count > 0) {
//			nextInstruction = _stackInstruction.Peek ();
//			behavior = nextInstruction.GetBehavior ();
//			if (behavior.state == StatesManager.EBehavior.STANDBY) {
//				_stackInstruction.Dequeue ();
//			} else {
//				if (behavior.IsEnableToPlay()) {
//					behavior.Play ();
//				}
//			}
//		}
//	}
}