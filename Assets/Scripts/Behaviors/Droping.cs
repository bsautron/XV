using UnityEngine;
using System.Collections;

public class Droping : ABehavior {
	public override bool CheckIfPossible() {
		Taking component = this.GetComponent<Taking> ();

		return component && component.state == StatesManager.EBehavior.RUNNING;
	}

	public override IEnumerator CoBehavior() {
		yield return true;
	}
}
