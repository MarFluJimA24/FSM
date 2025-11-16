using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Door/Actions/Open")]
public class DoorOpenAction : Action
{
    public override void Act(Controller controller)
    {
        var dc = controller.GetComponent<DoorController>();
        if (dc) dc.OpenStep();
    }
}
