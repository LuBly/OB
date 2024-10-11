using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour
{
    private Player player;
    public void Init()
    {
        player = GameManager.Instance.Player;
    }
    public void CheckTarget()
    {
        player.AttackHandler.CheckTarget();
    }
}