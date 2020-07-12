using System.Collections.Generic;
using Helpers;
using UnityEngine;

namespace KeyboardScripts
{
    public class LetterPool : MonoBehaviour
    {
        private readonly KeyCode[] _lettersAvailable = {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z, 
            KeyCode.Keypad0, KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6, KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9, KeyCode.Space, KeyCode.LeftShift, KeyCode.LeftAlt, KeyCode.Comma, KeyCode.Return, KeyCode.Period, KeyCode.Backspace, KeyCode.Semicolon};

        public static LetterPool Instance;
        
        [SerializeField] private int _extraLetters = 8;
        [SerializeField] private int _lettersPerSpawn = 5;
        [SerializeField] private GameObject _defaultKey;
        [SerializeField] private GameObject _doubleKey;
        [SerializeField] private GameObject _fiveKey;
        [SerializeField] private GameObject _fourKey;
        
        private ComponentPool<KeyboardKey> _keyboardKeys;
        private Queue<KeyCode> _queue = new Queue<KeyCode>();
        private int _spawnedKeys = 0;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _queue = new Queue<KeyCode>(GetRandomList());
            _keyboardKeys = new ComponentPool<KeyboardKey>(40, _defaultKey, transform, Quaternion.identity);
            SpawnSomeKeys();
        }

        private List<KeyCode> GetRandomList()
        {
            List<KeyCode> keys = new List<KeyCode>(_lettersAvailable);

            for (int i = 0; i < 8; i++)
            {
                keys.Add(_lettersAvailable[Random.Range(0, _lettersAvailable.Length)]);
            }
            
            int n = keys.Count;  
            while (n > 1)
            {  
                n--;  
                int k = Random.Range(0, n + 1);  
                KeyCode value = keys[k];  
                keys[k] = keys[n];  
                keys[n] = value;  
            }

            return keys;
        }

        private void SpawnKey()
        {
            if (_queue.Count == 0)
            {
                _queue = new Queue<KeyCode>(GetRandomList());
                Debug.Log("RefillingQueue");
            }
            
            KeyCode keyToSpawn = _queue.Dequeue();

            GameObject go = null;
            KeyboardKey keyboardKey = null;
            
            switch (keyToSpawn)
            {
                case KeyCode.LeftShift:
                case KeyCode.Backspace:
                    go = Instantiate(_doubleKey, transform);
                    keyboardKey = go.GetComponent<KeyboardKey>();
                    break;
                case KeyCode.Space:
                    go = Instantiate(_fiveKey, transform);
                    keyboardKey = go.GetComponent<KeyboardKey>();
                    break;
                case KeyCode.Return:
                    go = Instantiate(_fourKey, transform);
                    keyboardKey = go.GetComponent<KeyboardKey>();
                   break;
                default:
                    keyboardKey = _keyboardKeys.GetComponent();
                    break;
            }

            keyboardKey.transform.position = transform.position;
            keyboardKey.gameObject.SetActive(true);
            keyboardKey.SetKey(keyToSpawn);
            _spawnedKeys++;
        }

        private void SpawnSomeKeys()
        {
            for (int i = 0; i < _lettersPerSpawn; i++)
            {
                SpawnKey();
            }
        }

        public void NewKeyJoined()
        {
            _spawnedKeys--;

            if (_spawnedKeys <= 0)
            {
                SpawnSomeKeys();
            }
        }
    }
}