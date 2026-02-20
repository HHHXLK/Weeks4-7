using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// Takes the held item (from SummonSystem) and places it into the collection area
/// Adds the item to a list
/// Limits the number of collected items and destroys the oldest one when the limit is exceeded
/// Updates UI count text
public class CollectionSystem : MonoBehaviour
{
    public Transform collectionArea;  // Center point for spawn range
    public TMP_Text countText;     // UI count display

    public int maxItems = 10;
    public float rangeX = 4f;     // Horizontal random range around collectionArea
    public float rangeY = 0.5f;     // Vertical random range around collectionArea

    private int count = 0;
    private List<GameObject> spawnedItems = new List<GameObject>();

    public void InitCount()
    {
        count = 0;
        if (countText != null) countText.text = "Collected: 0";
    }


    /// Moves a held item into the collection area and tracks it in a list.
 
    public void CollectHeldItem(GameObject heldItem)
    {
        if (heldItem == null) return;
        if (collectionArea == null) return;

        // Detach from rabbit so it doesn't disappear with the rabbit.
        heldItem.transform.SetParent(null);

        float centerX = collectionArea.position.x;
        float centerY = collectionArea.position.y;

        float randomX = Random.Range(centerX - rangeX, centerX + rangeX);
        float randomY = Random.Range(centerY - rangeY, centerY + rangeY);

        heldItem.transform.position = new Vector3(randomX, randomY, 0f);

        // Track it
        spawnedItems.Add(heldItem);

        // Update count UI
        count++;
        if (countText != null) countText.text = "Collected: " + count;

        // If too many items, destroy the oldest
        if (spawnedItems.Count > maxItems)
        {
            Destroy(spawnedItems[0]);
            spawnedItems.RemoveAt(0);
        }
    }
}