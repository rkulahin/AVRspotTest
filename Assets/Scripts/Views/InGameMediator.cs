using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.mediation.api;
using Signals;
using Views;
using Managers;

namespace Mediators
{
	public class InGameMediator : Mediator
	{
		[Inject] public UIManager uIManager {get;set;}
		[Inject] public InGameView inGameView {get;set;}
		[Inject] public OpenMenuSignal menuSignal {get;set;}
		
		public override void OnRegister()
		{
			inGameView.menuSignal.AddListener(OpenMenuButton);
		}

		public override void OnRemove()
		{
			inGameView.menuSignal.RemoveListener(OpenMenuButton);
		}

		private void OpenMenuButton()
		{
			menuSignal.Dispatch(uIManager.menuView);
		}
	}
}
