using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class AtlasAnimation : MonoBehaviour
{
    public SpriteAtlas spriteAtlas; // 아틀라스 참조
    public float frameRate = 10f; // 초당 프레임 수

    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;
    private int currentFrame;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprites = new Sprite[spriteAtlas.spriteCount];
        spriteAtlas.GetSprites(sprites);

        currentFrame = 0;
        timer = 0f;
    }

    void Update()
    {
        if (sprites.Length == 0) return;

        timer += Time.deltaTime;

        if (timer >= 1f / frameRate)
        {
            timer -= 1f / frameRate;
            currentFrame = (currentFrame + 1) % sprites.Length;
            spriteRenderer.sprite = sprites[currentFrame];
        }
    }
}
