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
	public class OpenMenuCommand : Command
	{
		[Inject] public UIManager uIManager {get;set;}
		[Inject] public MainView mainView {get;set;}
		public override void Execute()
		{
			Debug.Log("Open/Hide Menu");
			mainView.Hide();
		}

	}
}