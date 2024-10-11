using System;
using System.Collections;
using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{
    // 적이 범위 내에 있으면 공격 실행
    // 공격 = Animation + Projectile 발사

    // 필요한 함수
    // 1. 적 탐지
    // 2. 공격 실행
    private Coroutine ScanTarget;
    private WaitUntil delay;
    private bool isAttack;
    private Player player;
    private Projectile_Arrow projectile;

    //Projectile 발사, 애니매이션 실행
    public event Action OnAttack;
    
    public void Init()
    {
        this.player = GameManager.Instance.Player;
        isAttack = false;
        delay = new WaitUntil(() => !isAttack);
        if (ScanTarget != null) StopCoroutine(ScanTarget);
        ScanTarget = StartCoroutine(ScanTargetIter());
    }

    IEnumerator ScanTargetIter()
    {
        while (true)
        {
            if (isAttack)
                yield return delay;

            else
            {
                CheckTarget();
                yield return null;
            }
        }
    }

    public void CheckTarget()
    {
        // SpawnManager에서 적을 생성하고 들고 있다.
        // SpawnManager에서 들고 있는 적 = 무조건 target (한마리씩 나오니까)
        // SpawnManager에서 들고 있는 적과 Player의 거리가 AttackRange보다 작다면
        // 공격 진입
        if (GameManager.Instance.CurMonster == null) return;
        float sqrDistance = Vector3.SqrMagnitude(transform.position - GameManager.Instance.CurMonster.transform.position);
        float sqrAttackRange = player.StatHandler.Stat.AttackRange * player.StatHandler.Stat.AttackRange;

        if(sqrDistance < sqrAttackRange)
        {
            ActiveAttack();
        }
        else
        {
            isAttack = false;
        }
    }

    private void ActiveAttack()
    {
        isAttack = true;
        ActiveProjectile();
        OnAttack?.Invoke();
    }

    private void ActiveProjectile()
    {
        projectile = GameManager.Instance.Pool.SpawnFromPool(EPoolObjectType.Projectile).ReturnMyComponent<Projectile_Arrow>();
        projectile.Init(player.StatHandler.Stat);
    }
}
