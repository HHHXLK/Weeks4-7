using UnityEngine;

public class Knife : MonoBehaviour
{
    public PopUpPirateGame game;

    void OnMouseDown()
    {
        if (game != null)
        {
            game.KnifeClicked(gameObject);
        }
    }
}
