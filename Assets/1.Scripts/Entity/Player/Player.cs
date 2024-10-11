using UnityEngine;

public class Player : MonoBehaviour
{
    // 변동 변수 ( 공격력, 공격속도, 공격 범위, 넉백 파워 )
    public PlayerStatHandler StatHandler { get; private set; }

    // 정적 변수 ( 이름, +@ )
    public PlayerDataHandler DataHandler { get; private set; }

    // 동작 관리
    public PlayerAttackHandler AttackHandler { get; private set; }
    public PlayerAnimationHandler AnimationHandler { get; private set; }
    public PlayerAnimationEventHandler AnimationEventHandler { get; private set; }
    public PlayerAnimationData AnimationData { get; private set; }

    private void Awake()
    {
        // TODO : DataManager에서 Stat과 Data 불러오는 기능 추가
        StatHandler = new PlayerStatHandler();
        DataHandler = new PlayerDataHandler();
        AnimationData = new PlayerAnimationData();

        AttackHandler = GetComponent<PlayerAttackHandler>();
        AnimationHandler = GetComponent<PlayerAnimationHandler>();
        AnimationEventHandler = GetComponentInChildren<PlayerAnimationEventHandler>();
    }

    private void Start()
    {
        AnimationData.Initialize();
        AttackHandler.Init();
        AnimationHandler.Init();
        AnimationEventHandler.Init();
    }
}
