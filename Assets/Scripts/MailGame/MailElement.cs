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

        private string _text;
        
        private void OnEnable()
        {
            _text = string.Empty;
            _focus.onClick.AddListener(SetFocus);
            _textMeshPro.SetText(_text);
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
            if (_text.Length >= _charLimit)
            {
                return;
            }

            _text = _text + arg0;
            _textMeshPro.SetText(_text);
        }

        public void DeleteLastChar()
        {
            if (string.IsNullOrEmpty(_text))
            {
                return;
            }
            
            _text = _text.Remove(_text.Length - 1);
            _textMeshPro.SetText(_text);
        }
    }
}