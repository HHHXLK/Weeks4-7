using UnityEngine;

public class Pirate : MonoBehaviour
{
    public bool gameOver = false;
    Knife[] knives = FindObjectsOfType<Knife>();

    void Start()
    {
        
        Knife[] knives = FindObjectsOfType<Knife>();

   
        int bad = Random.Range(0, knives.Length);

        for (int i = 0; i < knives.Length; i++)
        {
            knives[i].isBad = (i == bad);
            knives[i].pirate = this;
        }
    }

    
    public void PopUp()
    {
        if (gameOver) return;

        gameOver = true;

    
        transform.position += Vector3.up * 2f;


    }


    public void Win()
    {
        if (gameOver) return;

        gameOver = true;

    }
}
