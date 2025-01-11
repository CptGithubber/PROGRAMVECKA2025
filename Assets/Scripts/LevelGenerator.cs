using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;

    public ColorToPrefab[] colorMappings;

    public void GenerateTile(int x, int y)
    {
        //setts pixel color to the color on the map
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            //Ignors transparrent pixeles
            return;
        }
        //For every black pixel it places a ground prefab at that location
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(Mathf.RoundToInt(x), Mathf.RoundToInt(y));
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
    public void GenerateLevel()
    {
        //Checks every pixel on the x and y axies for color
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }
    public void Start()
    {
        GenerateLevel();
        AstarPath.active.Scan();
    }


}
