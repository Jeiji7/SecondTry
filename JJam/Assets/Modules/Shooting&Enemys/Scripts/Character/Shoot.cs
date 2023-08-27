using UnityEngine;

internal class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPosirion;
    [SerializeField] private GameObject _bulletPrefab;

    internal void SpawnBullet()
    {
        Instantiate(_bulletPrefab, _bulletSpawnPosirion.position, transform.rotation);
    }

}
