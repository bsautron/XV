using UnityEngine;
using System.Collections;

/* 
 * IState
 * This interface enable the State for your object
 * 
 * Example:
 * eunm EState {ES1, ES2}
 * public class Example : IState<EState> {}
 * 
 * And then:
 * example.state == ES1
 * ...
 */

public interface IState<T> {
	T	state { get; }
}
