using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickManager : Singleton<ClickManager> {

	public GameObject[] allGO;

	private int _idCurrentEvent = -1;
	private List<AClickable> _listAClickable = new List<AClickable>();

	public void ManageEvent(AClickable newEvent) {
		int tmpId = -1;
		for (int i = 0; i < _listAClickable.Count; i++) {
			if (_listAClickable [i] == newEvent) {
				Debug.Log (newEvent.gameObject.name);
				tmpId = i;
			}
		}
		if (tmpId != _idCurrentEvent) {
			if (_idCurrentEvent != -1)
				_listAClickable [_idCurrentEvent].Desactivate ();
			_idCurrentEvent = tmpId;
			_listAClickable [_idCurrentEvent].Activate ();
		}
	}

	public void AddAClickable(AClickable newElem) {
		this._listAClickable.Add(newElem);
	}
}
