using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuController : MonoBehaviour
{
    public UICommand[] UiCommands;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (var uiCommand in UiCommands)
            {
                if (Input.GetKeyDown(uiCommand.KeyToPress))
                {
                    uiCommand.Event.Invoke();
                }
            }
        }
    }

    public void ChangeUI(GameObject ui)
    {
        ui.SetActive(!ui.activeSelf);
    }
}
[Serializable]
public class UICommand
{
    public KeyCode KeyToPress;
    public UnityEvent Event;
}
