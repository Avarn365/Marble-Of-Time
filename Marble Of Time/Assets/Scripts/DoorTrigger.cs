using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    bool isOpened = false;

    public int movex;
    public int movey;
    public int movez;

    void OnTriggerEnter(Collider col)
    {
        if(isOpened == false)
        {
            door.transform.position += new Vector3(movex, movey, movez);
            isOpened = true;
        }
    }
}
