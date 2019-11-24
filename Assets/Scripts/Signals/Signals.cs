using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using strange.extensions.signal.api;
using strange.extensions.signal.impl;
using Views;

namespace Signals
{
	public class InitSignal : Signal{}
	public class StartSignal : Signal{}
	public class OpenMenuSignal :Signal<MainView>{}
	public class FillSignal :Signal{}
	public class SaveSignal :Signal{}
	public class BrushSignal :Signal<Draw>{}
	public class ColorSignal :Signal<Color>{}
	public class SizeSignal :Signal<float>{}
	public class ExitSignal : Signal{}
}