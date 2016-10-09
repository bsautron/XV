using UnityEngine;
using System.Collections;

public class MapManager : Singleton<MapManager> {
	[SerializeField] private float _pad = 0.2f;

	public float pad { get { return this._pad; } }
}
