using UnityEngine;
using System.Collections;

public class Taking : ABehavior {
	public override bool CheckIfPossible() {
		Droping component = this.GetComponent<Droping> ();
		
		return component && component.state == StatesManager.EBehavior.RUNNING;
	}

	public override IEnumerator CoBehavior() {
		yield return true;
	}

}
