using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;
using Managers;
public class Bootstrap : ContextView
{
	[SerializeField] private UIManager _uiManager;
	private MainContext _context;

    private void Awake()
	{
		_context = new MainContext(_uiManager, this);
		_context.Start();
		_context.Launch();
	}
}