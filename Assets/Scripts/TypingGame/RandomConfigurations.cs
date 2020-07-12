using UnityEngine;

namespace TypingGame
{
    [CreateAssetMenu(fileName = "RandomConfigurations", menuName = "Configurations/RandomConfigurations", order = 1)]
    public class RandomConfigurations : ScriptableObject
    {
        [SerializeField] private string[] _words;
        
        public string[] Words => _words;

        public string GetRandomWord()
        {
            return _words[Random.Range(0, _words.Length)];
        }
    }
}