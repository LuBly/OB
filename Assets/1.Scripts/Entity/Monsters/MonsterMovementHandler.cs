using System.Collections;
using UnityEngine;

public class MonsterMovementHandler : MonoBehaviour
{
    private WaitForFixedUpdate delay;

    private Monster monster;
    private float moveSpeed;
    [SerializeField] private float duration = 0.3f;
    private bool isKnockBack;
    
    private Coroutine moveCoroutine;
    private Coroutine knockbackCoroutine;

    private void Awake()
    {
        delay = new WaitForFixedUpdate();   
    }

    public void Init(Monster monster)
    {
        this.monster = monster;
        moveSpeed = monster.DataHandler.MonsterData.Speed;
        isKnockBack = false;
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(Move());
        monster.HealthSystem.OnDie += Die;
    }

    public void KnockBack(float KnockBackPower)
    {
        if (!isKnockBack)
        {
            if(knockbackCoroutine != null) StopCoroutine(knockbackCoroutine);
            knockbackCoroutine = StartCoroutine(ApplyKnockBack(KnockBackPower));
        }
    }

    private IEnumerator ApplyKnockBack(float KnockBackPower)
    { 
        float knockBackTime = 0f;
        Vector2 knockbackDirection = (monster.transform.position - GameManager.Instance.Player.transform.position).normalized;
        isKnockBack = true;
        while (knockBackTime < duration)
        {
            float t = (duration - knockBackTime) / duration;
            monster.transform.Translate(knockbackDirection * t * Time.fixedDeltaTime);
            knockBackTime += Time.fixedDeltaTime;
            yield return delay;
        }
        isKnockBack = false;
    }

    private IEnumerator Move()
    {
        while (true)
        {
            monster.transform.position = Vector3.MoveTowards(monster.transform.position, GameManager.Instance.Player.transform.position + Vector3.right, moveSpeed * Time.fixedDeltaTime);
            yield return delay;
        }
    }

    private void Die()
    {
        if(moveCoroutine != null) StopCoroutine(moveCoroutine);
        if(knockbackCoroutine != null) StopCoroutine(knockbackCoroutine);

        monster.HealthSystem.OnDie -= Die;
    }
}