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
	public class SizeMediator : Mediator
	{
		[Inject] public SizeView sizeView {get;set;}
		[Inject] public SizeSignal sizeSignal {get;set;}
		
		public override void OnRegister()
		{
			sizeView.sizeSignal.AddListener(ChangeSize);
		}

		public override void OnRemove()
		{
			sizeView.sizeSignal.RemoveListener(ChangeSize);
		}

		private void ChangeSize()
		{
			sizeSignal.Dispatch(sizeView.GetSliderValue());
		}
	}
}
