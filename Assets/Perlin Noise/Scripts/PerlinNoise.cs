using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    [Range(1.0f, 200.0f)]
    public float scale = 20f;
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        //GENERATE A PERLIN NOISE MAP

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x,y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();



        return texture;

    }

    Color CalculateColor(int x, int y)
    {
        float sample = Mathf.PerlinNoise((float)x/width * scale , (float)y/height * scale);
        return new Color (sample, sample, sample); 
    }
}
