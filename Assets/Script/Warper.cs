using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Warper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //IF WE CLICK AND WE ARE NOT HOVERING OVER UI

        bool shouldWarp = Mouse.current.leftButton.wasPressedThisFrame &&
                            !EventSystem.current.IsPointerOverGameObject();

        if (shouldWarp == true)
        {
            Vector3 currentMousePosition = Mouse.current.position.ReadValue();
            transform.position = currentMousePosition;

        }
    }
}
