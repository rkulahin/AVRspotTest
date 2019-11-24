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
	public class MenuMediator : Mediator
	{
		[Inject] public UIManager uIManager {get;set;}
		[Inject] public MenuView menuView {get;set;}
		[Inject] public OpenMenuSignal brushSignal {get;set;}
		[Inject] public OpenMenuSignal colorSignal {get;set;}
		[Inject] public OpenMenuSignal sizeSignal {get;set;}
		[Inject] public FillSignal fillSignal {get;set;}
		[Inject] public SaveSignal saveSignal {get;set;}
		
		public override void OnRegister()
		{
			menuView.brushSignal.AddListener(ClickBrushButton);
			menuView.colorSignal.AddListener(ClickColorButton);
			menuView.sizeSignal.AddListener(ClickSizeButton);
			menuView.fillSignal.AddListener(ClickFillButton);
			menuView.saveSignal.AddListener(ClickSaveButton);
		}

		public override void OnRemove()
		{
			menuView.brushSignal.RemoveListener(ClickBrushButton);
			menuView.colorSignal.RemoveListener(ClickColorButton);
			menuView.sizeSignal.RemoveListener(ClickSizeButton);
			menuView.fillSignal.RemoveListener(ClickFillButton);
			menuView.saveSignal.RemoveListener(ClickSaveButton);

		}

		private void ClickBrushButton()
		{
			brushSignal.Dispatch(uIManager.brushView);
		}
		
		private void ClickColorButton()
		{
			colorSignal.Dispatch(uIManager.colorView);
		}	

		private void ClickSizeButton()
		{
			sizeSignal.Dispatch(uIManager.sizeView);
		}

		private void ClickFillButton()
		{
			fillSignal.Dispatch();
		}

		private void ClickSaveButton()
		{
			saveSignal.Dispatch();
		}
	}
}
