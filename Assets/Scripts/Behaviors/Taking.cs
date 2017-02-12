using UnityEngine;
using System.Collections;


// TODO: Put change this behavior for the caracter
public class Taking : ABehavior {

	public override IEnumerator CoBehavior() {
		this.transform.parent.transform.parent = GameObject.FindObjectOfType <Character>().transform;
		this.Stop ();
		yield return true;
	}

	public override bool IsAvailable() {
		Droping component = this.GetComponent<Droping> ();
		return component && component.state == StatesManager.EBehavior.RUNNING;
	}
}