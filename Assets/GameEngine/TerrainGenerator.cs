using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField]
    private int plusWidth = 100;
    [SerializeField]
    private int plusHeight = 0;
    private Tilemap tilemap;
    private Tile tileGrass;

    private GridManager gridManager;
    private int width;
    private int height;

    void Start()
    {
        this.tilemap = this.GetComponent<Tilemap>();
        this.tileGrass = loadTile("Textures/Terrain/grass");

        this.gridManager = GameObject.Find("BuildingSystem").GetComponent<GridManager>();
        this.width = this.gridManager.width + this.plusWidth;
        this.height = this.gridManager.height + this.plusHeight;

        this.tilemap.ClearAllTiles();
        generateTerrain();
    }

    void Update()
    {
        
    }

    private Tile loadTile(string textPath)
    {
        Tile tile = (Tile) ScriptableObject.CreateInstance("Tile");
        Texture2D texture = Resources.Load<Texture2D>(textPath);
        tile.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), texture.width, 1, SpriteMeshType.Tight, Vector4.zero); ;
        return tile;
    }

    private void generateTerrain()
    {
        for(int x = -width/2; x <= width/2; x++)
        {
            for (int y = -width / 2; y <= width / 2; y++)
            {
                this.tilemap.SetTile(new Vector3Int(x, y, 0), tileGrass);
            }
        }
    }
}
