using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;   // 要生成的 Prefab
    public int spawnCount = 5;       // 生成数量

    public float minX = -7f;
    public float maxX = 7f;
    public float minY = -3f;
    public float maxY = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);

            Vector3 pos = new Vector3(x, y, 0f);

            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
