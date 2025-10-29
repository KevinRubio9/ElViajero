using UnityEngine;

public class CallFuncions : MonoBehaviour
{

    public EnemyShooterLogic enemySL;
    [SerializeField] float distanceSound;

    public void CallShootCogollo()
    {
        enemySL.Shoot();
    }

    public void CallSound()
    {
        AudioManager.Instance.PlaySFX3D("Step Cogollo",transform,distanceSound);
    }
}
