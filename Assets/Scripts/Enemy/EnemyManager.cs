using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] int enemyGroupCount;


    public static EnemyManager instance;
    [SerializeField] GameObject[] enemyPrefab;
    public Player player;

    public List<List<Enemy>> enemys = new List<List<Enemy>>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        StartStage(GameManager.Instance.curStage);
    }
    void StartStage(int stageNum)
    {
        for (int i = 0; i <enemyGroupCount; i++)
        {
            Vector3 groupPosition = new Vector3(0, 0, 20 * (i + 1));

            int enemyNum = stageNum + (i / 3);
            List<Enemy> enemyGroup = new List<Enemy>();
            for (int j = 0; j < enemyNum; j++)
            {
                enemyGroup.Add(Instantiate(enemyPrefab[0], groupPosition + (Vector3.right * 2 * j), Quaternion.identity, transform).GetComponent<Enemy>());
            }
            enemys.Add(enemyGroup);
        }
    }

    public void EnemyDie(Enemy enemy)
    {
        for(int i = 0;i < enemys.Count; i++)
        {
            if (enemys[i].Contains(enemy))
            {
                enemys[i].Remove(enemy);
                Debug.Log($"목록에서{enemy}제거됨");
                return;
            }
        }
    }
}
