using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject player;
    private Transform tf;
    public GameObject[] enemy;
    //public int enemyAmount;
    public static int enemyAmount = 5;
    public GameObject support;

    public GameObject[] powerups;
    public int itemAmount;
    private int itemIndex = 0;

    public GameObject[] tiles;
    public GameObject wall;

    public List<Vector3> createdTiles;
    public List<Vector3> createdItems;

    public int tileAmount;
    public int tileSize;


    public float chanceUp;
    public float chanceRight;
    public float chanceDown;

    //wall generation
    public float minY = 999999;
    public float maxY = 0;
    public float minX = 999999;
    public float maxX = 0;
    public float xAmount;
    public float yAmount;
    public float extraWallX;
    public float extraWallY;

    public float waitTime;
    //private GameObject cam;


    void Start()
    {
       StartCoroutine(GenerateLevel());
       tf = GameObject.Find("soldier_1h(Clone)").transform;
    }

    void Update() 
    {
        
    }

     IEnumerator GenerateLevel()
        {

            for(int i = 0; i < tileAmount; i++)
            {
                float dir = Random.Range(0f, 1f); //0-3 untuk menentukan arahnya, 0=up 1=right 2=down 3=left
                int tile = Random.Range(0, tiles.Length);

                CreateTile(tile);
                CallMoveGen(dir);

                yield return new WaitForSeconds(waitTime);

                 if (i == tileAmount - 1)
                 {
                     Finish(); // apakah finish perlu?
                 }
            }

            yield return 0;
        }

        void CallMoveGen(float ranDir)
        {
            if(ranDir < chanceUp)
            {
                MoveGen(0); //0 itu atas
            }else if(ranDir < chanceRight)
            {
                MoveGen(1); // 1 itu kanan
            }else if(ranDir < chanceDown)
            {
                MoveGen(2); // 2 itu kiri
            }else
            {
                MoveGen(3); // 3 itu kanan
            }


        }

        void MoveGen(int dir)

        {
            switch(dir)
            {
                case 0:

                    transform.position = new Vector3(transform.position.x, transform.position.y + tileSize, 0);

                    break;

                case 1:

                    transform.position = new Vector3(transform.position.x + tileSize, transform.position.y , 0);

                    break;

                case 2:

                    transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, 0);

                    break;

                case 3:

                    transform.position = new Vector3(transform.position.x - tileSize, transform.position.y , 0);

                    break;
            }
        }

        void CreateTile(int tileIndex)
        {

            if(!createdTiles.Contains(transform.position))
            {
            GameObject tileObject;

            tileObject = Instantiate(tiles[tileIndex], transform.position, transform.rotation) as GameObject;

            createdTiles.Add(tileObject.transform.position);
            }
            else
            {
                tileAmount++;
            }
            
        }

        void Finish()
        {
            CreateWallValues();
            CreateWalls();
            SpawnObjects();
        }

        void SpawnObjects()
        {
            
            Instantiate(player, createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity);
            //belakang sendiri ganti Quaternion.identity

            //Instantiate(support, createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity);

            for(int i = 0; i < enemyAmount; i++)
            {
                Instantiate(enemy[Random.Range(0,5)], createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity);
            }

            //Instantiate(powerups[enemyAmount], createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity);
            CreatePowerUps(itemIndex);

            
        }

        void CreateWallValues()
        {
            for(int i = 0; i < createdTiles.Count; i++)
            {
                 if(createdTiles[i].y < minY)
                 {
                    minY = createdTiles[i].y;
                 }

                if(createdTiles[i].y > maxY)
                {
                    maxY = createdTiles[i].y;
                }

                if(createdTiles[i].x < minX)
                {
                    minX = createdTiles[i].x;
                }

                if(createdTiles[i].x > maxX)
                {
                    maxX = createdTiles[i].x;
                }

                xAmount = ((maxX - minX) / tileSize) + extraWallX; //max-min untuk ambil jaraknya, terus dibagi tilesize
                yAmount = ((maxY - minY) / tileSize) + extraWallY; //untuk tahu berapa tiles yang harus diletakkan

            }
           
        }

        void CreateWalls()
        {
            for(int x = 0; x < xAmount; x++)
            {

                for(int y = 0; y < yAmount; y++)
                {
                    if(!createdTiles.Contains(new Vector3((minX - (extraWallX * tileSize / 2) + (x * tileSize)) , (minY - (extraWallY * tileSize / 2) + (y * tileSize)))))
                    {
                        Instantiate(wall, new Vector3((minX - (extraWallX * tileSize / 2) + (x * tileSize)) , (minY - (extraWallY * tileSize / 2) + (y * tileSize))), transform.rotation);
                    }
                }
            }

            AstarPath.active.Scan();
        }

        void CreatePowerUps(int itemIndex)
        {

            //if(!createdItems.Contains(transform.position))
            for(int j = 0; j < itemAmount; j++)
            {
            GameObject itemObject;

            itemObject = Instantiate(powerups[itemIndex], createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity) as GameObject;
            //Instantiate(player, createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity);

            createdItems.Add(itemObject.transform.position);
            
            itemIndex++;
            }
            
        }
}
