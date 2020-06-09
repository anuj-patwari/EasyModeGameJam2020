using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCotroller : MonoBehaviour
{

    [SerializeField] Camera camera;
    [SerializeField] GameObject player;
    [SerializeField] float xOffset;
    [SerializeField] float zOffset;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(player.transform.position.x + xOffset, transform.position.y, player.transform.position.z + zOffset);
    }
}
