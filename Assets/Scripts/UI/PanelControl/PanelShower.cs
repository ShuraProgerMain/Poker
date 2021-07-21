using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PanelShower : MonoBehaviour
{
    [SerializeField] private DataPanel _tablePanel;
    [SerializeField] private DataPanel _buttonPanel;
    [SerializeField] private DataPanel _minigamePanel;
    [SerializeField] private DataPanel _winPanel;

    #region Enable/Disable

    private void OnEnable()
    {
        MoneyMain.ShowWinMenu += () =>
        {
            ShowWinPanel();
        };

        ButtonHandler.ShowButtonsPanelAction += () => ShowButtonPanel();
        ButtonHandler.MiniGameShowAction += () => ShowMinigamePanel();
    }

    #endregion
    
    public void ShowTablePanel()
    {
        AnimationShow(_tablePanel);
    }
    
    public void ShowWinPanel()
    {
        AnimationShow(_winPanel);

    }

    public void ShowButtonPanel()
    {
        AnimationShow(_buttonPanel);
    }
    
    public void ShowMinigamePanel()
    {
        AnimationShow(_minigamePanel);
    }
    
    public void CloseCurrentTab(DataPanel data)
    {
        if (data.horizontalOffset)
        {
            data.currentTransform.DOAnchorPos(new Vector2(data.offset, 0), 0.35f);
        }
        else
        {
            data.currentTransform.DOAnchorPos(new Vector2(0, data.offset), 0.35f);
        }
    }

    private void AnimationShow(DataPanel data)
    {
        data.currentTransform.DOAnchorPos(Vector2.zero, 0.35f);
    }
}
