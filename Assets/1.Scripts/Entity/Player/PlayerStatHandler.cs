using System;

// 변동 변수 ( 공격력, 공격속도, 공격 범위, 넉백 파워 )
[Serializable]
public class PlayerStat
{
    public float AttackPower = 1;
    public float AttackSpeed = 1;
    public float AttackRange = 5;
    public float KnockBackPower = 30;
}

public class PlayerStatHandler
{
    public PlayerStat Stat = new PlayerStat();
}