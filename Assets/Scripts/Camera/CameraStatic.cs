using UnityEngine;
using System.Collections;

public class CameraStatic : MonoBehaviour {

	private float	_rotationY = 0;
	private bool	_direction = true;

	void Start () {
		this._rotationY = this.transform.transform.eulerAngles.y;
	}

	// Update is called once per frame
	void Update () {
		if (this._direction && transform.eulerAngles.y < this._rotationY + 30f) {
			transform.Rotate (new Vector3 (0, 0.1f, 0));
		} else {
			this._direction = false;
		}
		if (!this._direction && transform.eulerAngles.y > this._rotationY - 30f) {
			transform.Rotate (new Vector3 (0, -0.1f, 0));
		} else {
			this._direction = true;
		}
	}
}
