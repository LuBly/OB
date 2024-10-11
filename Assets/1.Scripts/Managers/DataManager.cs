using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> monsterPrefabs;
    public List<GameObject> MonsterPrefabs => monsterPrefabs;
    public List<Dictionary<string, string>> MonsterData;

    private void Awake()
    {
        MonsterData = CSVReader.Read("SampleMonster");
    }
}
