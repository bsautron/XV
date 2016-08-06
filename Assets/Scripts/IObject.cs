using UnityEngine;
using System.Collections;

public interface IObject {

	public void Enable (); 
	public void Disbale ();
	public bool GetState ();
	// public float GetWeight ();
	// public float GetWidth ();
	// public float GetHeight ();
}