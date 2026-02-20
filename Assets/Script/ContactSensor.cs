using UnityEngine;
using UnityEngine.Events;

public class ContactSensor : MonoBehaviour
{
    public Transform player;
    public UnityEvent OnEnter;
    public UnityEvent OnLeave;



    private SpriteRenderer hazardRenderer;
    private bool wasInTheHazard = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hazardRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isInTheHazard = hazardRenderer.bounds.Contains(player.position);
        if (isInTheHazard
            && wasInTheHazard == false)
        {
            wasInTheHazard = true;
            //WHAT WE WANT TO HAVE HAPPEN WHEN THE PLAYER ENTERS THE SENSOR
            OnEnter.Invoke();
        }
        else if (!isInTheHazard && wasInTheHazard)
        {
            wasInTheHazard = false;
            //WHAT WE WANT TO HAVE HAPPEN WHEN THE PLAYER EXITS THE SENSOR
            OnLeave.Invoke();
        }


    }
}
