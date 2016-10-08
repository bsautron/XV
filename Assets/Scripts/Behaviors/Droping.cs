using UnityEngine;
using System.Collections;

public class Droping : ABehavior {

	public Character caractere;

	public override IEnumerator CoBehavior() {
		yield return true;
	}

	public override bool IsAvailable() {
		Taking component = this.GetComponent<Taking> ();
		return component && component.state == StatesManager.EBehavior.RUNNING;
	}

}
