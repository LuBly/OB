using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PoolManager Pool;
    public DataManager Data;
    public SpawnManager Spawn;
    public UIManager UI;
    public Player Player;
    public Monster CurMonster;
}
