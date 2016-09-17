using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestObject : MonoBehaviour, IState<StatesManager.EBehavior> {

	[SerializeField] private StatesManager.EBehavior	_state;

	private	Informations	_infos;

//	public string shortName					{ get { return this._shortName; } }
//	public string description				{ get { return this._description; } }
	public StatesManager.EBehavior state 	{ get { return this._state; } }

//	public BehaviorsProperties behaviors;

	public void Start() {
		this._infos = this.gameObject.GetComponent<Informations>();
//		this._infos.UpdateField<System.Int32> ("age", 23);
//		this._infos.UpdateField<float> ("age", 23f);
	}

//	public void Start() {
//		this._behaviors = this.gameObject.GetComponents<IBehavior> ();
//	}
//

//
//	public void Update() {
//		if (Input.anyKeyDown) {
//			this._behaviors[Random.Range(0, this._behaviors.Length)].Play ();
//		}
//	}
//
//	[ContextMenu ("Do Something")]
//	void DoSomething () {
//		Debug.Log ("Perform operation");
//	}
}
