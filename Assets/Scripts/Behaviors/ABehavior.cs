using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Informations))]
public abstract class ABehavior : MonoBehaviour, IState<StatesManager.EBehavior>  {
	[SerializeField] protected StatesManager.EBehavior	_state;
	protected IEnumerator 				_currentCoBehavior;
	protected GameObject				_referrer;
	protected object 					_context;
	public bool							isReplay;
	private string						_name;

	public StatesManager.EBehavior state { get { return this._state; } }
	public GameObject referrer { get { return this._referrer; } set { this._referrer = value; } }
	public object context { get { return this._context; } set { this._context = value; } }

	public void Awake() {
		this._state = StatesManager.EBehavior.STANDBY;
	}

	public virtual void Start() {
		this._name = this.GetComponent<Informations> ().GetField ("displayName") as string;
		Debug.Log ("My referrer is: " + this._referrer);
	}

	public bool IsEnableToPlay() {
		return this._state == StatesManager.EBehavior.STANDBY;
	}

	public bool IsEnableToStop() {
		return this._state == StatesManager.EBehavior.RUNNING;
	}

	public ABehavior _Clone() {
		if (!this.isReplay) {
			ABehavior replayBehavior = this._referrer.GetComponent<Behaviors> ().InvokeBehavior (this._name, this._context);
			replayBehavior.transform.parent = ReplayManager.instance.transform;
			replayBehavior.isReplay = true;
			return replayBehavior;
		}
		return null;
	}

	public void Play() {
		if (this.IsEnableToPlay()) {
			ABehavior replayBehavior = this._Clone ();
			if (replayBehavior)
				ReplayManager.instance.PushEvent (replayBehavior);
			Debug.Log("Play: " + this._name);
			this._currentCoBehavior = this.CoBehavior ();
			this._state = StatesManager.EBehavior.RUNNING;
			StartCoroutine (this._currentCoBehavior);
		}
	}

	public void Stop() {
		if (this.IsEnableToStop()) {
			this._state = StatesManager.EBehavior.STANDBY;
			StopCoroutine (this._currentCoBehavior);
			Destroy(this.gameObject);
		}
	}

	public abstract bool IsAvailable ();
	public abstract IEnumerator CoBehavior ();
}
