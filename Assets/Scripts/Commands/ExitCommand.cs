using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using strange.extensions.command.impl;
using Signals;
using Managers;

namespace Commands
{
	public class ExitCommand : Command
	{
		[Inject] public UIManager uIManager {get;set;}

		public override void Execute()
		{
			uIManager.startView.Hide(true);
			Debug.Log("Exit");
			Application.Quit();
		}

	}
}