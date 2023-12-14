using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 5f, -10f);
    }
}
