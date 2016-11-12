using UnityEngine;
using System.Collections;

public class Droping : ABehavior {

	public override IEnumerator CoBehavior() {
		this.transform.parent.transform.parent = null;
		this.Stop ();
		yield return true;
	}

	public override bool IsAvailable() {
		Taking component = this.GetComponent<Taking> ();
		return component && component.state == StatesManager.EBehavior.RUNNING;
	}

}
