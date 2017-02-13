using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : Singleton<GUIManager>  {

	public GameObject userGUI;

	[HideInInspector] public GameObject playButton;
	[HideInInspector] public GameObject pauseButton;
	[HideInInspector] public GameObject pausePanel;

	public void Start() {
		this.playButton = this.userGUI.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
		this.playButton.GetComponent<Button> ().onClick.AddListener (() => GameManager.instance.Resume ());
		this.pauseButton = this.userGUI.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
		this.pauseButton.GetComponent<Button> ().onClick.AddListener (() => GameManager.instance.Pause ());
		this.pausePanel = this.userGUI.transform.GetChild (1).gameObject;
	}

	public void DisablePanel(GameObject go) {
		go.SetActive (false);
	}

	public void EnablePanel(GameObject go) {
		go.SetActive (true);
	}
}
