using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 4;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}
