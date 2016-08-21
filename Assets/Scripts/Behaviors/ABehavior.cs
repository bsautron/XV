using UnityEngine;
using System.Collections;

public abstract class ABehavior : MonoBehaviour, IBehavior {

	[SerializeField] protected StatesManager.EBehavior	_state;

	protected IEnumerator 				_currentCoBehavior;

	protected string					_shortName;
	protected string					_description;

	public string	 shortName 
		{ get { return this._shortName; } }

	public string	 description 
		{ get { return this._description; } }

	public StatesManager.EBehavior state 
		{ get { return this._state; } }

	public void Start() {
		this._state = StatesManager.EBehavior.STANDBY;
	}

	public virtual bool CheckIfPossible() {
		return this._state == StatesManager.EBehavior.STANDBY;
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

	public abstract IEnumerator CoBehavior ();
}
