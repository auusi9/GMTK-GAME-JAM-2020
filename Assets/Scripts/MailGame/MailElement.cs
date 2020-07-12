using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MailGame
{
    public class MailElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private MailThing _mailThing;
        [SerializeField] private Button _focus;
        [SerializeField] private int _charLimit = 500;

        private void OnEnable()
        {
            _focus.onClick.AddListener(SetFocus);
            _textMeshPro.SetText("");
        }

        private void SetFocus()
        {
            _mailThing.SetFocus(this);
        }
        
        private void OnDisable()
        {
            _focus.onClick.RemoveListener(SetFocus);
        }

        public void AddText(string arg0)
        {
            string text = _textMeshPro.text;

            if (text.Length >= _charLimit)
            {
                return;
            }
            
            _textMeshPro.SetText(text + arg0);
        }

        public void DeleteLastChar()
        {
            string text = _textMeshPro.text;
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            
            text = text.Remove(text.Length - 1);
            _textMeshPro.SetText(text);
        }
    }
}