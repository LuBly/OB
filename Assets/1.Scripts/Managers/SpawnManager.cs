using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// TODO :: 처치될때마다 다음 몬스터를 판단할 수 있는 로직 제작 필요
public class SpawnManager : MonoBehaviour
{
    public Transform SpawnPoint;
    public List<Monster> Monsters {  get; private set; }

    private int curIdx = 0;
    private WaitForSeconds delay = new WaitForSeconds(1f);
    private Coroutine spawnNewMonster;

    private void Start()
    {
        Monsters = new List<Monster>();
        for (int i = 0; i < GameManager.Instance.Data.MonsterPrefabs.Count; i++) 
        {
            Monsters.Add(Instantiate(GameManager.Instance.Data.MonsterPrefabs[i].GetComponent<Monster>(), SpawnPoint));
            Monsters[i].gameObject.SetActive(false);
        }

        SpawnMonster();
    }

    private void SpawnMonster()
    {
        Monsters[curIdx % Monsters.Count].gameObject.SetActive(true);
        Monsters[curIdx % Monsters.Count].Init();
        Monsters[curIdx % Monsters.Count].HealthSystem.OnDie += DisableMonster;
        GameManager.Instance.CurMonster = Monsters[curIdx % Monsters.Count];
    }

    private void DisableMonster()
    {
        if (spawnNewMonster != null) StopCoroutine(spawnNewMonster);
        spawnNewMonster = StartCoroutine(delaySpawn());
    }

    private IEnumerator delaySpawn()
    {
        yield return delay;

        Monsters[curIdx % Monsters.Count].gameObject.SetActive(false);
        Monsters[curIdx % Monsters.Count].HealthSystem.OnDie -= DisableMonster;
        curIdx++;
        SpawnMonster();
    }
}
