using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScroller : MonoBehaviour
{

    [SerializeField] private RawImage _img;
    [SerializeField] private Rigidbody2D player;

    void Update()
    {
        if (!player.IsSleeping())
        {
            _img.uvRect = new Rect(_img.uvRect.position + new Vector2(player.position.x, player.position.y) * Time.deltaTime, _img.uvRect.size);
        }
        
    }
}
