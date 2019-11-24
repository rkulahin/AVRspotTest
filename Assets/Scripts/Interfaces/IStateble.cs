using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

namespace Interfaces
{
	public interface IStateble
	{
		void ChangeState(State newState);
	}
}