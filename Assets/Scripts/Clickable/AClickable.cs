using UnityEngine;
using System.Collections;

public abstract class AClickable : MonoBehaviour {

	[SerializeField] protected bool _rightCLick = false;

	protected bool _active = false;

	public abstract void OnMouseOver ();
	public abstract void Activate ();
	public abstract void Desactivate ();

	void Awake(){
		ClickManager.instance.AddAClickable (this);
	}
}
