using System.Collections;
using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerStatsComponent))]
    public abstract class BasePlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerStatsComponent _playerStatsComponent;
        protected virtual void Start()
        {
            StartCoroutine(MoveForward());
        }

        protected void Jump()
        {
            GetComponent<Rigidbody>().AddForce(transform.up * GetComponent<PlayerStatsComponent>().JumpForce, ForceMode.Impulse);
        }

        private IEnumerator MoveForward()
        {
            while(true)
            {
                transform.position += transform.forward * _playerStatsComponent.ForwardSpeed * Time.deltaTime;
                yield return null;
			}
		}
    }
}
