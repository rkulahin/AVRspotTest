using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using strange.extensions.command.impl;
using Signals;
using Managers;

namespace Commands
{
	public class SaveCommand : Command
	{
		[Inject] public UIManager uIManager {get;set;}

		public override void Execute()
		{
			Debug.Log("Save");
			uIManager.paintView.Screenshot();
		}

	}
}