using System;
using UnityEngine;

public class AnimationInvoker : MonoBehaviour
{
    public Action AnimationEventInvoked;

    public void AnimationEvent()
    {
        AnimationEventInvoked?.Invoke();
    }
}
