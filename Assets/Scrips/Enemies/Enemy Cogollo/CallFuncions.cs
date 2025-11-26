using UnityEngine;

public class CallFuncions : MonoBehaviour
{

    public EnemyShooterLogic enemySL;
    [SerializeField] float minHearingRange;
    [SerializeField] float maxHearingRange;

    public void CallShootCogollo()
    {
        AudioManager.Instance.PlaySFX3D("Shoot Cogollo", transform,minHearingRange,maxHearingRange);
        enemySL.Shoot();
    }

    public void CallSound()
    {
        AudioManager.Instance.PlaySFX3D("Step Cogollo",transform,minHearingRange,maxHearingRange);
    }
}
