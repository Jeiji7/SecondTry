using UnityEngine;

namespace Movement
{
    internal class MoveTestActive : MonoBehaviour
    {
        [SerializeField] private MovementInput _character;
        private void Awake()
        {
            _character.Activate();  
        }
    }
}
