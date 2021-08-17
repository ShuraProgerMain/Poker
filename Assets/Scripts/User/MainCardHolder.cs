using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CardHolder;
using CardTemplate;
using Enums;
using UI.Buttons;
using UnityEngine;

namespace User
{
    public class MainCardHolder : MonoBehaviour
    {
        [SerializeField] private CardContainerRoot[] _cardContainers;

        private const int CARD_COUNT = 5;
        private TemplateCard[] _activeCards = new TemplateCard[5];

        #region Events

        public static Action<int> WinningCombination;
    
        #endregion

        #region Enable/Disable

        private void OnEnable()
        {
            ButtonHandler.DrawCardAction += () =>
            {
                CheckComplianceCards();
            };

            ButtonHandler.ResetHoldOneAction += () =>
            {
                HoldOneCardsReset();
            };
        }

        #endregion
    
        public void DistributeCards(TemplateCard[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (!_cardContainers[i].inactive)
                {
                    _cardContainers[i].AddCard(cards[i]);
                    _cardContainers[i].ShowCardImage();
                
                    _activeCards[i] = _cardContainers[i].currentCard;
                }
            }
        }

        public void CheckComplianceCards()
        {
            if (CheckNaturalRoyalFlush(_activeCards))
            {
                WinningCombination?.Invoke(250);
            }
            else if(CheckStraightFlush(_activeCards))
            {
                WinningCombination?.Invoke(50);
            }
            else if(CheckFourAKind(_activeCards))
            {
                WinningCombination?.Invoke(25);
            }
            else if(CheckFullHouse(_activeCards))
            {
                WinningCombination?.Invoke(9);
            }
            else if(CheckFlush(_activeCards))
            {
                WinningCombination?.Invoke(6);
            }
            else if(CheckStraight(_activeCards))
            {
                WinningCombination?.Invoke(4);
            }
            else if(CheckThreeOfAKind(_activeCards))
            {
                WinningCombination?.Invoke(3);
            }
            else if(CheckTwoParis(_activeCards))
            {
                WinningCombination?.Invoke(2);
            }
            else if(CheckJacksOfBetter(_activeCards))
            {
                WinningCombination?.Invoke(1);
            }
            else
            {
                StartCoroutine(DalayClear());
            }
        }

        private IEnumerator DalayClear()
        {
            yield return new WaitForSeconds(1f);
            ClearCards();
        }

        public void ClearCards()
        {
            foreach (var item in _cardContainers)
            {
                var temp = (CardContainerMain)item;
                temp.inactive = false;
                temp.SetState();
                temp.DeleteCard();
            }
        }
        private void HoldOneCards()
        {
            for (int i = 0; i < 5; i++)
            {
                var temp = (CardContainerMain)_cardContainers[i];
                temp.HoldOnCard();
            }
        }
        private void HoldOneCardsReset()
        {
            for (int i = 0; i < 5; i++)
            {
                var temp = (CardContainerMain)_cardContainers[i];
                temp.HoldOnCardReset();
            }
        }
        private void HoldOneCards(int[] carNums)
        {
            for (int i = 0; i < carNums.Length; i++)
            {            
                var temp = (CardContainerMain)_cardContainers[carNums[i]];
                temp.HoldOnCard();
            }
        }
        private bool CheckNaturalRoyalFlush(TemplateCard[] cards)
        {
            if (CheckCompliance(cards, (int) CardType.Ten, true))
            {
                HoldOneCards();
                return true;
            }

            return false;
        }
    
        private bool CheckStraightFlush(TemplateCard[] cards)
        {
            if (CheckCompliance(cards, (int) CardType.Two, true))
            {
                HoldOneCards();
                return true;
            }

            return false;
        }
    
