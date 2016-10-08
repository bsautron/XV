using UnityEngine;
using System.Collections;

/*
 * Allow a GameObject datailable with a short name and a description
 * You must implement this 2 getter
 * 
 * An extern object can read the shortname like:
 * object.shortName
 */

public interface IDetailable {
	string		shortName	{ get; }
	string		description { get; }
}
