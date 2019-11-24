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
	public class ColorMediator : Mediator
	{
		[Inject] public ColorView colorView {get;set;}
		[Inject] public ColorSignal blackSignal {get;set;}
		[Inject] public ColorSignal whiteSignal {get;set;}
		[Inject] public ColorSignal greenSignal {get;set;}
		[Inject] public ColorSignal blueSignal {get;set;}
		[Inject] public ColorSignal yellowSignal {get;set;}
		[Inject] public ColorSignal redSignal {get;set;}
		
		public override void OnRegister()
		{
			colorView.blackSignal.AddListener(ClickBlackButton);
			colorView.whiteSignal.AddListener(ClickWhiteButton);
			colorView.greenSignal.AddListener(ClickGreenButton);
			colorView.blueSignal.AddListener(ClickBlueButton);
			colorView.yellowSignal.AddListener(ClickYellowButton);
			colorView.redSignal.AddListener(ClickRedButton);
		}

		public override void OnRemove()
		{
			colorView.blackSignal.RemoveListener(ClickBlackButton);
			colorView.whiteSignal.RemoveListener(ClickWhiteButton);
			colorView.greenSignal.RemoveListener(ClickGreenButton);
			colorView.blueSignal.RemoveListener(ClickBlueButton);
			colorView.yellowSignal.RemoveListener(ClickYellowButton);
			colorView.redSignal.RemoveListener(ClickRedButton);
		}

		private void ClickBlackButton()
		{
			blackSignal.Dispatch(Color.black);
		}

		private void ClickWhiteButton()
		{
			whiteSignal.Dispatch(Color.white);
		}

		private void ClickGreenButton()
		{
			greenSignal.Dispatch(Color.green);
		}
		
		private void ClickBlueButton()
		{
			blueSignal.Dispatch(Color.blue);
		}
		
		private void ClickYellowButton()
		{
			yellowSignal.Dispatch(Color.yellow);
		}
		
		private void ClickRedButton()
		{
			redSignal.Dispatch(Color.red);
		}
	}
}
