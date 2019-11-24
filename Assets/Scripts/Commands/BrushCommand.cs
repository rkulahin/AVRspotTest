using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using strange.extensions.command.impl;
using Signals;
using Managers;

namespace Commands
{
	public class BrushCommand : Command
	{
		[Inject] public UIManager uIManager {get;set;}
		[Inject] public Draw newBrush {get;set;}
		public override void Execute()
		{
			Debug.Log("newBrush");
			uIManager.paintView.SetBrush(newBrush);
		}

	}
}