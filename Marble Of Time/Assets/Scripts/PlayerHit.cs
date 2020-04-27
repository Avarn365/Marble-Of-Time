using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public Material[] material;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            rend.sharedMaterial = material[1];
        }
    }
}
