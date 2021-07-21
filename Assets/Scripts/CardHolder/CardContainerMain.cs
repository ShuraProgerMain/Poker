using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardContainerMain : CardContainerRoot
{
    private void OnMouseDown()
    {
        if (currentCard != null)
        {
            HoldOnCard();
        }
    }
    
    public void HoldOnCard()
    {
        inactive = !inactive;
        SetState();
    }
    
    public void HoldOnCardReset()
    {
        inactive = false;
        SetState();
    }
    public void SetState()
    {
        if (inactive)
        {
            _renderer.color = _inactiveColor;
        }
        else
        {
            _renderer.color = _defaultColor;
        }
    }

    
}
