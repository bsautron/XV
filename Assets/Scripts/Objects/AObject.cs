using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Informations))]
[RequireComponent (typeof (Behaviors))]
public abstract class AObject : MonoBehaviour, IState<StatesManager.EObject> {

	[SerializeField] private StatesManager.EObject	_state;

	protected Informations _infos;
	protected Behaviors _behaviors;

	public StatesManager.EObject state 	{ get { return this._state; } }

	public void Awake() {
		this._behaviors = this.gameObject.GetComponent<Behaviors> ();
		this._infos = this.gameObject.GetComponent<Informations>();
	}
}
