using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChanger : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    #region Events

    private void OnEnable()
    {
        MainCardHolder.WinningCombination += i =>
        {
            ShowNextButton(2);
        };
    }

    #endregion
    
    public void ShowNextButton(int index)
    {
        foreach (var item in _buttons)
        {
            item.gameObject.SetActive(false);
        }
        
        _buttons[index].gameObject.SetActive(true);
        
        
    }
}
