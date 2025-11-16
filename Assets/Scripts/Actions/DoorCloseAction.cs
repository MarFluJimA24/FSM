using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Door/Actions/Close")]
public class DoorCloseAction : Action
{
    public override void Act(Controller controller)
    {
        var dc = controller.GetComponent<DoorController>();
        if (dc) dc.CloseStep();
    }
}
