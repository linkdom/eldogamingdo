using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    Transform camera;
    GameObject background;

    void Start() {
        camera = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(camera.position.x, transform.position.y, 1);
        
    }
}
