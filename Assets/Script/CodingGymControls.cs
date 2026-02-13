using UnityEngine;
using UnityEngine.UI;

public class CodingGymControls : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Slider rotateSlider;

    void Update()
    {
        // Slider
        float angle = rotateSlider.value * 360f;
        spriteRenderer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    // Button
    public void ChangeColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        spriteRenderer.color = randomColor;
    }
}
