using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.signal.impl;

namespace Views
{
	public class MenuView : MainView
	{
		[SerializeField] private Button _brushButton;
		[SerializeField] private Button _colorButton;
		[SerializeField] private Button _sizeButton;
		[SerializeField] private Button _fillButton;
		[SerializeField] private Button _saveButton;
		public Signal brushSignal = new Signal();
		public Signal colorSignal = new Signal();
		public Signal sizeSignal = new Signal();
		public Signal fillSignal = new Signal();
		public Signal saveSignal = new Signal();

		protected override void Start()
		{
			base.Start();
			_brushButton.onClick.AddListener(ClickBrushButton);
			_colorButton.onClick.AddListener(ClickColorButton);
			_sizeButton.onClick.AddListener(ClickSizeButton);
			_fillButton.onClick.AddListener(ClickFillButton);
			_saveButton.onClick.AddListener(ClickSaveButton);

		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_brushButton.onClick.RemoveListener(ClickBrushButton);
			_colorButton.onClick.RemoveListener(ClickColorButton);
			_sizeButton.onClick.RemoveListener(ClickSizeButton);
			_fillButton.onClick.RemoveListener(ClickFillButton);
			_saveButton.onClick.RemoveListener(ClickSaveButton);
		}

		private void ClickBrushButton()
		{
			brushSignal.Dispatch();
		}

		private void ClickColorButton()
		{
			colorSignal.Dispatch();
		}	

		private void ClickSizeButton()
		{
			sizeSignal.Dispatch();
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
