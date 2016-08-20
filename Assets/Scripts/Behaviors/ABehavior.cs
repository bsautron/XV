using UnityEngine;
using System.Collections;

public abstract class ABehavior : MonoBehaviour, IBehavior {

	[SerializeField] protected string					_shortName;
	[SerializeField] protected string					_description;
	[SerializeField] protected StatesManager.EBehavior	_state;

	protected IEnumerator 				_currentCoBehavior;

	public StatesManager.EBehavior state 
		{ get { return this._state; } }
	public string shortName
		{ get { return this._shortName; } }
	public string description
		{ get { return this._description; } }

	public void Start() {
		this._state = StatesManager.EBehavior.STANDBY;
	}

	public void Play() {
		if (this._state == StatesManager.EBehavior.STANDBY) {
			this._currentCoBehavior = this.CoBehavior ();
			this._state = StatesManager.EBehavior.RUNNING;
			StartCoroutine (this._currentCoBehavior);
		}
	}

	public void Stop() {
		if (this._state == StatesManager.EBehavior.RUNNING) {
			this._state = StatesManager.EBehavior.STANDBY;
			StopCoroutine (this._currentCoBehavior);
		}
	}

	public abstract IEnumerator CoBehavior ();
}
