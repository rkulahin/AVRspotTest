using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using strange.extensions.command.impl;
using Signals;
using Managers;

namespace Commands
{
	public class StartCommand : Command
	{
		[Inject] public UIManager uIManager {get;set;}

		public override void Execute()
		{
			Debug.Log("Start");
			uIManager.startView.Hide(true);
			uIManager.inGameView.Hide(false);
		}

	}
}