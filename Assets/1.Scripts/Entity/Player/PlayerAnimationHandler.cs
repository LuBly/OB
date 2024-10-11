using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Player player;
    private Animator animator;

    public void Init()
    {
        animator = GetComponentInChildren<Animator>();
        this.player = GameManager.Instance.Player;
        player.AttackHandler.OnAttack += ActiveAttack;
    }

    // 최초 Init시에만 등록 (1회성)
    private void ActiveAttack()
    {
        animator.SetTrigger(player.AnimationData.AttackParameterName);
    }

}