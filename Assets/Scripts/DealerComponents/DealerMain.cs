using System.Collections.Generic;
using CardTemplate;
using MiniGame;
using UnityEngine;
using User;
using Random = UnityEngine.Random;

namespace DealerComponents
{
    public class DealerMain : MonoBehaviour
    {
        [SerializeField] private MainCardHolder _mainCardHolder;
        [SerializeField] private MiniGameCardHolder _miniCardHolder;
    
        [SerializeField] private TemplateCard[] _allCards;

        private List<int> randoms = new List<int>();
    
        private void Awake()
        {
            _allCards = Resources.LoadAll<TemplateCard>("Cards");

            foreach (var item in _allCards)
            {
                item.Initialize();
            }
        }

        private List<int> RandomCardDraft()
        {
            var temp = new List<int>();
        
            for (int i = 0; i < 5; i++)
            {
                var num = Random.Range(0, _allCards.Length);

                if (!randoms.Contains(num))
                {
                    temp.Add(num);
                }
                else
                {
                    i--;
                }
            }

            return temp;
        }

        public void DealMiniGameCard()
        {
            var temp = RandomCardDraft();

            var randomCards = GetRandomCards(temp);
        
            _miniCardHolder.DistributeCards(randomCards.ToArray());
        }
    
        public void DrawCard()
        {
            var temp = RandomCardDraft();

            var randomCards = GetRandomCards(temp);
        
            _mainCardHolder.DistributeCards(randomCards.ToArray());
        }

        private List<TemplateCard> GetRandomCards(List<int> tempRandom) 
        {
            var randomCards = new List<TemplateCard>();

            foreach (var item in tempRandom)
            {
                randomCards.Add(_allCards[item]);   
            }

            return randomCards;
        }
    
        public void DealCards()
        {
            randoms.Clear();
        
            _mainCardHolder.ClearCards();
        
            randoms = RandomCardDraft();

            var randomCards = GetRandomCards(randoms);

            _mainCardHolder.DistributeCards(randomCards.ToArray());

            // for (int i = 0; i < 5; i++)
            // {
            //     var num = Random.Range(0, _allCards.Length);
            //
            //     if (!randoms.Contains(num))
            //     {
            //         randoms.Add(num);
            //     }
            //     else
            //     {
            //         i--;
            //     }
            // }


            // foreach (var item in randoms)
            // {
            //     randomCards.Add(_allCards[item]);   
            // }
        
            //TODO удалить
            // randomCards.Add(_allCards[10]);   
            // randomCards.Add(_allCards[0]);   
            // randomCards.Add(_allCards[36]);   
            // randomCards.Add(_allCards[4]);   
            // randomCards.Add(_allCards[17]);   
        


        }
    }
}
