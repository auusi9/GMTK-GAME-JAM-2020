using KeyboardScripts;
using TMPro;
using UnityEngine;

namespace TypingGame
{
    public class TypingGame : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _randomWordText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _timer;
        [SerializeField] private TextMeshProUGUI _customInput;
        [SerializeField] private float _gameDuration;
        [SerializeField] private RandomConfigurations _config;
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private TextMeshProUGUI _gameOverText;

        private string _randomWord;
        private string _currentInput;
        private int _score = 0;
        private int _currentWordScore = 0;
        private float _currentDuration = 0f;
        private bool _timesUp = false;

        private void OnEnable()
        {
            _timesUp = false;
            _currentDuration = 0f;
            TypingListener.Instance.NewLetter += NewLetter;
            _score = 0;
            
            _scoreText.SetText(_score.ToString());
            NewRandomWord();
            _gameOverScreen.SetActive(false);
                
        }

        private void OnDisable()
        {
            TypingListener.Instance.NewLetter -= NewLetter;
        }

        private void Update()
        {
            if (_gameDuration - _currentDuration > 0)
            {
                _timer.SetText("{0}", _gameDuration - _currentDuration);
                _currentDuration += Time.deltaTime;
                return;
            }

            _timesUp = true;
            _timer.SetText("0");
            _gameOverScreen.SetActive(true);
            _gameOverText.SetText(_score.ToString());
        }

        private void NewLetter(string letter)
        {
            if (_timesUp)
            {
                return;
            }
            
            if (_randomWord.StartsWith(letter))
            {
                _randomWord = _randomWord.Remove(0, 1);
                _currentInput += letter;
                _customInput.SetText(_currentInput);
                _randomWordText.SetText(_randomWord);

                if (string.IsNullOrEmpty(_randomWord))
                {
                    _score += _currentWordScore;
                    _scoreText.SetText(_score.ToString());
                    _currentInput = "";
                    _customInput.SetText(_currentInput);
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
            _currentWordScore = _randomWord.Length;
        }
    }
}