using UnityEngine;
using UnityEngine.UI;

public class RabbitSlider : MonoBehaviour
{
    public Slider slider;
    public ToyController controller;

    public float hiddenY = -2f;
    public float shownY = 0f;

    void Update()
    {
        if (!controller.CanPullRabbit()) return;

        float y = Mathf.Lerp(hiddenY, shownY, slider.value);
        controller.SetRabbitY(y);
    }
}
