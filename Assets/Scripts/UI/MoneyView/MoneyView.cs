using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Text _valueWinBet;
    [SerializeField] private Text _valueBet;
    [SerializeField] private Text _valueMoney;
    [SerializeField] private Text[] _tableTexts;
    
    private int[] _defaultTableTexts = {250, 50, 25, 9, 6, 4, 3, 2, 1};
    public void SetWinBetUI(float value)
    {
        Debug.Log("VAR vin value" + value);
        
        _valueWinBet.text = value.ToString();
    }
    
    public void SetBetUI(float value)
    {
        _valueBet.text = value.ToString();
    }
    
    public void SetMoneyUI(int value)
    {
        _valueMoney.text = value.ToString();
    }

    public void SetTableText(int multipyCount)
    {
        for (int i = 0; i < _defaultTableTexts.Length; i++)
        {
            _tableTexts[i].text = (_defaultTableTexts[i] * multipyCount).ToString();
        }

        if (multipyCount == 5)
        {
            _tableTexts[0].text = 4000.ToString();
        }
    }
}
