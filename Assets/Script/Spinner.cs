using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float speed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }

    public void StartSpin()
    {
        speed = 100f;
    }

    public void StopSpin()
    {
        speed = 0f;
    }
}
