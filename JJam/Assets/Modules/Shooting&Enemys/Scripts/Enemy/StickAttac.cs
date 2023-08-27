using UnityEngine;
namespace ShootingAndEnemys
{
    internal class StickAttac : MonoBehaviour
    {
        [SerializeField, Range(1, 40)] private int _stickDamage;
        [SerializeField] private Transform _targetPlayer;
        [SerializeField] private Animator _animator;
       
        private void OnTriggerEnter2D(Collider2D collision)
        {
            CharacterStats character = collision.gameObject.GetComponent<CharacterStats>();
            if (character != null)
            {
                character.TakeDamage(_stickDamage);
                Debug.Log("Перс атакован");
            }
        }


    }
}
