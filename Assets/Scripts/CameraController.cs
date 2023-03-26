using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    float yValue;
    // Start is called before the first frame update
    void Start()
    {
        yValue = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.position;
        transform.position = new Vector3(playerPos.x + offset.x, 0, 0);
    }
}
