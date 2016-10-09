using UnityEngine;
using System.Collections;

public class CameraMain : MonoBehaviour {

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	public float speedMovement = 1f;
	public float speedRotation = 5.0f;
	public Transform target;

	// Rotation
	//private float	_yMin = 0f;
	//private float	_yMax = 80f;

	// Zoom (3 types of zoom "fiedlofview, rotate and vector, vector") // Add the options in Preferences user and replace or move bool in config
	public float	speedFOV;
	public float	minFOV;
	public float	maxFOV;
	public bool		zoomFieldOfView;
	private bool 	zoomRotateAndVector = false; // Bug
	//private bool 	zoomVector = false; // Bug

	void Update () {
		if (Input.GetMouseButton(1)) {
			transform.LookAt(target);
			transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * speedRotation);
		}
	}

	void FixedUpdate () {
		float speed = Time.deltaTime * this.speedMovement;
		if (Input.GetKey (KeyCode.LeftArrow) && (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) || Input.mousePosition.x < 0 + 5) {
			this.transform.Translate (new Vector3 (-speed, 0, 0));
		} else if (Input.GetKey (KeyCode.RightArrow) && (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) || Input.mousePosition.x > Screen.width - 5) {
			this.transform.Translate (new Vector3 (speed, 0, 0));
		} else if (Input.GetKey (KeyCode.UpArrow) && (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) || Input.mousePosition.y > Screen.height - 5) {
			this.transform.Translate (target.forward * speed, Space.World);
		} else if (Input.GetKey (KeyCode.DownArrow) && (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) || Input.mousePosition.y < 0 + 5) {
			this.transform.Translate (target.forward * -speed, Space.World);
		} 
		ZoomType ();
		Vector3 v3 = transform.position;
		v3.x = Mathf.Clamp (v3.x, this.minX, this.maxX);
		v3.y = Mathf.Clamp (v3.y, this.minY, this.maxY);
		v3.z = Mathf.Clamp (v3.z, this.minY, this.maxY);
		transform.position = v3;
	}

	void ZoomType () {
		if (this.zoomFieldOfView) {
			ZoomFieldOfView ();
		} else {
			ZoomVector ();
		}
	}

	void ZoomFieldOfView () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && Camera.main.fieldOfView - this.speedFOV >= this.minFOV) {
			Camera.main.fieldOfView -= this.speedFOV;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0 && Camera.main.fieldOfView - this.speedFOV <= this.maxFOV) {
			Camera.main.fieldOfView += this.speedFOV;
		}
	}

	void ZoomVector () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.6f, transform.position.z + 0.2f);
			if (this.zoomRotateAndVector) {
				transform.Rotate (-2, 0, 0);
			}
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.6f, transform.position.z - 0.2f);
			if (this.zoomRotateAndVector) {
				transform.Rotate (2, 0, 0);
			}
		}
	}
}
