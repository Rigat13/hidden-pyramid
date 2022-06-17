using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTrapAndSpawnLevel : MonoBehaviour
{
    public TrapDoor trapDoor;
    private bool hasFallen = false;
    public GameObject level;
    public Collider floorCollider;

    private void OnTriggerEnter(Collider other) 
    {
        if (!hasFallen && IsPlayer(other))
        {
            hasFallen = true;
            floorCollider.gameObject.SetActive(false);
            Spawn();
            trapDoor.OpenTrapDoor();
        }
    }

    private bool IsPlayer(Collider other) { return other.CompareTag(Parameter.PLAYER); }
    
    private void Spawn() { if(!level.activeSelf) level.SetActive(true); }
}

