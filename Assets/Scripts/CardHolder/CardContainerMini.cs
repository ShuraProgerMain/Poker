using MiniGame;
using UnityEngine;

namespace CardHolder
{
    public class CardContainerMini : CardContainerRoot
    {
        private MiniGameCardHolder _miniGameCardHolder;

        public override void AwakeCustom()
        {
            _miniGameCardHolder = transform.parent.GetComponent<MiniGameCardHolder>();
        }
    
        private void OnMouseDown()
        {
            if (!inactive)
            {
                CheckCards();
                ShowCardImage();
            }
        }

        private void CheckCards()
        {
            var temp = _miniGameCardHolder.CardComparsion((int)currentCard.type);

            if (temp)
            {
                Debug.Log("молодец");
            }
            else
            {
                Debug.Log(" NE молодец");
            }
        
            _miniGameCardHolder.ShowAllCardImage();
        }
    }
}
