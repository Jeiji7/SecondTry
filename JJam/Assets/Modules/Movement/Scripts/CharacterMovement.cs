using System.Collections;
using UnityEngine;

namespace Movement
{
    internal class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _movementSpeed;
        [SerializeField, Range(0.1f, 50)] private float _jumpForce;
        [SerializeField, Range(8000f, 15000)] private float _dashForce;
        [SerializeField] private TrailRenderer _tr;
        [SerializeField] private Animator _anim;

        private Rigidbody2D _rb;
        private PolygonCollider2D _collider;
        private bool _isRightDirection = true;
        private float _horizontal;

        private float _originalGravity;
        private bool _canDash = true;
        private bool _isDashing = false;
        private float _dashingTime = 0.2f;
        private float _dashingCooldown = 1f;

        private const float ÑheckRadius = 0.2f;
        private const string XAxis = "Horizontal";

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _collider = GetComponent<PolygonCollider2D>();
        }

        private void Update()
        {
            _horizontal = Input.GetAxisRaw(XAxis);
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_horizontal * _movementSpeed, _rb.velocity.y);
        }

        internal void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            if (Input.GetKeyDown(KeyCode.Space) && _rb.velocity.y > 0f)
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 1f);
        }

        internal void Flip()
        {
            if ((_isRightDirection && _horizontal < 0f) || (!_isRightDirection && _horizontal > 0f))
            {
                _isRightDirection = !_isRightDirection;
                transform.Rotate(0, 180, 0);
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, ÑheckRadius, _layerMask);
        }

        internal void StartDash()
        {
            if (_isDashing == true)
                return;
            if (Input.GetKeyDown(KeyCode.E) && _canDash)
            {
                _anim.SetBool("dashStart", true);
                StartCoroutine(Dash());
                _collider.isTrigger = true;
            }
            else
            {
                _collider.isTrigger = false;
                _anim.SetBool("dashStart", false);
            }
        }

        private IEnumerator Dash()
        {
            _canDash = false;
            _isDashing = true;
            _originalGravity = _rb.gravityScale;
            _rb.gravityScale = 0;
            _tr.emitting = true;
            if (_isRightDirection)
                _rb.AddForce(Vector2.right * _dashForce);
            else
                _rb.AddForce(Vector2.left * _dashForce);
            yield return new WaitForSeconds(_dashingTime);
            _tr.emitting = false;
            _rb.gravityScale = _originalGravity;
            _isDashing = false;
            yield return new WaitForSeconds(_dashingCooldown);
            _canDash = true;
        }
    }
}