        private bool CheckFourAKind(TemplateCard[] cards)
        {
            var temp = CheckCompliance(cards);

            var count = 0;
        
            for (int i = 0; i < temp.Count; i++)
            {
                var maxIdentical = 0;
            
                for (int j = 0; j < temp.Count; j++)
                {
                    if ((int)_activeCards[temp[i]].type == (int)_activeCards[temp[j]].type)
                    {
                        maxIdentical++;
                        Debug.Log("md " + maxIdentical);

                    }
                    else
                    {
                        maxIdentical--;
                        maxIdentical = Mathf.Clamp(maxIdentical, 0, 5);
                    }
                }
            
                count = maxIdentical;
            }
        
            if(count == 4)
            {
                HoldOneCards();
                return true;
            }
        
            return false;
        }
    
        private bool CheckFullHouse(TemplateCard[] cards)
        {
            var temp = CheckCompliance(cards);

            if (temp.Count == 5)
            {
                HoldOneCards(temp.ToArray());
                return true;
            }
        
            return false;
        }
    
        private bool CheckFlush(TemplateCard[] cards)
        {
            var temp = CheckSameSuits(cards);

            if (temp)
            {
                HoldOneCards();
                return true;
            }
        
            return false;
        }
    
        private bool CheckStraight(TemplateCard[] cards)
        {
            if (CheckCompliance(cards, (int) CardType.Two, false))
            {
                HoldOneCards();
                return true;
            }

            return false;
        }
    
        private bool CheckThreeOfAKind(TemplateCard[] cards)
        {
            var temp = CheckCompliance(cards);
        
            if (temp.Count == 3)
            {
                HoldOneCards(temp.ToArray());
                return true;
            }
        
            return false;
        }
    
        private bool CheckTwoParis(TemplateCard[] cards)
        {
            var temp = CheckCompliance(cards);
        
            if (temp.Count == 4)
            {
                HoldOneCards(temp.ToArray());
                return true;
            }
        
            return false;
        }
    
        private bool CheckJacksOfBetter(TemplateCard[] cards)
        {
            var temp = CheckCompliance(cards, CardType.Jack);
        
            if (temp.Count == 2)
            {
                HoldOneCards(temp.ToArray());
            
                return true;
            }
        
            return false;
        }


        private bool CheckSameSuits(TemplateCard[] cards)
        {
            for (int i = 0; i < CARD_COUNT - 1; i++)
            {
                if ((cards[i].subType != cards[Mathf.Clamp(i + 1, 0, CARD_COUNT)].subType))
                {
                    return false;
                }
            }
            return true;
        }
    
        private bool CheckCompliance(TemplateCard[] cards, int numberLimiter, bool isFlash)
        {
            List<int> nums = new List<int>();

            for (int i = 0; i < cards.Length; i++)
            {
                nums.Add((int)cards[i].type);
            }

            if (nums[0] >= numberLimiter)
            {
                if (isFlash)
                {
                    if (!CheckSameSuits(cards))
                    {
                        return false;
                    }
                }

                for (int i = 0; i < nums.Count - 1; i++)
                {
                    if (nums[i + 1] - nums[i] != 1)
                    {
                        return false;
                    }
                }
                return true;
            }
        
            return false;
        }
    
        private List<int> CheckCompliance(TemplateCard[] cards, CardType cardLimiter = CardType.Two)
        {
            List<int> nums = new List<int>();
            List<int> identicalNums = new List<int>(); //Место хранения одинаковых элементов. Может лучше сохранять их индексы?

            for (int i = 0; i < cards.Length; i++)
            {
                nums.Add((int)cards[i].type);
            }

            if (nums.Max() >= (int) cardLimiter)
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    for (int j = 0; j < nums.Count; j++)
                    {
                        var index = Mathf.Clamp(j + 1, 0, nums.Count - 1);
                    
                        if ((nums[i] >= (int) cardLimiter) && (nums[i] == nums[index]) && (i != index))
                        {
                            if (!identicalNums.Contains(i))
                            {
                                identicalNums.Add(i);
                            }
                            if (!identicalNums.Contains(index))
                            {
                                identicalNums.Add(index);
                            }
                            nums[index] += 100;
                        }
                    }
                }
            }

            return identicalNums;
        }
    }
}