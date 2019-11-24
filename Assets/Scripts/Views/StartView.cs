using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.signal.impl;

namespace Views
{
	public class StartView : MainView
	{
		[SerializeField] private Button _startButton;
		public Signal startSignal = new Signal();

		protected override void Start()
		{
			base.Start();
			_startButton.onClick.AddListener(ClickStartButton);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_startButton.onClick.RemoveListener(ClickStartButton);
		}

		private void ClickStartButton()
		{
			startSignal.Dispatch();
		}

	}
}
