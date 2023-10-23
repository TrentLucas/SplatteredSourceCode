using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Load : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Load")) {
            Debug.Log("on");
            Light2D lightComponent = other.GetComponent<Light2D>();
            if (lightComponent != null)
            {
                lightComponent.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Load")) {
            Debug.Log("off");
            Light2D lightComponent = other.GetComponent<Light2D>();
            if (lightComponent != null)
            {
                lightComponent.enabled = false;
            }
        }
    }
}
