using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>, IState<StatesManager.EGame> {

	[SerializeField] protected StatesManager.EGame	_state;

	public StatesManager.EGame state { 
		get { return this._state; }
		set { this._state = value; }
	}

	public void Start() {
		this.Resume ();
	}

	public void Update() {
		this._HandleKeyInput ();
	}


	/* INPUT KEY HANDLERS */
	private void _HandleKeyInput() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("PRESS ESC");
			this._KeyEscape ();
		}
	}

	private void _KeyEscape() {
		switch (this._state) {
		case StatesManager.EGame.PLAY:
			this.Pause ();
			break;
		case StatesManager.EGame.PAUSE:
			this.Resume ();
			break;
		case StatesManager.EGame.REPLAY:
			this._state = StatesManager.EGame.PAUSE;
			break;
		default:
			break;
		}
	}

	/* STATES CHANGEMENTS */
	public void Pause() {
		Debug.Log ("GAME: Paused");
		this._state = StatesManager.EGame.PAUSE;
		Time.timeScale = 0;
		GUIManager.instance.DisablePanel (GUIManager.instance.pauseButton);
		GUIManager.instance.EnablePanel (GUIManager.instance.playButton);
		GUIManager.instance.EnablePanel (GUIManager.instance.pausePanel);
	}

	public void Resume() {
		Debug.Log ("GAME: Resumed");
		this._state = StatesManager.EGame.PLAY;
		Time.timeScale = 1;
		GUIManager.instance.DisablePanel (GUIManager.instance.playButton);
		GUIManager.instance.EnablePanel (GUIManager.instance.pauseButton);
		GUIManager.instance.DisablePanel (GUIManager.instance.pausePanel);
	}
}