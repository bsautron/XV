using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public struct InGameGUI {
	public GameObject mainPanel;
	public Button playButton;
	public Button pauseButton;
}

public struct PauseGUI {
	public GameObject mainPanel;
}

public class GUIManager : Singleton<GUIManager>  {

	public GameObject userGUI;

	public InGameGUI inGameGUI = new InGameGUI();
	public PauseGUI pauseGUI = new PauseGUI ();

	public void Start() {
		this.inGameGUI.playButton = this.userGUI.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Button>();
		this.inGameGUI.pauseButton = this.userGUI.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<Button>();
		this.pauseGUI.mainPanel = this.userGUI.transform.GetChild (1).gameObject;

		this._AddButtonAction (this.inGameGUI.playButton, GameManager.instance.Resume);
		this._AddButtonAction (this.inGameGUI.pauseButton , GameManager.instance.Pause);
	}
	
	private void _AddButtonAction(Button button, UnityEngine.Events.UnityAction action) {
		button.onClick.AddListener (action);

	}
	public void DisablePanel(GameObject go) {
		go.SetActive (false);
	}

	public void EnablePanel(GameObject go) {
		go.SetActive (true);
	}
}
