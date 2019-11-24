using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using Signals;
using Managers;
using Views;
using Mediators;
using Commands;

public class MainContext : MVCSContext
{
	private UIManager _uIManager;

	public MainContext(UIManager uIManager, MonoBehaviour context)
						:base(context, ContextStartupFlags.MANUAL_MAPPING |
										ContextStartupFlags.MANUAL_LAUNCH)
	{
		
		_uIManager = uIManager;
	}

	public override void Launch()
	{
		base.Launch();
		Signal initSignal = injectionBinder.GetInstance<InitSignal>();
		initSignal.Dispatch();
	}
	protected override void addCoreComponents()
	{
		base.addCoreComponents();
		injectionBinder.Unbind<ICommandBinder>();
		injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
	}
	protected override void mapBindings()
	{
		base.mapBindings();
		CommandBinding();
		InjectionsBinding();
		ViewBinding();
	}
	private void CommandBinding()
	{
		commandBinder.Bind<InitSignal>().To<InitCommand>().Once();
		commandBinder.Bind<StartSignal>().To<StartCommand>();
		commandBinder.Bind<OpenMenuSignal>().To<OpenMenuCommand>();
		commandBinder.Bind<BrushSignal>().To<BrushCommand>();
		commandBinder.Bind<ColorSignal>().To<ColorCommand>();
		commandBinder.Bind<SizeSignal>().To<SizeCommand>();
		commandBinder.Bind<FillSignal>().To<FillCommand>();
		commandBinder.Bind<SaveSignal>().To<SaveCommand>();
		commandBinder.Bind<ExitSignal>().To<ExitCommand>();
	}
	private void InjectionsBinding()
	{
		injectionBinder.Bind<UIManager>().To(_uIManager);
	}
	private void ViewBinding()
	{
		mediationBinder.Bind<StartView>().To<StartMediator>();
		mediationBinder.Bind<InGameView>().To<InGameMediator>();
		mediationBinder.Bind<MenuView>().To<MenuMediator>();
		mediationBinder.Bind<BrushView>().To<BrushMediator>();
		mediationBinder.Bind<ColorView>().To<ColorMediator>();
		mediationBinder.Bind<SizeView>().To<SizeMediator>();
	}
}