using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingAndEnemys
{
    internal class ShotTestActive : MonoBehaviour
    {
        [SerializeField] private ShootingInput _shooted;
        private void Awake()
        {
            _shooted.Activate();
        }
    }
}
