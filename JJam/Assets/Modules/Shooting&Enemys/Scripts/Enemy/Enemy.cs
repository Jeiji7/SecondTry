using UnityEngine;

namespace ShootingAndEnemys
{
    internal class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private float _speed;
        [SerializeField] internal Transform _targetPlayer;
        [SerializeField] private bool _isRightDirection;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _layerMask;

        private Rigidbody2D _rb;
        private float _distance;

        private const float _distanceRange = 1.05f;
        private const float ÑheckRadius = 0.05f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            MoveToTarget();
            Flip();
        }

        private void MoveToTarget()
        {
            _distance = Vector2.Distance(transform.position, _targetPlayer.position);
            if (_distance <= _distanceRange)
            {
                _rb.velocity = Vector2.zero;
                _rb.bodyType = RigidbodyType2D.Kinematic;
            }
            else
            {
                _rb.bodyType = RigidbodyType2D.Dynamic;
                if (IsGrounded())
                {
                    Vector2 direction = (_targetPlayer.position - transform.position).normalized;
                    _rb.velocity = direction * _speed;
                }
                else
                    _rb.velocity = Vector2.zero;
            }
        }
        internal void Flip()
        {
            if ((_isRightDirection && (_targetPlayer.transform.position.x < transform.position.x))
                || (!_isRightDirection && (_targetPlayer.transform.position.x > transform.position.x)))
            {
                _isRightDirection = !_isRightDirection;
                transform.Rotate(0, 180, 0);
            }
        }
        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, ÑheckRadius, _layerMask);
        }
        public void TakeDamage(int damage)
        {
            if (_isRightDirection)
                transform.position = new Vector2(transform.position.x - 0.7f, transform.position.y);
            else
                transform.position = new Vector2(transform.position.x + 0.7f, transform.position.y);
            _health -= damage;
            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}
