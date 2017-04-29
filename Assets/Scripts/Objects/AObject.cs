using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Informations))]
[RequireComponent (typeof (Behaviors))]
[RequireComponent (typeof (Rigidbody))]
public abstract class AObject : MonoBehaviour, IState<StatesManager.EObject> {

	[SerializeField] private StatesManager.EObject	_state;
	
	// OTHER
	[SerializeField] protected	bool	_editeable;
	public		bool	editeable {
		get { return _editeable; }
	}
	
//	[SerializeField] protected	bool	_takeable;
//	public		bool	takeable {
//		get { return _takeable; }
//	}
	
	[SerializeField] protected 	bool	_isActive;
	public		bool	isActive {
		get { return this._isActive; }
		set { this._isActive = value; }
	}

	protected Renderer[] _renderers;
	public		Renderer[]	renderers {
		get { return this._renderers; }
	}


	protected Informations _infos;
	public Informations infos { get { return this._infos; } }

	protected Behaviors _behaviors;

	public StatesManager.EObject state 	{ get { return this._state; } }

	public void Awake() {
		this._behaviors = this.gameObject.GetComponent<Behaviors> ();
		this._infos = this.gameObject.GetComponent<Informations>();
		this._renderers = this.gameObject.GetComponentsInChildren<Renderer> ();
	}
}
