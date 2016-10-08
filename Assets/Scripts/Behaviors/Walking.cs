using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Walking : ABehavior {
	
	private Character 		_character;
	private Vector3			_targetPosition;
	private bool			_onDeplacement = false;

	public override void Start() {
		base.Start ();
		this._character = this._parent.GetComponent<Character> ();
	}

	public void Update() {
		NavMeshAgent charaterAgent = this._character.agent;
		if (this.state == StatesManager.EBehavior.RUNNING && charaterAgent.hasPath) {
			if (charaterAgent.remainingDistance <= charaterAgent.stoppingDistance) {
				this._onDeplacement = false;
				this.Stop ();
			}
		}
	}
	
	public override IEnumerator CoBehavior() {
		this._character.agent.SetDestination(this._targetPosition);
		this._onDeplacement = true;
		while (this._onDeplacement) {
			yield return true;
		}
		yield return true;
	}

	public override bool IsAvailable() {
		return true;
	}

	public void SetTargetPosition(Vector3 pos) {
		this._targetPosition = pos;
	}
}
