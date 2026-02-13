using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToyController : MonoBehaviour
{
    public Transform wand;
    public Transform rabbit;

    public Button collectButton;
    public TMP_Text statusText;
    public TMP_Text countText;

    public float rotateSpeed = 180f;
    public float summonTime = 3f;

    public float rabbitHiddenY = -2f;
    public float rabbitShownY = 0f;

    private bool isSummoning = false;
    private bool canPullRabbit = false;

    private float timer = 0f;
    private int count = 0;

    void Start()
    {
        SetRabbitY(rabbitHiddenY);
        collectButton.interactable = false;
        statusText.text = "Click Wand to Summon";
        countText.text = "Collected: 0";
    }

    void Update()
    {
        if (isSummoning)
        {
            timer += Time.deltaTime;

            wand.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

            if (timer >= summonTime)
            {
                isSummoning = false;
                canPullRabbit = true;
                collectButton.interactable = true;
                statusText.text = "Use Slider, then Collect!";
            }
        }
    }

    // 按魔杖按钮调用
    public void StartSummon()
    {
        if (isSummoning || canPullRabbit) return;

        timer = 0f;
        isSummoning = true;
        statusText.text = "Summoning...";
    }

    // Collect 按钮调用
    public void CollectItem()
    {
        if (!canPullRabbit) return;

        count++;
        countText.text = "Collected: " + count;

        SetRabbitY(rabbitHiddenY);

        canPullRabbit = false;
        collectButton.interactable = false;
        statusText.text = "Click Wand to Summon";
    }

    public void SetRabbitY(float y)
    {
        Vector3 pos = rabbit.position;
        pos.y = y;
        rabbit.position = pos;
    }

    public bool CanPullRabbit()
    {
        return canPullRabbit;
    }
}
