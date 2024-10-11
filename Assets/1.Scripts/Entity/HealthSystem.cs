using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float curHealth;
    public float CurHealth => curHealth;
    public event Action<float> OnHit;
    public event Action OnDie;
    public event Action<float> OnHealthChange;

    public bool IsDie { get; private set; }

    public void InitHealthSystem(float maxHealth)
    {
        this.maxHealth = maxHealth;
        curHealth = this.maxHealth;
        IsDie = false;
        CallHealthChangeEvent(GetHealthPercentage());
    }

    public void TakeDamage(float damage)
    {
        curHealth = Mathf.Max(curHealth - damage, 0);

        if (!IsDie && curHealth == 0)
        {
            IsDie = true;
            CallDieEvent();
        }
        if (damage != int.MaxValue)
            CallHitEvent(damage);

        CallHealthChangeEvent(GetHealthPercentage());
    }

    public void CallHitEvent(float damage)
    {
        OnHit?.Invoke(damage);
    }

    public void CallDieEvent()
    {
        OnDie?.Invoke();
    }

    public void CallHealthChangeEvent(float healthPercentage)
    {
        OnHealthChange?.Invoke(healthPercentage);
    }

    public float GetHealthPercentage()
    {
        return curHealth / maxHealth;
    }
}
