using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StackInstruction : MonoBehaviour {

	private Queue<Instruction> _stackInstruction = new Queue<Instruction>();

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this.CheckStack();
	}

	public void AddIstruction(ABehavior nextInstruction) {
		if (nextInstruction) {
			this._stackInstruction.Enqueue (new Instruction (nextInstruction));
		}
	}

	public void CheckStack() {
		Instruction nextInstruction;
		ABehavior behavior;

		if (_stackInstruction.Count > 0) {
			nextInstruction = _stackInstruction.Peek ();
			behavior = nextInstruction.GetBehavior ();
			if (behavior.state = "stop") {
				_stackInstruction.Dequeue ();
			} else {
				if (behavior.IsEnableToPlay()) {
					behavior.Play ();
				}
			}
		}
	}
}