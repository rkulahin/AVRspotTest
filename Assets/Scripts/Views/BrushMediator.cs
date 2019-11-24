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
	public class BrushMediator : Mediator
	{
		[Inject] public BrushView brushView {get;set;}
		[Inject] public BrushSignal circleSignal {get;set;}
		[Inject] public BrushSignal squareSignal {get;set;}
		[Inject] public BrushSignal triangleSignal {get;set;}
		
		public override void OnRegister()
		{
			brushView.circleSignal.AddListener(ClickCircleButton);
			brushView.squareSignal.AddListener(ClickSquareButton);
			brushView.triangleSignal.AddListener(ClickTriangleButton);
		}

		public override void OnRemove()
		{
			brushView.circleSignal.RemoveListener(ClickCircleButton);
			brushView.squareSignal.RemoveListener(ClickSquareButton);
			brushView.triangleSignal.RemoveListener(ClickTriangleButton);
		}

		private void ClickCircleButton()
		{
			circleSignal.Dispatch(new CircleDraw());
			Debug.Log("Draw Circle");

		}
		
		private void ClickSquareButton()
		{
			squareSignal.Dispatch(new SquareDraw());
			Debug.Log("Draw Square");
		}	

		private void ClickTriangleButton()
		{
			triangleSignal.Dispatch(new TriangleDraw());
			Debug.Log("Draw Triangle");
		}
	}
}
