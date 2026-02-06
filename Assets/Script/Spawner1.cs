using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public GameObject prefabToSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            float x = Random.Range(-7f, 7f);
            float y = Random.Range(-3f, 3f);

            Vector3 pos = new Vector3(x, y, 0f);

            Instantiate(prefabToSpawn, pos, Quaternion.identity);
        }
    }

}
