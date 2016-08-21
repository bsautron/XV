using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AObject : MonoBehaviour, IDetailable {

	// OTHER
	[SerializeField] protected	bool	_takeable;
	public		bool	takeable {
		get { return _takeable; }
	}

	[SerializeField] protected 	bool	_isActive;
	public		bool	isActive {
		get { return this._isActive; }
		set { this._isActive = isActive; }
	}

	[SerializeField] protected	string	_shortName;
	public		string	shortName {
		get { return this._shortName; }
		set { this._shortName = shortName; }
	}

	[SerializeField] protected	string	_description;
	public		string	description {
		get { return this._description; }
		set { this._description = description; }
	}

	protected Dictionary<string, ABehavior> _dicBehavior = new Dictionary<string, ABehavior>();
	public Dictionary<string, ABehavior> dicBehavior {
		get { return _dicBehavior; }
	}

	void Awake() {
		// behaviour
		ABehavior[] behaviors;
		behaviors = this.gameObject.GetComponents<ABehavior> ();
		foreach (ABehavior behavior in behaviors) {
			this._dicBehavior.Add(behavior.shortName, behavior);
		}
	}
}
