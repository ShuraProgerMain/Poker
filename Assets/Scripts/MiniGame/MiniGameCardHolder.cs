using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCardHolder : MonoBehaviour
{
    [SerializeField] private CardContainerRoot[] _cardContainers; 
    
    private const int _cardCount = 5;

    private TemplateCard[] _activeCards = new TemplateCard[5];

    #region Events

    public static Action<int> MiniGameResult;

    #endregion
    
    public void DistributeCards(TemplateCard[] cards)
    {
        _cardContainers[0].AddCard(cards[0]);
        _cardContainers[0].ShowCardImage();
        
        for (int i = 1; i < _cardCount; i++)
        {
            if (!_cardContainers[i].inactive)
            {
                _cardContainers[i].DeleteCard();
                _cardContainers[i].AddCard(cards[i]);
                _activeCards[i] = _cardContainers[i].currentCard;
            }
        }
    }

    public bool CardComparsion(int rank)
    {
        var temp = (int) _cardContainers[0].currentCard.type < rank;

        if (temp)
        {
            MiniGameResult?.Invoke(2);
        }
        else
        {
            MiniGameResult?.Invoke(0);
        }
        
        return temp;
    }

    public void ShowAllCardImage()
    {
        for (int i = 1; i < _cardCount; i++)
        {
            _cardContainers[i].ShowCardImage();
        }
    }
}
