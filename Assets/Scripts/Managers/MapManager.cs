using UnityEngine;
using System.Collections;

public class MapManager : Singleton<MapManager> {
	[SerializeField] private float _pad = 1f;

	public float pad { get { return this._pad; } }

	public void Update() {
		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100f)) {
				Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), hit.point);
			}
		}
	}
}
