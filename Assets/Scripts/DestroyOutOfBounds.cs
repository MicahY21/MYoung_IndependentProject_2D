using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topOfScene = 30.0f;
    private float bottomOfScene = -0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topOfScene)
        {
            Destroy(gameObject);
        }

        else if (transform.position.y < bottomOfScene)
        {
            Destroy(gameObject);
        }
    }
}
