using UnityEngine;
using UnityEngine.UI;

public class HpBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private Monster monster;
    private Camera MainCamera;
    private Vector3 amount;

    private void Awake()
    {
        if (MainCamera == null)
        {
            MainCamera = Camera.main;
        }
    }

    public void InitalizeHpBar(Monster monster)
    {
        this.monster = monster;
        fillImage.fillAmount = 1;
        this.monster.HealthSystem.OnHealthChange += UpdateHpBar;
        this.monster.HealthSystem.OnDie += DeActivateHpBar;
    }

    private void DeActivateHpBar()
    {
        gameObject.SetActive(false);
        if (monster != null)
        {
            monster.HealthSystem.OnHealthChange -= UpdateHpBar;
            monster.HealthSystem.OnDie -= DeActivateHpBar;
            monster = null;
        }
    }

    private void UpdateHpBar(float healthPercentage)
    {
        fillImage.fillAmount = healthPercentage;
    }
}
