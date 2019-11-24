using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.mediation.api;
using Signals;
using Views;

namespace Mediators
{
	public class StartMediator : Mediator
	{
		[Inject] public StartView startView {get;set;}
		[Inject] public StartSignal startSignal {get;set;}
		
		public override void OnRegister()
		{
			startView.startSignal.AddListener(ClickStartButton);
		}

		public override void OnRemove()
		{
			startView.startSignal.RemoveListener(ClickStartButton);
		}

		private void ClickStartButton()
		{
			startSignal.Dispatch();
		}
	}
}
