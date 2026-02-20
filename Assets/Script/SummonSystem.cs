using TMPro;
using UnityEngine;

/// Controls the 3-second summoning timer
/// Rotates the wand in two ways:
///(1) Orbit rotation (around the hat) using a pivot object
///(2) Self rotation (wand spins around its own center)
///  When summoning finishes:
///    Shows the rabbit
///    Spawns ONE "held item" and attaches it to the HoldPoint
///
/// I separated this system because it is time-based behaviour (timer + animation-like rotation).
/// Keeping it isolated makes the ToyController easier to read and debug.
public class SummonSystem : MonoBehaviour
{
    public Transform wand;              // The wand object itself (child of pivot)
    public Transform wandOrbitPivot;     // The pivot located at hat center
    public Transform rabbit;            // Rabbit transform
    public Transform holdPoint;   // A child empty object on the rabbit where the item should appear
    public TMP_Text statusText;          // UI text for instructions

    public float summonTime = 3f;     // How long summoning lasts
    public float orbitRotateSpeed = 180f; // Degrees per second for orbit rotation
    public float selfRotateSpeed = 720f;  // Degrees per second for wand self-spin

    public GameObject[] itemPrefabs;   
    // State variables
    private bool isSummoning = false;
    private bool summonFinished = false;  // Ready to pull rabbit
    private float timer = 0f;

    // The item currently attached to the rabbit (hand-held item)
    private GameObject heldItem;

    public void InitStartHidden()
    {
        // At the very beginning of the game, rabbit should not be visible.
        if (rabbit != null) rabbit.gameObject.SetActive(false);
        heldItem = null;
        isSummoning = false;
        summonFinished = false;
        timer = 0f;
    }

    public bool CanPullRabbit()
    {
        // Other scripts (slider/controller) use this to decide if player can pull rabbit.
        return summonFinished;
    }

    public GameObject GetHeldItem()
    {
        return heldItem;
    }

    public void ClearHeldItem()
    {
        heldItem = null;
    }

    public void StartSummon()
    {
        // Prevent double summon while summoning or while already ready to pull.
        if (isSummoning || summonFinished) return;

        // Reset timer
        timer = 0f;
        isSummoning = true;
        summonFinished = false;

        // Hide rabbit at the start of summoning.
        if (rabbit != null) rabbit.gameObject.SetActive(false);

        // if an old held item still exists, destroy it.
        if (heldItem != null)
        {
            Destroy(heldItem);
            heldItem = null;
        }

        if (statusText != null) statusText.text = "Summoning...";
    }

    private void Update()
    {
        if (!isSummoning) return;

        timer += Time.deltaTime;

        // Orbit rotation
        if (wandOrbitPivot != null)
        {
            wandOrbitPivot.Rotate(0f, 0f, orbitRotateSpeed * Time.deltaTime);
        }

        // Self rotation (wand spins around its own center)
        if (wand != null)
        {
            wand.Rotate(0f, 0f, selfRotateSpeed * Time.deltaTime);
        }

        // When timer ends, finish summoning.
        if (timer >= summonTime)
        {
            isSummoning = false;
            summonFinished = true;

            // Show rabbit now that summoning is done.
            if (rabbit != null) rabbit.gameObject.SetActive(true);

            if (statusText != null) statusText.text = "Look what's in the hat!";

            // Spawn one held item and attach it to holdPoint so it follows the rabbit.
            SpawnHeldItemIfNeeded();
        }
    }

    private void SpawnHeldItemIfNeeded()
    {
        if (heldItem != null) return;
        if (itemPrefabs == null || itemPrefabs.Length == 0) return;
        if (holdPoint == null) return;

        int index = Random.Range(0, itemPrefabs.Length);
        heldItem = Instantiate(itemPrefabs[index]);

        // Parent to hold point so it moves with the rabbit
        heldItem.transform.SetParent(holdPoint, false);
        heldItem.transform.localPosition = Vector3.zero;

        SpriteRenderer sr = heldItem.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            float brightness = Random.Range(0.8f, 1.2f);
            sr.color = new Color(brightness, brightness, brightness, 1f);
        }
    }

    public void ResetToIdle()
    {
        // Called after collecting
        summonFinished = false;

        // Hide rabbit after collection.
        if (rabbit != null) rabbit.gameObject.SetActive(false);

        // heldItem should be handled by CollectionSystem (detached and moved),
        // so here only clear the reference.
        heldItem = null;
    }
}