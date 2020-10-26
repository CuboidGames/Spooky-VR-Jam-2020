using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPointerHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject hidingObject;

    private UIElement focusedUIElement;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && focusedUIElement)
        {
            focusedUIElement.OnSelect.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UIElement"))
        {
            focusedUIElement = other.GetComponent<UIElement>();
            hidingObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UIElement"))
        {
            focusedUIElement = null;
            hidingObject.SetActive(true);
        }
    }
}
