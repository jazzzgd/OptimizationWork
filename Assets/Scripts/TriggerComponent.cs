using UnityEngine;

namespace Runner
{
    public class TriggerComponent : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private bool _isDamage;

        private GameManager _gameManager;
        
        void Start()
        {
            _collider.isTrigger = true;
            _gameManager = GameManager.Self;
        }

		private void OnTriggerEnter(Collider other)
		{
            if (_isDamage)
            {
                _gameManager.SetDamage();
            }
            else
            {
                _gameManager.UpdateLevel();
			}
        }
	}
}