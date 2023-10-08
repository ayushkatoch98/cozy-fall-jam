using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnLocation;
    [SerializeField] private float deathYPosition;
    [Space]
    [SerializeField] private ScreenFade fade;
    void Update()
    {
        if (transform.position.y <= deathYPosition && !fade.isRespawing)
        {
            fade.RespawnTransition();
        }
    }
}
