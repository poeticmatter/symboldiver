using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLoop : MonoBehaviour {


	public static GameLoop instance = null;
	void Awake()
	{
		if (instance == null) instance = this;
		else Debug.LogError("More than one GameLoop");
	}


	private List<Actor> actors = new List<Actor>();
	private int currentActor = 0;
	private Action currentAction = null;

	public void RegisterActor(Actor actor)
	{
		actors.Add(actor);
	}

	public void UnregisterActor(Actor actor)
	{
		int index = actors.IndexOf(actor);
		if (index < currentActor) currentActor--;
		actors.RemoveAt(index);
	}

	private void IncrementCurrentActor()
	{
		currentActor = (currentActor + 1) % actors.Count;
	}

	private Actor GetCurrentActor()
	{
		return actors[currentActor];
	}
	
	void Update () {
		Loop();
	}

	private void Loop()
	{
		if (currentAction != null)
		{
			if (currentAction.state == Action.ActionState.EXECUTING)
			{
				return;
			}
			ResetCurrentAction();
			IncrementCurrentActor();
		}
		PerformAction();
	}

	private void PerformAction ()
	{
		currentAction = GetCurrentActor().GetAction();
		if (currentAction == null) return; //Should only happen for player actor
		bool loopAction = true;
		while (loopAction)
		{
			ActionResult result = currentAction.Perform();
			if (result.Succeeded)
			{
				loopAction = false;
			}
			else
			{
				if (currentAction == result.Alternate)
				{
					Debug.Log("alternate should be a different action");
					break;
				}
				currentAction = result.Alternate;
			}
		}
	}

	private void ResetCurrentAction()
	{
		currentAction.state = Action.ActionState.IDLE;
	}
}
