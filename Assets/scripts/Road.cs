using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    //Road movement
    private new Renderer renderer;
    public float speed = 0.6f;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0f);
        renderer.material.mainTextureOffset = offset;
    }
}
