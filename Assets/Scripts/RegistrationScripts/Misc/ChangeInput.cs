using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeInput : MonoBehaviour
{
    EventSystem system;

    public Button submit;
    public Toggle privacy;

    public void Awake()
    {
        system = EventSystem.current;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (system.currentSelectedGameObject != null)
                {
                    Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
                    if (previous != null)
                    {
                        previous.Select();
                    }
                }
            }
            else
            {
                if (system.currentSelectedGameObject != null)
                {
                    Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
                    if (next != null)
                    {
                        next.Select();
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (privacy.IsActive())
            {
                print("signup");
                if (privacy.isOn) submit.onClick.Invoke();
            }
            else
            {
                print("login");
                submit.onClick.Invoke();
            }
        }
    }

    public void SetSubmit(Button button)
    {
        submit = button;
    }
}
