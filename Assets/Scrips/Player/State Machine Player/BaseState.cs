using UnityEngine;

public abstract class BaseState
{
    protected PlayerController controller;

    public BaseState(PlayerController controllerParameter)
    {
        controller = controllerParameter;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState(BaseState newState);
}
