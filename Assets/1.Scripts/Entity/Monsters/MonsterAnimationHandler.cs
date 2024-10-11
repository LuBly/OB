using UnityEngine;

public class MonsterAnimationHandler : MonoBehaviour
{
    private Monster monster;
    public Animator Animator { get; private set; }

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
    }

    public void Init(Monster monster)
    {
        this.monster = monster;
        monster.HealthSystem.OnHit += AnimHit;
        monster.HealthSystem.OnDie += AnimDie;
    }

    private void AnimHit(float damage)
    {
        Animator.SetTrigger(monster.AnimationData.HitParameterHash);
    }

    private void AnimDie()
    {
        Animator.SetTrigger(monster.AnimationData.DieParameterHash);
        monster.HealthSystem.OnHit -= AnimHit;
        monster.HealthSystem.OnDie -= AnimDie;
    }

}