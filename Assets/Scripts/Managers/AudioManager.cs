using UnityEngine;
using System.Collections;

public class AudioManager : Singleton<AudioManager> , IState<StatesManager.EVolume> {
	[SerializeField] protected StatesManager.EVolume	_state;
	
	public StatesManager.EVolume state { 
		get { return this._state; }
		set { this._state = value; }
	}

	public int main = 100;
	public int environement = 100;
	public int characters = 100;
	public int machines = 100;
}
