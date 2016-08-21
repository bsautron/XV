using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIObject : MonoBehaviour {

	private AObject	_aObject;
	private int[] 	_posButtonX = new int[8];
	private int[] 	_posButtonY = new int[8];
	private int		_widhtButton = 150;
	private int		_heightButton = 50;

	void Start () {
		_aObject = this.GetComponent<AObject> ();

		int screenCenterX = Screen.width / 2 - _widhtButton / 2;
		int screenCenterY = Screen.height / 2 - _heightButton / 2;


		//        0
		//     1     2
		//  3           4
		//     5     6
		//        7

		_posButtonX [0] = screenCenterX;
		_posButtonY [0] = screenCenterY - 200;

		_posButtonX [1] = screenCenterX - 100;
		_posButtonY [1] = screenCenterY - 100;

		_posButtonX [2] = screenCenterX + 100;
		_posButtonY [2] = screenCenterY - 100;

		_posButtonX [3] = screenCenterX - 200;
		_posButtonY [3] = screenCenterY;

		_posButtonX [4] = screenCenterX + 200;
		_posButtonY [4] = screenCenterY;

		_posButtonX [5] = screenCenterX - 100;
		_posButtonY [5] = screenCenterY + 100;

		_posButtonX [6] = screenCenterX + 100;
		_posButtonY [6] = screenCenterY + 100;

		_posButtonX [7] = screenCenterX;
		_posButtonY [7] = screenCenterY + 200;
	}

	void OnGUI () {
		int index = 0;
		foreach (string key in _aObject.dicBehavior.Keys) {
			if (GUI.Button(new Rect(_posButtonX[index], _posButtonY[index], _widhtButton, _heightButton), key))
				_aObject.dicBehavior[key].Play();
			index++;
		}
	}
}
