using UnityEngine;

public class ShootStateCogollo : BaseStateCogollo
{
    public ShootStateCogollo(EnemyShooterLogic controllerParameter) : base(controllerParameter) { }
    float time;
    public override void EnterState()
    {

        controller.agent.SetDestination(controller.transform.position);
        controller.agent.updateRotation = false;
        controller.anim.CrossFade("Attack", 0.1f);

    }
    public override void UpdateState()
    {
        controller.LookTarget();
        if (controller.playerInZone && Time.time >= controller.rateTimeShoot)
        {
            controller.rateTimeShoot = Time.time + controller.fireRate;
            controller.Shoot();
        }
        if (!controller.playerDetected)
        {
            ExitState(controller.patrol);
        }
    }
    public override void ExitState(BaseStateCogollo newState)
    {
        controller.ChangeState(newState);
    }
}


