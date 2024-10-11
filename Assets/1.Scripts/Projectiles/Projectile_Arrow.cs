using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Arrow : PoolObject
{
    [SerializeField] private float disableRange = 0.2f;
    [SerializeField] private float projectileMoveSpeed = 10f;

    private float AttackPower;
    private float KnockBackPower;
    private Coroutine ActiveProjectile;
    private Monster TargetMonster;

    // ���� �������� �̵�
    // ���Ϳ� �浹 �� TakeDamage ����
    public void Init(PlayerStat stat)
    {
        transform.position = GameManager.Instance.Player.transform.position;
        AttackPower = stat.AttackPower;
        KnockBackPower = stat.KnockBackPower;
        TargetMonster = GameManager.Instance.CurMonster;
        if(ActiveProjectile != null) StopCoroutine(ActiveProjectile);
        ActiveProjectile = StartCoroutine(MoveProjectile());
    }

    IEnumerator MoveProjectile()
    {
        if(TargetMonster == null)
        {
            DisableObject();
            yield break;
        }

        Vector3 targetPos = TargetMonster.transform.position;
        float sqrDistance = Vector3.SqrMagnitude(transform.position - targetPos);
        float sqrThreshold = disableRange * disableRange;
        while (sqrDistance > sqrThreshold)
        {
            sqrDistance = Vector3.SqrMagnitude(transform.position - targetPos);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, projectileMoveSpeed * Time.deltaTime);
            yield return null;
        }

        TargetMonster.MovementHandler.KnockBack(KnockBackPower);
        TargetMonster.HealthSystem.TakeDamage(AttackPower);
        DisableObject();
    }

    private void DisableObject()
    {
        TargetMonster = null;
        if (ActiveProjectile != null)
        {
            StopCoroutine(ActiveProjectile);
        }
        gameObject.SetActive(false);
    }
}
