using UnityEngine;

public class TackleState : StatesBase
{
    public TackleState(EnemyMoveController parameters) : base(parameters) { }
    public override void EnterState()
    {
      
        //controller.anim.CrossFade("Tackle", 0.1f);

    }
    public override void UpdateState()
    {
        if (controller.targetAgent == null) return;

        controller.currDistance = Vector3.Distance(controller.transform.position, controller.targetAgent.position);

        if (controller.currDistance <= controller.actionDistance * 0.5f)
        {
            PlayerController player = controller.targetAgent.GetComponent<PlayerController>();

            if (player != null)
            {
                player.Tackle(controller.transform, controller.tackleSpeed, 0.3f);
                controller.lastTackleTime = Time.time;

            }
        }
        if (controller.currDistance > controller.actionDistance * 2f)
        {
            Debug.Log("Player lejos, cambiando a patrulla");
            ExitState(controller.patrol);
        }
        else if (controller.currDistance <= controller.actionDistance)
        {
            Debug.Log("Cerca suficiente para empujar, cambiando a chase");
            ExitState(controller.Chase);
        }
    }
    public override void ExitState(StatesBase newState)
    {
        controller.ChangeStatus(newState);
        

    }


}
