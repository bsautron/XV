using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>, IState<StatesManager.EGame> {
	[SerializeField] protected StatesManager.EGame	_state;

	public StatesManager.EGame state { 
		get { return this._state; }
		set { this._state = value; }
	}

}
