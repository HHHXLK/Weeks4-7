using System.Collections.Generic;
using UnityEngine;

public class PopUpPirateGame : MonoBehaviour
{
    public GameObject knifePrefab;
    public Transform barrel;
    public GameObject pirate;

    public int knifeCount = 5;

    private List<GameObject> knives = new List<GameObject>();
    private bool gameOver = false;

    void Start()
    {
        pirate.SetActive(false);

        SpawnKnives();
    }

    void SpawnKnives()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            float angle = i * (360f / knifeCount);       
            float radians = angle * Mathf.Deg2Rad;

            float radius = 0.9f;                       
            Vector3 offset = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0f) * radius;

 
            offset.y += 0.2f;

            Vector3 randomOffset = offset;


            GameObject knife = Instantiate(knifePrefab);
            knife.transform.position = barrel.position + randomOffset;

            // 给 Knife 一个引用回 Game
            knife.GetComponent<Knife>().game = this;

            knives.Add(knife);
        }
    }

    public void KnifeClicked(GameObject knife)
    {
        if (gameOver) return;

        bool piratePops = Random.value < 0.3f;  // 30% chance

        if (piratePops)
        {
            pirate.SetActive(true);
            gameOver = true;
        }
        else
        {
            knives.Remove(knife);
            Destroy(knife);

            if (knives.Count == 0)
            {
                gameOver = true;
            }
        }
    }
}