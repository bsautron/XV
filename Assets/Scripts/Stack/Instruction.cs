using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Instruction : List<ABehavior>, IState<StatesManager.EInstruction> {
	
	private StatesManager.EInstruction	_state;
	public StatesManager.EInstruction state { get { return this._state; } }
	private IEnumerator<ABehavior> _enumeratorBehavior;

	public void LaunchCommand () {
		if (this._state != StatesManager.EInstruction.RUNNING) {
			this._state = StatesManager.EInstruction.RUNNING;

			_enumeratorBehavior = this.GetEnumerator ();
			_enumeratorBehavior.MoveNext();
			_enumeratorBehavior.Current.Play ();
		}
		if (_enumeratorBehavior.Current.state == StatesManager.EBehavior.STANDBY) {
			if (_enumeratorBehavior.MoveNext ()) {
				_enumeratorBehavior.Current.Play ();
			} else {
				this._state = StatesManager.EInstruction.FINISHED;
			}
		}
	}

	public 
}
