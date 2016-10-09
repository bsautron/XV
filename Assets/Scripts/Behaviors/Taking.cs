using UnityEngine;
using System.Collections;

public class Taking : ABehavior {

	public override IEnumerator CoBehavior() {
		this.transform.parent = this.target.transform;
		yield return true;
	}

	public override bool IsAvailable() {
		Droping component = this.GetComponent<Droping> ();
		return component && component.state == StatesManager.EBehavior.RUNNING;
	}
}