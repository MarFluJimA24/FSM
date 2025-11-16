using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Door/Decisions/Door Fully Open")]
public class DoorFullyOpenDecision : Decision
{
    public override bool Decide(Controller controller)
    {
        var dc = controller.GetComponent<DoorController>();
        return dc != null && dc.IsFullyOpen();
    }
}
