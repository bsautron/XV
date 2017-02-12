using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Walking : ABehavior {

	private Character 		_character;
	private Animator		_animator;

	public override void Start() {
		base.Start ();

		this._character = this._referrer.GetComponent<Character> ();
		this._animator = this._character.GetComponent<Animator>();
	}

	public override IEnumerator CoBehavior() {
		this._animator.SetBool ("isWalking", true);
		NavMeshAgent charaterAgent = this._character.agent;
		Vector3 targetPosition = (Vector3)this._context;
		this._referrer.transform.LookAt (targetPosition);

		charaterAgent.ResetPath ();
		charaterAgent.SetDestination(targetPosition);

		yield return new WaitForEndOfFrame();

		while (charaterAgent.remainingDistance == 0)
			yield return false;
		while (charaterAgent.remainingDistance > charaterAgent.stoppingDistance)
			yield return true;
		
		this._animator.SetBool ("isWalking", false);
		this.Stop ();
		yield return new WaitForSeconds(2f);
	}

	public override bool IsAvailable() {
		return true;
	}


}
