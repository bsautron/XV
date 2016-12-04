using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>, IState<StatesManager.EGame> {

	[SerializeField] protected StatesManager.EGame	_state;
//
	public GameObject go;

	public StatesManager.EGame state { 
		get { return this._state; }
		set { this._state = value; }
	}
//
	public void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			go.GetComponent<Behaviors>().InvokeBehavior("Booting");
		}
	}
}