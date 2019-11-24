using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.signal.impl;

namespace Views
{
	public class ColorView : MainView
	{
		[SerializeField] private Button _blackButton;
		[SerializeField] private Button _whiteButton;
		[SerializeField] private Button _greenButton;
		[SerializeField] private Button _blueButton;
		[SerializeField] private Button _yellowButton;
		[SerializeField] private Button _redButton;

		public Signal blackSignal = new Signal();
		public Signal whiteSignal = new Signal();
		public Signal greenSignal = new Signal();
		public Signal blueSignal = new Signal();
		public Signal yellowSignal = new Signal();
		public Signal redSignal = new Signal();

		protected override void Start()
		{
			base.Start();
			_blackButton.onClick.AddListener(ClickBlackButton);
			_whiteButton.onClick.AddListener(ClickWhiteButton);
			_greenButton.onClick.AddListener(ClickGreenButton);
			_blueButton.onClick.AddListener(ClickBlueButton);
			_yellowButton.onClick.AddListener(ClickYellowButton);
			_redButton.onClick.AddListener(ClickRedButton);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_blackButton.onClick.RemoveListener(ClickBlackButton);
			_whiteButton.onClick.RemoveListener(ClickWhiteButton);
			_greenButton.onClick.RemoveListener(ClickGreenButton);
			_blueButton.onClick.RemoveListener(ClickBlueButton);
			_yellowButton.onClick.RemoveListener(ClickYellowButton);
			_redButton.onClick.RemoveListener(ClickRedButton);
		}

		private void ClickBlackButton()
		{
			blackSignal.Dispatch();
		}

		private void ClickWhiteButton()
		{
			whiteSignal.Dispatch();
		}

		private void ClickGreenButton()
		{
			greenSignal.Dispatch();
		}
		
		private void ClickBlueButton()
		{
			blueSignal.Dispatch();
		}
		
		private void ClickYellowButton()
		{
			yellowSignal.Dispatch();
		}
		
		private void ClickRedButton()
		{
			redSignal.Dispatch();
		}
	}
}
