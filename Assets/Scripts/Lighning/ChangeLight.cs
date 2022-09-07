using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    private Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            light.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        }
    }
}
