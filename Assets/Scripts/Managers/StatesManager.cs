using UnityEngine;
using System.Collections;

public class StatesManager : Singleton<StatesManager> {

	/* List all different State available Here */
	public enum EBehavior {STANDBY, RUNNING};
	public enum EObject {NOTSELECTED, SELECTED, NOTAVAILABLE};
	public enum EGame {STOP, PLAY, PAUSE, PAUSEPLUS};
	public enum EInstruction {STANDBY,RUNNING,FINISH};
}
