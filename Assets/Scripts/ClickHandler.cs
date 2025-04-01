using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public Action Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked?.Invoke();
        }
    }
}
