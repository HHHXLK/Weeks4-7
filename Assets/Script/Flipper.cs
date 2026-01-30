using UnityEngine;

public class Flipper : MonoBehaviour
{
    public float speed;
    private float direction = 1f;
    bool MoveC = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contr
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveC)
        {
            transform.position += direction * transform.right * speed * Time.deltaTime;
        }
    }

    public void OnMoveClick()
    {
        MoveC = true;
    }

    public void OnStopClick()
    {
        MoveC= false;
    }
    public void OnFlipClick()
    {
        direction *= -1;
    }
}