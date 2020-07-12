using KeyboardScripts;
using MailGame;
using TMPro;
using UnityEngine;

public class MailThing : MonoBehaviour
{
        private MailElement _mailElement;

        private void OnEnable()
        {
                TypingListener.Instance.NewLetter += NewLetter;
                TypingListener.Instance.NewDelete += NewDelete;
        }

        private void NewDelete()
        {
                _mailElement.DeleteLastChar();
        }

        private void NewLetter(string arg0)
        {
                _mailElement?.AddText(arg0);
        }

        public void SetFocus(MailElement mailElement)
        {
                _mailElement = mailElement;
        }
}