using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingAndEnemys
{
    public class MeleeAttack : MonoBehaviour
    {
        [SerializeField, Range(1, 40)] private int _stickDamage;
        [SerializeField, Range(0.1f, 3f)] private float _stickCoolDown;

        private Animator _animator;
        private float _lastFiredTime;
        private bool _canDamage;
        private int _counterToUlt;
        private const int CountToUlt = 5;

        private void Start()
        {
            _animator = GetComponent<Animator>();

            _counterToUlt = 0;
            _canDamage = true;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse1))
                _animator.SetBool("attackStart", true);
            else
                _animator.SetBool("attackStart", false);

            if (CoolDown() == true)
                _canDamage = true;
            CoolDown();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            MakeDamage(collision);
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            MakeDamage(collision);
        }
        public bool CheckUlt()
        {
            if (_counterToUlt == CountToUlt)
                return true;
            else return false;

        }
        public void ZeroingCounter()
        {
            _counterToUlt = 0;
        }

        internal bool CoolDown()
        {
            if (Time.time - _lastFiredTime >= _stickCoolDown)
            {
                _lastFiredTime = Time.time;
                return true;
            }
            else return false;
        }
        private void MakeDamage(Collider2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null && _canDamage == true)
            {
                enemy.TakeDamage(_stickDamage);
                Debug.Log($"Урон прошел: {_stickDamage}");
                _canDamage = false;
                if (CheckUlt() == false)
                    _counterToUlt += 1;
                else
                    _counterToUlt = CountToUlt;

            }
        }
    }
}
