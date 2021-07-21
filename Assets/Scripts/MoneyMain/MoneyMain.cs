using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class MoneyMain : MonoBehaviour
{
    [SerializeField] private int _moneyMultiply = 1;
    [SerializeField] private float[] _defaultMoneyBet = {0.25f, 0.5f, 1f, 2f, 5f};
    
    private int _currentMoneyBet;
    private float[] _moneyBet = {0.25f, 0.5f, 1f, 2f, 5f};
    private MoneyView _moneyView;

    #region Events

    public static Action<float> AddedCurrentCredits;
    public static Action<float> PutCoinsAction;
    public static Action ShowWinMenu;

    #endregion
    
    #region Enable/Disable

    private void OnEnable()
    {
        MainCardHolder.WinningCombination += AddedMoney;
        ButtonHandler.DealCardAction += PutCoins;
    }

    private void OnDisable()
    {
        MainCardHolder.WinningCombination -= AddedMoney;
    }

    #endregion

    private void Awake()
    {
        _moneyView = GetComponent<MoneyView>();
    }

    private void PutCoins()
    {
        PutCoinsAction?.Invoke(_moneyBet[_currentMoneyBet]);
    }
    
    public void ChangeMoneyMultiply(int value)
    {
        _moneyMultiply += value;
        _moneyMultiply = Mathf.Clamp(_moneyMultiply, 1, 5);

        for (int i = 0; i < _moneyBet.Length; i++)
        {
            var temp = _defaultMoneyBet[i];
            _moneyBet[i] =  temp * _moneyMultiply;
            _moneyView.SetBetUI(_moneyBet[_currentMoneyBet]);
        }
        
        _moneyView.SetTableText(_moneyMultiply);
        _moneyView.SetMoneyUI(_moneyMultiply);
    }
    
    public void ChangeMoneyBet(int value)
    {
        _currentMoneyBet += value;

        _currentMoneyBet = Mathf.Clamp(_currentMoneyBet, 0, 4);
        
        _moneyView.SetBetUI(_moneyBet[_currentMoneyBet]);
    }

    private void AddedMoney(int value)
    {
        var temp = value * _moneyBet[_currentMoneyBet];

        if (value == 250 && _moneyMultiply == 5)
        {
            temp = 4000;
        }

        _moneyView.SetWinBetUI(temp);

        AddedCurrentCredits?.Invoke(temp);
        ShowWinMenu?.Invoke();
    }
}
