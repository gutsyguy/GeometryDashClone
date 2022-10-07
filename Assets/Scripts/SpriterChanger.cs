using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriterChanger : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeSprite()
    {
        spriteRender.sprite = newSprite;
    }
}
