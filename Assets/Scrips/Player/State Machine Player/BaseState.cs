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
    public virtual void FixedUpdateState()
    {

    }
    public virtual void AnimationEvent()
    {
    }
    public abstract void ExitState(BaseState newState);
}
