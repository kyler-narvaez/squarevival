using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    [Range(-1f, 1f)] private float scrollSpeed;
    private float offset;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<Material>();
        scrollSpeed = 0.5f;
    }

    private void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("GrassBackground", new Vector2(offset, 0f));
    }
}
