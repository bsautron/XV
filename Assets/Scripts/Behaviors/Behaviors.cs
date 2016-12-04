﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Behaviors : MonoBehaviour {

	[SerializeField] private ABehavior[]	_tabBehavior;

	private Dictionary<string, ABehavior>	_dicBehavior = new Dictionary<string, ABehavior>();
	public Dictionary<string, ABehavior> dic { get { return this._dicBehavior; } }

	public void Start() {
		this._Init (this._tabBehavior);
	}

	private void _Init(ABehavior[] listBehavior) {
		foreach (ABehavior behavior in listBehavior) {
//			ABehavior b = Instantiate (behavior, this.transform.position, Quaternion.identity) as ABehavior;
			this._MapToDictionary (behavior);
		}
	}

	private void _MapToDictionary(ABehavior behavior) {

		Debug.Log (behavior.GetComponent<Informations> ().GetField ("displayName") as string);
//		string behaviorName = behavior.GetComponent<Informations> ().GetField ("displayName") as string;
//		this._dicBehavior.Add (behaviorName, behavior);
	}

	private void _AssignParent(ABehavior behavior) {
		behavior.transform.parent = this.transform;
	}

	public void InvokeBehavior(string behaviorName) {
		this._AssignParent (Instantiate (this.dic [behaviorName], this.transform.position, Quaternion.identity) as ABehavior);
	}
}
