using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildHazRot : MonoBehaviour
{
    public float rotateX = 0;
    public float rotateY = 0;
    public float rotateZ = 0;

    void Update()
    {
        transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
    }
}
