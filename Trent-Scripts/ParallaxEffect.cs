using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    private float lengthX, lengthY, startposX, startposY, distY;
    public GameObject cam;
    public float parallaxEffectInt;

    // Start is called before the first frame update
    void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
        distY = startposY;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float tempX = ((cam.transform.position.x + 10) * (1 - parallaxEffectInt));
        float distX = (cam.transform.position.x * parallaxEffectInt);

        float tempY = (cam.transform.position.y * (parallaxEffectInt * 0.5f));

        transform.position = new Vector3(startposX + distX, startposY, transform.position.z);

        if (tempX > startposX + lengthX) startposX += lengthX;
        else if (tempX < startposX - lengthX) startposX -= lengthX;

        if (tempY > startposY) startposY += tempY - startposY;
        else if (tempY < startposY && tempY > distY) startposY -= startposY - tempY;
        else startposY = distY;
    }
}
