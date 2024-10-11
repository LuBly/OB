using System.Collections.Generic;
using UnityEngine;

//public enum EPoolObjectType{Default, Enemy, EnemyDamageText, SpawnEffect, EnemyBullet, PlayerDamageText }

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public EPoolObjectType type; // key ��
        public GameObject prefab; // ���� ������ ������Ʈ
        public int size; // �ѹ��� ��� ������ ������
        public Transform parentTransform; // �θ� ������Ʈ
    }

    [Header("# Pool Info")]
    [SerializeField] private List<Pool> pools;
    private Dictionary<EPoolObjectType, List<PoolObject>> poolDictionary;


    private void Awake()
    {
        // ��ųʸ� �ʱ�ȭ
        poolDictionary = new Dictionary<EPoolObjectType, List<PoolObject>>();
    }

    private void Start()
    {
        // pools�� �ִ� ��� ������Ʈ�� Ž���ϰ� ���س��� size��ŭ �������� �̸� ����� ����
        foreach (Pool pool in pools)
        {
            List<PoolObject> list = new List<PoolObject>();
            poolDictionary.Add(pool.type, list);

            AddPoolObject(pool.type);
        }
    }

    private void AddPoolObject(EPoolObjectType type) // ������ ����
    {
        Pool pool = pools.Find(obj => type == obj.type);

        // pool.size��ŭ �������� ���� -> ��Ȱ��ȭ -> ����Ʈ�� �־���
        for (int i = 0; i < pool.size; i++)
        {
            PoolObject poolObj = Instantiate(pool.prefab, pool.parentTransform).GetComponent<PoolObject>();
            poolObj.gameObject.SetActive(false);
            poolDictionary[type].Add(poolObj);
        }
    }

    // �̹� ������ ������Ʈ Ǯ���� �������� ������
    public PoolObject SpawnFromPool(EPoolObjectType type)
    {
        if (!poolDictionary.ContainsKey(type))
        {
            return null;
        }

        PoolObject poolObject = null;

        for (int i = 0; i < poolDictionary[type].Count; i++)
        {
            if (!poolDictionary[type][i].gameObject.activeSelf) // ��Ȱ��ȭ�� ������Ʈ�� ã���� ��
            {
                poolObject = poolDictionary[type][i];
                break;
            }

            if (i == poolDictionary[type].Count - 1) // ��� ������Ʈ�� Ȱ��ȭ ���� �� 
            {
                AddPoolObject(type);
                poolObject = poolDictionary[type][i + 1];
            }
        }

        poolObject.gameObject.SetActive(true); // Ȱ��ȭ

        return poolObject;
    }
}