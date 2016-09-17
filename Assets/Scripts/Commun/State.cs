using UnityEngine;
using System.Collections;

[System.Serializable]
public class State<T> {
	
	public delegate void WhenStateChanged(T state);
	public event WhenStateChanged OnStateChanged;

	private T _state;

	public T state {
		get { return this._state; }
		set { this._ChangeState (value); }
	}

	private bool _ChangeState(T newState) {
		Debug.Log (this._state);
//		if (this._state == newState)
			return false;

		this._state = newState;
		OnStateChanged(newState);
		return true;
	}

	public bool Equal(T value1, T value2) {
		Debug.Log ("EFW:EOIFJWEIJF:");
		return true;
	}
}
