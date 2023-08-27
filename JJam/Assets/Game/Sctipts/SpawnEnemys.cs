using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField] private GameObject spawner1;
    [SerializeField] private GameObject spawner2;


    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
