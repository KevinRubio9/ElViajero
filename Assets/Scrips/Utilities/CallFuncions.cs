using UnityEngine;

public class CallFuncions : MonoBehaviour
{

    public EnemyShooterLogic enemySL;

    public void CallShootCogollo()
    {
        enemySL.Shoot();
    }

    public void CallSound()
    {
        AudioManager.Instance.PlaySFX("Step Cogollo");
    }
}
