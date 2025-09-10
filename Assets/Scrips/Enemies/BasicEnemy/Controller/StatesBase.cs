using UnityEngine;
using System.Collections.Generic;

public abstract class StatesBase
{
    public StatesBase(EnemyMoveController parameters)
    {
        controller = parameters;
    }
    protected EnemyMoveController controller;

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState(StatesBase newState);
}