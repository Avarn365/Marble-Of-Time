using UnityEngine;
using System.Collections;

public class Rotator500 : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(20, 40, 60) * Time.deltaTime);
    }
}