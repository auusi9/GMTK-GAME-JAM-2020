using KeyboardScripts;
using TMPro;
using UnityEngine;

namespace TypingGame
{
    public class TypingGame : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _randomWordText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _customInput;
        [SerializeField] private RandomConfigurations _config;

        private string _randomWord;
        private string _currentInput;
        private int _score = 0;
        
        private void Start()
        {
            TypingListener.Instance.NewLetter += NewLetter;
        }

        private void OnDestroy()
        {
            TypingListener.Instance.NewLetter -= NewLetter;
        }

        private void OnEnable()
        {
            _score = 0;
            _scoreText.SetText(_score.ToString());
            NewRandomWord();
        }

        private void NewLetter(string letter)
        {
            if (_randomWord.StartsWith(letter))
            {
                _randomWord = _randomWord.Remove(0, 1);
                _currentInput += letter;
                _customInput.SetText(_currentInput);
                _randomWordText.SetText(_randomWord);

                if (string.IsNullOrEmpty(_randomWord))
                {
                    _score++;
                    _scoreText.SetText(_score.ToString());
                    NewRandomWord();
                }
            }
            else
            {
                Failed();
            }
        }

        private void Failed()
        {
            _currentInput = "";
            _customInput.SetText(_currentInput);
            NewRandomWord();
        }

        private void NewRandomWord()
        {
            _randomWord = _config.GetRandomWord();
            _randomWordText.SetText(_randomWord);
        }
    }
}