using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class AtlasAnimation : MonoBehaviour
{
    public string atlasName; // 아틀라스 파일명
    public float frameRate = 10f; // 초당 프레임 수

    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;
    private int currentFrame;
    private float timer;
    private SpriteAtlas spriteAtlas;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        LoadAtlas();
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

    public void LoadAtlas()
    {
        if (string.IsNullOrEmpty(atlasName)) return;

        // "Resources/Altas/파일명" 형식으로 아틀라스 로드
        spriteAtlas = Resources.Load<SpriteAtlas>($"Altas/{atlasName}");
        if (spriteAtlas == null)
        {
            Debug.LogError($"SpriteAtlas '{atlasName}' not found in Resources/Altas/");
            return;
        }

        sprites = new Sprite[spriteAtlas.spriteCount];
        spriteAtlas.GetSprites(sprites);

        currentFrame = 0;
        timer = 0f;
    }

    public void SetAtlasName(string newAtlasName)
    {
        atlasName = newAtlasName;
        LoadAtlas();
    }
}
