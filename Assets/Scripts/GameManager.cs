using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runner
{
    public class GameManager : MonoBehaviour
    {
        private int _progress = 0;

        private float _step = 6f;
        private int _currentIndex = 0;
        private float _lastZ = 30f;
        private int _levelsLength = 1024 * 1024;

        [SerializeField, Range(1, 100), Tooltip("Это здоровье игрока, не перепутай")]
        private int Health = 3;
        [SerializeField]
        private Transform _player;
        [SerializeField]
        private Transform[] _levels;
        [SerializeField, Space]
        private Text _text;


        public static GameManager Self { get; private set; }

        private void Start()
        {
            StartCoroutine(FallDown());
        }
        void Awake()
        {
            Self = this;
        }

        private IEnumerator FallDown()
        {
            while (_player.position.y <= -1f)
            {
                if (Health > 0)
                {
                    SetDamage();
                }
            }
            yield return null;
        }

        public void SetDamage()
        {
            Health -= 1;

            Debug.Log("Current health: " + Health);

            if(Health <= 0)
            {
                Debug.Log("---Игрок погиб!---");
                Time.timeScale = 0;
            }
		}

        public void UpdateLevel()
        {
            _progress++;
            _text.text = _progress.ToString();// StringBuilder?
            _lastZ += _step;
            
            for(int i = 0; i < _levelsLength; i++)
            {
                var position = _levels[_currentIndex].position;
                position.z = _lastZ;
                _levels[_currentIndex].position = position;
            }

            _currentIndex++;
            if (_currentIndex >= _levels.Length)
            {
                _currentIndex = 0;
            }
	    }
    }
}