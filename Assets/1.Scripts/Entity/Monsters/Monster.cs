using UnityEngine;

public class Monster : PoolObject
{
    public MonsterDataHandler DataHandler { get; private set; }
    public MonsterAnimationData AnimationData { get; private set; }
    public MonsterAnimationHandler AnimationHandler { get; private set; }
    public MonsterMovementHandler MovementHandler { get; private set; }
    public HealthSystem HealthSystem { get; private set; }
    public HpBarUI HpBarUI { get; private set; }
    public MonsterUIController monsterUIController { get; private set; }

    [SerializeField] private int id;

    private void Awake()
    {
        DataHandler = new MonsterDataHandler();
        AnimationData = new MonsterAnimationData();
        AnimationHandler = GetComponent<MonsterAnimationHandler>();
        MovementHandler = GetComponent<MonsterMovementHandler>();
        HealthSystem = GetComponent<HealthSystem>();
        HpBarUI = GetComponentInChildren<HpBarUI>();
        monsterUIController = GetComponent<MonsterUIController>();
    }

    // 위치, 체력정보 초기화
    public void Init()
    {
        if(DataHandler.MonsterData == null)
            DataHandler.LoadData(id);
        transform.position = GameManager.Instance.Spawn.SpawnPoint.position;
        AnimationData.Initialize();
        AnimationHandler.Init(this);
        MovementHandler.Init(this);
        HealthSystem.InitHealthSystem(DataHandler.MonsterData.MaxHealth);
        HpBarUI.InitalizeHpBar(this);
        monsterUIController.Init(this);
    }
}
