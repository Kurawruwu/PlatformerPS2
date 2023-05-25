using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float lagAmount = 0f;
    Vector3 previousCameraPosition;
    Transform _camera;
    Vector3 targetPosition;

    float ParallaxAmount => 1f - lagAmount;
    private void Awake()
    {
        _camera = Camera.main.transform;
        previousCameraPosition = _camera.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3  movement = CameraMovement;
        if (movement == Vector3.zero) return;
        targetPosition = new Vector3(transform.position.x + movement.x * ParallaxAmount, transform.position.y, transform.position.z);
        transform.position = targetPosition;
    }

    Vector3 CameraMovement
    {
        get
        {
            Vector3 movement = _camera.position - previousCameraPosition;
            previousCameraPosition = _camera.position;
            return movement;
        }
    }
}
