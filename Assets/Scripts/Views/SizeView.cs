using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.signal.impl;

namespace Views
{
	public class SizeView : MainView
	{
		[SerializeField] private Slider _sizeSlider;
		public Signal sizeSignal = new Signal();
		private float _sliderValue;

		protected override void Start()
		{
			base.Start();
			_sizeSlider.onValueChanged.AddListener(delegate {ChangeSize();});
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_sizeSlider.onValueChanged.RemoveListener(delegate {ChangeSize();});

		}

		private void ChangeSize()
		{
			_sliderValue = _sizeSlider.value;
			sizeSignal.Dispatch();
		}

		public float GetSliderValue()
		{
			return _sliderValue;
		}

	}
}
