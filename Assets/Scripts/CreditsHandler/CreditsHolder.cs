using MiniGame;
using UI.Buttons;
using UI.CreditsView;
using UnityEngine;

namespace CreditsHandler
{
    public class CreditsHolder : MonoBehaviour
    {
        private float _activeCreditsCount = 0;
    
        [SerializeField] private float _currentCredits =  2000;

        private CreditsView _creditsView;

        #region Enable/Disable

        private void OnEnable()
        {
            MoneyMain.MoneyMain.AddedCurrentCredits += f => SetActiveCredits(f);
            ButtonHandler.PickUpCreditsAction += () => SetCredits(_activeCreditsCount);
            MiniGameCardHolder.MiniGameResult += f => SetActiveCredits(_activeCreditsCount * f);
            MoneyMain.MoneyMain.PutCoinsAction += f => SetCredits(-f);
        }

        #endregion
    
        private void Awake()
        {
            _creditsView = GetComponent<CreditsView>();
            _creditsView.SetCreditsText(_currentCredits);
        }

        public void SetCredits(float credits)
        {
            if (_activeCreditsCount >= 0)
            {
                _currentCredits += credits;
            }
        
            _creditsView.SetCreditsText(_currentCredits);
        }

        public void SetActiveCredits(float count)
        {
            _activeCreditsCount = count;
            _creditsView.SetMiniGameCredits(count);
        }
    }
}
