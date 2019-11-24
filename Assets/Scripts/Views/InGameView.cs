using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.signal.impl;
using Managers;

namespace Views
{
	public class InGameView : MainView
	{
		[SerializeField] private Button _menuButton;
		public Signal menuSignal = new Signal();

		protected override void Start()
		{
			base.Start();
			_menuButton.onClick.AddListener(OpenMenuButton);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_menuButton.onClick.RemoveListener(OpenMenuButton);
		}

		private void OpenMenuButton()
		{
			menuSignal.Dispatch();
		}

	}
}
