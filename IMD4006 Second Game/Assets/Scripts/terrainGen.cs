using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainGen : MonoBehaviour
{
   public int depth = 0;
   public int width = 65;
   public int height = 65;
   public int maxDepth = 2;
   public int minDepth = 0;

   public float scale = 20;
    void Start (){
        Terrain terrain = GetComponent<Terrain>();
       terrain.terrainData = GenerateTerrain(terrain.terrainData);
       if (depth > maxDepth){
           depth = 2;
       } else if (depth < minDepth){
           depth = 0;
       }
    }
   void Update (){
       Terrain terrain = GetComponent<Terrain>();
       terrain.terrainData = GenerateTerrain(terrain.terrainData);
       if (depth > maxDepth){
           depth = 2;
       } else if (depth < minDepth){
           depth = 0;
       }
   }

   TerrainData GenerateTerrain (TerrainData terrainData){
       terrainData.heightmapResolution = width + 1;
       terrainData.size = new Vector3(width,depth,height);
       terrainData.SetHeights(0,0, GenerateHeights());
       return terrainData;
   }

   float[,] GenerateHeights () {
       float[,] heights = new float[width, height];
       for (int x = 0; x < width; x++){
           for (int y = 0; y < height; y++){
               heights[x,y] = CalculateHeight(x,y);
           }
       }
       return heights;
   }

   float CalculateHeight(int x, int y){
       float xCoord = (float)x / width * scale;
       float yCoord = (float)y / height * scale;

       return Mathf.PerlinNoise(xCoord, yCoord);
   }
}
