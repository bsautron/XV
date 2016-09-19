using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestObject : MonoBehaviour, IState<StatesManager.EBehavior> {

	[SerializeField] private StatesManager.EBehavior	_state;

	private	Informations	_infos;

	public StatesManager.EBehavior state 	{ get { return this._state; } }

//	public BehaviorsProperties behaviors;

	public void Start() {
		this._infos = this.gameObject.GetComponent<Informations>();
		this._infos.UpdateField("age", 23f);
	}

}
