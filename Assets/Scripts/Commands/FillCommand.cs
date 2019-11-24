using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using strange.extensions.command.impl;
using Signals;
using Managers;
using Views;

namespace Commands
{
	public class FillCommand : Command
	{
		[Inject] public UIManager uIManager {get;set;}

		public override void Execute()
		{
			Debug.Log("FILL");
			uIManager.paintView.FillPaper();
		}

	}
}