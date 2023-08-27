using UnityEngine;

namespace ShootingAndEnemys
{
    internal class CharacterStats : MonoBehaviour
    {
        [SerializeField] private int _health;
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
                Debug.Log("Герой типа умер");        }

    }
}
