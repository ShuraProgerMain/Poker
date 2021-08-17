using UnityEngine;

namespace UI.PanelControl
{
    public class DataPanel : MonoBehaviour
    {
        public bool horizontalOffset;
        public float offset;
        public RectTransform currentTransform;

        private void Awake()
        {
            currentTransform = GetComponent<RectTransform>();
        }
    }
}
