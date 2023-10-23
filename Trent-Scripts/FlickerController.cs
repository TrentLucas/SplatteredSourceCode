// Trent Lucas
// 25 June 2023

// Manages the light flickering
/////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerController : MonoBehaviour
{

    private bool isFlickering = false;
    private bool isFlickering2 = false;
    private bool isFlickering3 = false;
    public bool setToFlickerOnOff;
    public bool setToPulsate;
    private float delay;
    public Vector2 valueRange, delayRange;
    private float value;

    // Checks if light should flicker
    void Update()
    {

        if (setToFlickerOnOff) {
            if (!isFlickering2) {
                StartCoroutine(OnOffFlickeringLight());
            }
        } else if (setToPulsate) {
            if (!isFlickering3) {
                StartCoroutine(PulsatingLight());
            }
        } else {
            if (!isFlickering) {
                StartCoroutine(FlickeringLight());
            }
        }
    }

    // Looped function to flicker light on and off
    IEnumerator FlickeringLight() {
        isFlickering = true;

        value = Random.Range(valueRange.x, valueRange.y);
        this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = value;
        delay = Random.Range(delayRange.x, delayRange.y);
        yield return new WaitForSeconds(delay);

        value = Random.Range(valueRange.x, valueRange.y);
        this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = value;
        delay = Random.Range(delayRange.x, delayRange.y);
        yield return new WaitForSeconds(delay);

        isFlickering = false;
    }

    // Looped function to flicker light on and off
    IEnumerator OnOffFlickeringLight() {
        isFlickering2 = true;

        this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1.0f;
        yield return new WaitForSeconds(0.6f);

        this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = valueRange.y;
        yield return new WaitForSeconds(0.6f);

        isFlickering2 = false;
    }

    // Looped function to flicker light on and off
    IEnumerator PulsatingLight() {
        isFlickering3 = true;

        for (int i = 0; i < valueRange.x; i++) {
            valueRange.y -= delayRange.x;
            this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = valueRange.y;
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i < valueRange.x; i++) {
            valueRange.y += delayRange.x;
            this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = valueRange.y;
            yield return new WaitForSeconds(0.1f);
        }


        isFlickering3 = false;
    }
}
