using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    //bg scroller
    public float bgscrollSpeed;
    public GameObject[] backgrounds;
    public float[] scrollSpeed;
    

    private void FixedUpdate()
    {
        for (int background = 0; background < backgrounds.Length; background++)
        {
            Renderer renderer = backgrounds[background].GetComponent<Renderer>();

            float offset = Time.time * (scrollSpeed[background] * bgscrollSpeed);

            renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
  
}
