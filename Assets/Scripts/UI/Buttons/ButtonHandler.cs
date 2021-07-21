using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private PanelShower _panelShower;

    #region Events

    public static Action DrawCardAction;
    public static Action DealCardAction;
    public static Action ResetHoldOneAction;
    public static Action MiniGameShowAction;
    public static Action MiniGameHideAction;
    public static Action ShowButtonsPanelAction;
    public static Action PickUpCreditsAction;

    #endregion
    
    public void CloseThisPanel(DataPanel data)
    {
        _panelShower.CloseCurrentTab(data);
    }

    public void ShowTable()
    {
        _panelShower.ShowTablePanel();
    }

    public void DealCards()
    {
        DealCardAction?.Invoke();
    }
    
    public void DrawCards()
    {
        DrawCardAction?.Invoke();
    }

    public void ResetHoldOne()
    {
        ResetHoldOneAction?.Invoke();
    }

    public void ShowMiniGame()
    {
        MiniGameShowAction?.Invoke();
    }

    public void ShowButtonsPanel()
    {
        ShowButtonsPanelAction?.Invoke();
        MiniGameHideAction?.Invoke();
    }

    public void PickUpCredits()
    {
        PickUpCreditsAction?.Invoke();
    }
}
