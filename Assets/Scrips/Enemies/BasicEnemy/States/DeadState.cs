using System.Security.Cryptography;
using UnityEngine;

public class DeadState : StatesBase
{
    public DeadState(EnemyMoveController parameters) : base(parameters) { }
    private float deathTimer = 1f;
    private float currentTimer;

    public override void EnterState()
    {
        Debug.Log("Hombre seta ha kiliado");
        controller.anim.CrossFade("Dead",0.1f);
        currentTimer = deathTimer;
    }
    public override void UpdateState()
    {
        if (currentTimer <= 0f)
        {
            controller.life.Dead();
        }
        currentTimer -= Time.deltaTime;
    }
    public override void ExitState(StatesBase newState)
    {

        controller.anim.SetBool("isDead", false);

    }
}
