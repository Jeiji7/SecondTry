using Cinemachine;
using UnityEngine;
using Movement;
public class RoomSwitch : MonoBehaviour
{
    [SerializeField] private MovementInput _character;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private CinemachineVirtualCamera _activeCamera;
    [SerializeField] private CinemachineVirtualCamera _newCamera;
    [SerializeField] private Animator _fading;

    private const string StateName = "fadeStart";
    private const string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D character)
    {
        if (character.CompareTag(playerTag))
        {
            _fading.SetBool(StateName, true);
            _character.transform.position = _spawnPosition.position;
            _newCamera.gameObject.SetActive(true);
            _activeCamera.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _fading.SetBool(StateName, false);
    }
}
