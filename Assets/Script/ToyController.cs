using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// Connects UI buttons to gameplay actions
/// Controls the high-level game flow
public class ToyController : MonoBehaviour
{
    public SummonSystem summonSystem;
    public CollectionSystem collectionSystem;

    public RabbitSliderControl rabbitSlider;
    public Button collectButton;
    public TMP_Text statusText;

    public Transform rabbit;
    public float rabbitHiddenY = -0.47f;
    public float rabbitShownY = 1.55f;

    private void Start()
    {
        // Initialize UI and systems
        if (collectButton != null) collectButton.interactable = false;

        if (statusText != null) statusText.text = "Click Wand to Summon";

        if (summonSystem != null)
        {
            // Let SummonSystem control rabbit visibility at start
            summonSystem.statusText = statusText;
            summonSystem.InitStartHidden();
        }

        if (collectionSystem != null)
        {
            collectionSystem.InitCount();
        }

        // Ensure rabbit starts hidden at correct Y (even if hidden)
        SetRabbitY(rabbitHiddenY);
    }

    private void Update()
    {
        if (summonSystem == null || collectButton == null) return;

        // Enable collect only after summoning is finished
        collectButton.interactable = summonSystem.CanPullRabbit();
    }

    ///// Called by the Wand button.
    ///// Starts the 3second summoning sequence.
    public void OnWandButtonClicked()
    {
        if (summonSystem == null) return;

        summonSystem.StartSummon();

        // During summoning, you cannot collect yet.
        if (collectButton != null) collectButton.interactable = false;
    }

    ///// Called by the Collect button.
    ///// Moves the held item into the collection area and resets to idle.
    public void OnCollectButtonClicked()
    {
        if (summonSystem == null || collectionSystem == null) return;

        // Only allow collect after summoning finished.
        if (!summonSystem.CanPullRabbit()) return;

        // Collect the held item (move it to collection area)
        GameObject held = summonSystem.GetHeldItem();
        collectionSystem.CollectHeldItem(held);

        // Reset rabbit and summoning state
        SetRabbitY(rabbitHiddenY);
        summonSystem.ResetToIdle();

        if (collectButton != null) collectButton.interactable = false;
        if (statusText != null) statusText.text = "Click crystall ball to Summon";

        if (rabbitSlider != null)
        {
            rabbitSlider.ResetSlider();
        }
    }

    ///// Keep it public so the slider script can set rabbit Y safely.
    public void SetRabbitY(float y)
    {
        if (rabbit == null) return;

        Vector3 pos = rabbit.position;
        pos.y = y;
        rabbit.position = pos;
    }

    ///// Used by the slider script: player can pull rabbit only after summoning finished.
    public bool CanPullRabbit()
    {
        if (summonSystem == null) return false;
        return summonSystem.CanPullRabbit();
    }
}