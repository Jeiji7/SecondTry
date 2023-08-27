using UnityEngine;

namespace ShootingAndEnemys
{
    internal class Bullet : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _lifeTime;
        [SerializeField, Range(1, 40)] private int _bulletDanage;
        private Rigidbody2D _bullet;

        private void Awake()
        {
            _bullet = GetComponent<Rigidbody2D>();
            _bullet.velocity = transform.right * _bulletSpeed;
            Destroy(gameObject, _lifeTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                    enemy.TakeDamage(_bulletDanage);
                Destroy(gameObject);
            }
        }

    }
}
