using UnityEngine;
using System.Collections;

public abstract class ABehavior : MonoBehaviour, IBehavior<ABehavior.State> {

	public enum State {STANDBY, RUNNING};

	private IEnumerator	_coBehavior;
	private State		_state;
	
	public void Awake () {
		this._state = State.STANDBY;
		this._coBehavior = this.CoBehavior();
	}

	public State GetState() {
		return this._state;
	}

	public virtual void Play() {
		Debug.Log ("Start behavior");
		this._state = State.RUNNING;
		StartCoroutine (this._coBehavior);
	}

	public virtual void Stop() {
		Debug.Log ("Stop behavior");
		this._state = State.STANDBY;
		StopCoroutine (this._coBehavior);
	}

	public virtual IEnumerator CoBehavior() {
		Debug.Log ("Start CoBehavior");
		yield return new WaitForSeconds (1f);
		Debug.Log ("End CoBehavior");
		yield return true;
		this.Stop ();
	}
}
