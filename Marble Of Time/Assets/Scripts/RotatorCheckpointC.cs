using UnityEngine;
using System.Collections;

public class RotatorCheckpointC : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(15, 60, 75) * Time.deltaTime);
    }
}