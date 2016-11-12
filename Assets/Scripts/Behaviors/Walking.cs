﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Walking : ABehavior, IContext<Vector3> {

	private Queue<Vector3>	_contexts = new Queue<Vector3>();

	private Character 		_character;

	private Vector3			_targetPosition;

	public override void Start() {
		base.Start ();
		this._character = this._parent.GetComponent<Character> ();
	}

	public void AddContext(Vector3 value) {
		this._contexts.Enqueue (value);
	}

	public Vector3 GetContext() {
		Vector3 context = this._contexts.Peek ();
		Debug.Log ("Context : " + context);
		this._contexts.Dequeue ();
		return context;
	}
	
	public override IEnumerator CoBehavior() {
		NavMeshAgent charaterAgent = this._character.agent;
		Vector3 targetPosition = this.GetContext ();

		charaterAgent.ResetPath ();
		charaterAgent.SetDestination(targetPosition);

		Debug.Log ("CoBehavior: " + targetPosition);
//		this._onDeplacement = true;

		yield return new WaitForEndOfFrame();

//		charaterAgent.Resume ();
		Debug.Log(charaterAgent.remainingDistance + " > " + charaterAgent.stoppingDistance);

		while (charaterAgent.remainingDistance > charaterAgent.stoppingDistance) {
			yield return true;
		}
//		this._onDeplacement = false;
//		charaterAgent.Stop ();
		this.Stop ();

		yield return new WaitForSeconds(2f);
	}

	public override bool IsAvailable() {
		return true;
	}


}
