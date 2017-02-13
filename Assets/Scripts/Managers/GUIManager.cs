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
	public Button resumeButton;
	public Button settingsButton;
	public Button editorButton;
	public Button saveButton;
	public Button loadButton;
	public Button replaysButton;
}

public class GUIManager : Singleton<GUIManager>  {

	public GameObject userGUI;

	public InGameGUI inGameGUI = new InGameGUI();
	public PauseGUI pauseGUI = new PauseGUI ();

	public void Start() {
		/* Get all panel button from the scene */
		this.inGameGUI.mainPanel = this.userGUI.transform.GetChild (0).gameObject;
		this.inGameGUI.playButton = this.inGameGUI.mainPanel.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Button>();
		this.inGameGUI.pauseButton = this.inGameGUI.mainPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Button>();

		this.pauseGUI.mainPanel = this.userGUI.transform.GetChild (1).gameObject;
		this.pauseGUI.resumeButton = this.pauseGUI.mainPanel.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Button>();
		this.pauseGUI.settingsButton = this.pauseGUI.mainPanel.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject.GetComponent<Button>();
		this.pauseGUI.editorButton = this.pauseGUI.mainPanel.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2).gameObject.GetComponent<Button>();
		this.pauseGUI.saveButton = this.pauseGUI.mainPanel.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(3).gameObject.GetComponent<Button>();
		this.pauseGUI.loadButton = this.pauseGUI.mainPanel.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(4).gameObject.GetComponent<Button>();
		this.pauseGUI.replaysButton = this.pauseGUI.mainPanel.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(5).gameObject.GetComponent<Button>();

		/* Add buttons actions */
		this._AddButtonAction (this.inGameGUI.playButton, GameManager.instance.Resume);
		this._AddButtonAction (this.inGameGUI.pauseButton , GameManager.instance.Pause);

		this._AddButtonAction (this.pauseGUI.resumeButton , GameManager.instance.Resume);
		this._AddButtonAction (this.pauseGUI.settingsButton , GameManager.instance.GoSettingsMode);
		this._AddButtonAction (this.pauseGUI.editorButton , GameManager.instance.GoEditonMode);
		this._AddButtonAction (this.pauseGUI.saveButton , GameManager.instance.Save);
		this._AddButtonAction (this.pauseGUI.loadButton , GameManager.instance.GoLoadMode);
		this._AddButtonAction (this.pauseGUI.replaysButton , GameManager.instance.GoReplayMode);

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
