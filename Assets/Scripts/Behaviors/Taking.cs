using UnityEngine;
using System.Collections;

public class Taking : ABehavior {

	public Character caracter;

	public override IEnumerator CoBehavior() {
		this.transform.parent = caracter.transform;
		yield return true;
	}

	public override bool IsAvailable() {
		Droping component = this.GetComponent<Droping> ();

		return component && component.state == StatesManager.EBehavior.RUNNING;
	}
}