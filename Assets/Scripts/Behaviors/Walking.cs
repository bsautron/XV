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

	public override IEnumerator CoBehavior() {
		NavMeshAgent charaterAgent = this._character.agent;
		Vector3 targetPosition = (Vector3)this._context;

		charaterAgent.ResetPath ();
		charaterAgent.SetDestination(targetPosition);

		yield return new WaitForEndOfFrame();

		while (charaterAgent.remainingDistance == 0)
			yield return false;
		while (charaterAgent.remainingDistance > charaterAgent.stoppingDistance)
			yield return true;

		this.Stop ();

		yield return new WaitForSeconds(2f);
	}

	public override bool IsAvailable() {
		return true;
	}


}
