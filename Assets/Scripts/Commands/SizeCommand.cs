using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using strange.extensions.command.impl;
using Signals;
using Managers;

namespace Commands
{
	public class SizeCommand : Command
	{
		[Inject] public UIManager uIManager {get;set;}
		[Inject] public float newSize {get;set;}
		public override void Execute()
		{
			Debug.Log("newSize");
			uIManager.paintView.SetRange((int)newSize);
		}

	}
}