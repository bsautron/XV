using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager : Singleton<CameraManager> {

	public List<Camera> cameras { 
		get { return this.cameras; }
		set { this.cameras = value; }
	}

	private Camera _currentCamera;

	void Start() {
		this._currentCamera = Camera.main;
		Camera[] tmpCameras;
		tmpCameras = GameObject.FindObjectsOfType<Camera> ();
		for (int i = 0; i < tmpCameras.Length; i++) {
			cameras.Add(tmpCameras[i]);
		}
	}

	void NextCamera () {
		this._currentCamera.depth = -1;
	}
}
