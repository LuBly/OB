using UnityEngine;

public class Player : MonoBehaviour
{
    // ���� ���� ( ���ݷ�, ���ݼӵ�, ���� ����, �˹� �Ŀ� )
    public PlayerStatHandler StatHandler { get; private set; }

    // ���� ���� ( �̸�, +@ )
    public PlayerDataHandler DataHandler { get; private set; }

    // ���� ����
    public PlayerAttackHandler AttackHandler { get; private set; }
    public PlayerAnimationHandler AnimationHandler { get; private set; }
    public PlayerAnimationEventHandler AnimationEventHandler { get; private set; }
    public PlayerAnimationData AnimationData { get; private set; }

    private void Awake()
    {
        // TODO : DataManager���� Stat�� Data �ҷ����� ��� �߰�
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
