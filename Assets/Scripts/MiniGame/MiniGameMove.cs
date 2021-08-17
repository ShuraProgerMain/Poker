using DG.Tweening;
using UI.Buttons;
using UnityEngine;

namespace MiniGame
{
    public class MiniGameMove : MonoBehaviour
    {
        [SerializeField] private Transform mainCardHolder;
        private readonly float _offset = 5.5f;
        private Transform _mainTransform;

        #region Enable/Disable

        private void OnEnable()
        {
            ButtonHandler.MiniGameShowAction += () => ShowMiniGame();
            ButtonHandler.MiniGameHideAction += () => HideMiniGame();
        }

        #endregion

        private void Awake()
        {
            _mainTransform = GetComponent<Transform>();
        }

        private void HideMiniGame()
        {
            _mainTransform.DOMove(Vector3.right * _offset, 0.25f);
            mainCardHolder.DOMove(Vector3.zero, 0.25f);
        }

        private void ShowMiniGame()
        {
            _mainTransform.DOMove(Vector3.zero, 0.25f);
            mainCardHolder.DOMove(Vector3.right * _offset, 0.25f);

        }
    }
}
