using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Actor))]
public class DoNothingAction : Action {
	override public ActionResult Perform()
	{
		state = ActionState.FINISHED;
		Debug.Log("Do nothing");
		return ActionResult.SUCCESS;
	}
}
