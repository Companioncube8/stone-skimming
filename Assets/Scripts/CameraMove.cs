using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField] private GameObject player;
    private Vector3 offset;

    public bool CameraMoveOn = false;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        if (CameraMoveOn)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
