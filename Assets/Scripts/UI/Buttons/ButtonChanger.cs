using UnityEngine;
using UnityEngine.UI;
using User;

namespace UI.Buttons
{
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
}
