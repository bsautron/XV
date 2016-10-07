using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Walking : ABehavior {
	
	private Character 		_character;
	private Vector3			_targetPosition;

	public override void Start() {
		base.Start ();
		this._character = this._parent.GetComponent<Character> ();
	}

	private void MoveTo () {
		this._character.agent.destination = this._targetPosition;
		if (!this._character.agent.pathPending) {
			if (this._character.agent.remainingDistance <= this._character.agent.stoppingDistance) {
				if (!this._character.agent.hasPath || this._character.agent.velocity.sqrMagnitude == 0f) {
					this.Stop ();
				}
			}
		}
	}

	public override IEnumerator CoBehavior() {
		this.MoveTo ();
		yield return true;
	}

	public override bool IsAvailable() {
		return true;
	}

	public void SetTargetPosition(Vector3 pos) {
		this._targetPosition = pos;
	}
}
