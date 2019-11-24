using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using strange.extensions.command.impl;
using Signals;
using Managers;

namespace Commands
{
	public class InitCommand : Command
	{
		[Inject] public UIManager uIManager {get;set;}

		public override void Execute()
		{
			Debug.Log("Init");
			uIManager.startView.Hide(false);
		}

	}
}