using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawningPrefab;

    public float waitDuration;
    public float destroyDuration;

    private float waitProgress = 0f;
    private float destroyProgress = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, destroyDuration);

        //EMPTY VECTOR3
        //Vector3 originPosition = Vector3.zero;

        //EMPTY ROTATION
        //Quaternion originRotation = Quaternion.identity;

        //Instantiate(spawningPrefab, transform.position, Quaternion.identity);

        //SPAWNING AT THE POSITION OF THE SPAWNER (WITH THE SPAWNER'S ROTATION)
        //Instantiate(spawningPrefab, transform.position, transform.rotation);

        //SPAWNING AT THE ORIGIN
        //Instantiate(spawningPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        waitProgress += Time.deltaTime;
        if (waitProgress > waitDuration)
        {
            GameObject spawnedObject = Instantiate(spawningPrefab, transform.position, Quaternion.identity);

            Destroy(spawnedObject, destroyDuration);

            waitProgress = 0f;
        }

    }

}
