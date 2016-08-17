using UnityEngine;
using System.Collections;

public abstract class ABehavior : MonoBehaviour, IBehavior {

	protected StatesManager.EBehavior	_state;
	protected string					_shortName;
	protected string					_description;

	protected IEnumerator				_coBehavior;
	protected GameObject 				_parent;


	public StatesManager.EBehavior state 
		{ get { return this._state; } }
	public string shortName
		{ get { return this._shortName; } }
	public string description
		{ get { return this._description; } }

	public void Play() {
		Debug.Log ("[Behavior] " + this._shortName + ": Play");
		this._state = StatesManager.EBehavior.RUNNING;
		while (this._coBehavior.MoveNext ()) {
			Debug.Log (this._coBehavior.Current);
		}
	}

	public void Stop() {
		Debug.Log ("[Behavior] " + this._shortName + ": Stop");
		this._state = StatesManager.EBehavior.STANDBY;
	}

	public abstract IEnumerator CoBehavior ();
}
