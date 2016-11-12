using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Informations))]
public abstract class ABehavior : MonoBehaviour, IState<StatesManager.EBehavior> {
	protected StatesManager.EBehavior	_state;
	protected IEnumerator 				_currentCoBehavior;

	public StatesManager.EBehavior state { get { return this._state; } }

	public void Start() {
		this._state = StatesManager.EBehavior.STANDBY;
	}

	public bool IsEnableToPlay() {
		return this._state == StatesManager.EBehavior.STANDBY;
	}

	public bool IsEnableToStop() {
		return this._state == StatesManager.EBehavior.RUNNING;
	}

	public void Play() {
		if (this.IsEnableToPlay()) {
			this._currentCoBehavior = this.CoBehavior ();
			this._state = StatesManager.EBehavior.RUNNING;
			StartCoroutine (this._currentCoBehavior);
		}
	}

	public void Stop() {
		if (this.IsEnableToStop()) {
			this._state = StatesManager.EBehavior.STANDBY;
			StopCoroutine (this._currentCoBehavior);
		}
	}

	public abstract bool IsAvailable ();
	public abstract IEnumerator CoBehavior ();
}
