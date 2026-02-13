using UnityEngine;

public class Knife : MonoBehaviour
{
    public bool isBad = false;
    public Pirate pirate;

    void OnMouseDown()
    {
        if (pirate == null || pirate.gameOver) return;

        if (isBad)
        {
            pirate.PopUp();  
        }
        else
        {
            Destroy(gameObject);  


            Knife[] left = FindObjectsOfType<Knife>();
            if (left.Length <= 1)
            {
                pirate.Win();
            }
        }
    }
}
