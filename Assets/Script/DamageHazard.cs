using UnityEngine;

public class DamageHazard : MonoBehaviour
{
    public int damage;
    public DungeonRaiderPlayer player;

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
        bool isInTheHazard = hazardRenderer.bounds.Contains(player.transform.position);
        if (isInTheHazard
            && wasInTheHazard == false)
        {
            wasInTheHazard = true;
            player.TakeDamage(damage);
        }
        //IF WE HAVE EXITED OUT OF THE HAZARD AND WE WERE PREVIOUSLY IN THE HAZARD
        //THEN WE RESET
        else if (!isInTheHazard && wasInTheHazard)
        {
            wasInTheHazard = false;
        }


    }
}
