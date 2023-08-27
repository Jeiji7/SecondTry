using UnityEngine;

namespace ShootingAndEnemys
{
    public class ShootingInput : MonoBehaviour
    {
        [SerializeField] private Shoot _shootedObject;
        //[SerializeField, Range(0.1f, 3f)] private float _bulletCoolDown;
        [SerializeField] private MeleeAttack _attachedObject;

        private bool _active = false;

        private void Update()
        {
            if (_active == false)
                return;
            CoolDown();
        }

        internal void CoolDown()
        {
            if (_attachedObject.CheckUlt() == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _shootedObject.SpawnBullet();
                    _attachedObject.ZeroingCounter();
                }
            }
        }
        public void Activate()
        {
            _active = true;
        }
        public void Deactivate()
        {
            _active = false;
        }
    }
}
