using UnityEngine;
using System.Collections;
using System.Threading;

public class Booting : ABehavior {
	
	[SerializeField] private string _shortName = "Booting";
	[SerializeField] private string _description = "This is the starting process for a machine";

	public float timeBooting = 2f;
	public float detaTimeLog = 0.2f;
	
	public override IEnumerator CoBehavior() {
		for (float i = 0f; i < this.timeBooting ; i += this.detaTimeLog) {
			Debug.Log ("Loading: " + ((i * 100) / this.timeBooting)  + "%");
			yield return new WaitForSeconds(this.detaTimeLog);
		}

		Debug.Log ("Loading: 100%");
		this.Stop();
	}
}
