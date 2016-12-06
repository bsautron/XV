using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>, IState<StatesManager.EGame> {

	[SerializeField] protected StatesManager.EGame	_state;
//
	public GameObject go;
	public float test = 1f;

	public StatesManager.EGame state { 
		get { return this._state; }
		set { this._state = value; }
	}
//
	public void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			ABehavior behavior = go.GetComponent<Behaviors>().InvokeBehavior("Booting", test);
			behavior.Play ();
		}
	}
}