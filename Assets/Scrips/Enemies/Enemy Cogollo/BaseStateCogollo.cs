using UnityEngine;

public abstract class BaseStateCogollo 
{
    protected EnemyShooterLogic controller;

    public BaseStateCogollo(EnemyShooterLogic controllerParameter)
    {
        controller = controllerParameter;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState(BaseStateCogollo newState);
}
