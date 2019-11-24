using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.signal.impl;

namespace Views
{
	public class BrushView : MainView
	{
		[SerializeField] private Button _circleButton;
		[SerializeField] private Button _squareButton;
		[SerializeField] private Button _triangleButton;
		public Signal circleSignal = new Signal();
		public Signal squareSignal = new Signal();
		public Signal triangleSignal = new Signal();

		protected override void Start()
		{
			base.Start();
			_circleButton.onClick.AddListener(ClickCircleButton);
			_squareButton.onClick.AddListener(ClickSquareButton);
			_triangleButton.onClick.AddListener(ClickTriangleButton);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_circleButton.onClick.RemoveListener(ClickCircleButton);
			_squareButton.onClick.RemoveListener(ClickSquareButton);
			_triangleButton.onClick.RemoveListener(ClickTriangleButton);
		}

		private void ClickCircleButton()
		{
			circleSignal.Dispatch();
		}

		private void ClickSquareButton()
		{
			squareSignal.Dispatch();
		}

		private void ClickTriangleButton()
		{
			triangleSignal.Dispatch();
		}
	}
}
