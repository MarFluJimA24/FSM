using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Door/Decisions/Door Fully Closed")]
public class DoorFullyClosedDecision : Decision
{
    public override bool Decide(Controller controller)
    {
        var dc = controller.GetComponent<DoorController>();
        return dc != null && dc.IsFullyClosed();
    }
}
