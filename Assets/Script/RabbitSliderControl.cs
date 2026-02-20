using UnityEngine;
using UnityEngine.UI;

/// Reads the UI Slider value (0-1)
/// Converts that value into a vertical Y position for the rabbit
/// Only allows movement after summoning is finished
public class RabbitSliderControl : MonoBehaviour
{
    public Slider slider;               // The UI slider component
    public ToyController controller;    // Reference to main controller

    public float hiddenY = -2f;         // Y position when rabbit is inside the hat
    public float shownY = 0f;           // Y position when rabbit is fully pulled out

    void Update()
    {
        // Only allow rabbit movement after summoning is complete.
        if (!controller.CanPullRabbit()) return;

        // Convert slider value (0¨C1) into a Y position.
        // Smoothly maps the value between hiddenY and shownY.
        float y = hiddenY + (shownY - hiddenY) * slider.value;

        // Ask ToyController to update the rabbit's position.
        controller.SetRabbitY(y);
    }

    /// Resets the slider back to 0.
    /// Called after collecting the item so the rabbit returns to the hat.
    public void ResetSlider()
    {
        if (slider != null)
        {
            slider.value = 0f;
        }
    }
}