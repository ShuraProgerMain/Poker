using CardTemplate;
using UnityEngine;

namespace CardHolder
{
    public abstract class CardContainerRoot : MonoBehaviour
    {
        public bool inactive;
    
        [SerializeField] protected Color _defaultColor = Color.white;
        [SerializeField] protected Color _inactiveColor = Color.white;
    
        public TemplateCard currentCard { get; private set; }
        protected SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            AwakeCustom();
        }

        public virtual void AwakeCustom()
        {
        
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                DeleteCard();
            }
        }
    
        public void AddCard(TemplateCard card)
        {
            currentCard = card;
        }

        public void ShowCardImage()
        {
            _renderer.sprite = currentCard.cardImage;
        }

        public void DeleteCard()
        {
            currentCard = null;
            _renderer.sprite = Resources.Load<Sprite>("Image/Sample");
        }
    }
}
