using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Door/Decisions/Player Nearby")]
public class PlayerNearbyDecision : Decision
{
    public float distance = 3f;
    public string playerTag = "Player";

    public override bool Decide(Controller controller)
    {
        var player = GameObject.FindGameObjectWithTag(playerTag);
        if (!player) return false;
        return Vector3.Distance(controller.transform.position, player.transform.position) <= distance;
    }
}
