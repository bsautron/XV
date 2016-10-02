using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//public class stackInstruction : MonoBehaviour {
//
//	private bool			_moveOn;
//	private Queue<Instruction> _stackInstruction = new Queue<Instruction>();
//
//	// Use this for initialization
//	void Start () {
//		this._moveOn = false;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		this.CheckStack();
//	}
//
//	public void CheckStack() {
//		Instruction nextInstruction;
//		
//		if (_stackInstruction.Count > 0) {
//			nextInstruction = _stackInstruction.Peek ();
//			if (nextInstruction.checkIfEndOfCommand ()) {
//				_stackInstruction.Dequeue ();
//			} else {
//				GetComponent<Instruction>().launchNextInstruction ();
//			}
//		}
//	}
//
//	public void SetOrder(int order, Vector3 position, int levelOrder, GameObject target) {
//		if (levelOrder <= GetComponent<Character>().levelOfCharacter) {
//			_stackInstruction.Enqueue (new Instruction (order, position, this, target));
//		} else {
//			Debug.Log("You Don't have the capacicity to act");
//		}
//	}
//}
