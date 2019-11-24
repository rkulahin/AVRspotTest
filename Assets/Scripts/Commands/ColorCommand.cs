using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using strange.extensions.command.impl;
using Signals;
using Managers;

namespace Commands
{
	public class ColorCommand : Command
	{
		[Inject] public UIManager uIManager {get;set;}
		[Inject] public Color newColor {get;set;}
		public override void Execute()
		{
			Debug.Log("newColor");
			uIManager.paintView.SetColor(newColor);
		}

	}
}