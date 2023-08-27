using UnityEngine;

namespace Movement
{
    public class MovementInput : MonoBehaviour
    {
        private bool _active = false;

        [SerializeField] private CharacterMovement _character;
        private void Update()
        {
            if (_active == false)
                return;
            _character.Flip();
            _character.Jump();
            _character.StartDash();

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
