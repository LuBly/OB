using System;
using UnityEngine;

[Serializable]
public class MonsterData
{
    public string Name = "temp";
    public string Grade = "임시";
    public float Speed = 5f;
    public int MaxHealth = 50;
}

public class MonsterDataHandler
{
    [SerializeField] public MonsterData MonsterData { get; private set; }
    // TODO : CSV에서 값 받아와서 Data채워넣기
    public void LoadData(int id)
    {
        MonsterData = new MonsterData();
        MonsterData.Name = GameManager.Instance.Data.MonsterData[id]["Name"];
        MonsterData.Grade = GameManager.Instance.Data.MonsterData[id]["Grade"];
        MonsterData.Speed = float.Parse(GameManager.Instance.Data.MonsterData[id]["Speed"]);
        MonsterData.MaxHealth = int.Parse(GameManager.Instance.Data.MonsterData[id]["Health"]);
    }
}