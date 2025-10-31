using UnityEngine;

public class CallFuntionsHongo : MonoBehaviour
{
    [SerializeField] string soundStep;
    [SerializeField] float minHearingRange;
    [SerializeField] float maxHearingRange;
    public void CallSoundStep()
    {
        AudioManager.Instance.PlaySFX3D(soundStep, transform,minHearingRange,maxHearingRange );
    }
}
