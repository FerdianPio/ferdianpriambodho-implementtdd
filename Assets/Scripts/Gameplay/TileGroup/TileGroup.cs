using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MatchPicture.ThemeDatabase;
using UnityEngine.U2D;
using System.Linq;

namespace MatchPicture.TileGroup
{
    public class TileGroup : MonoBehaviour
    {
        [SerializeField] GameObject gridPrefab;
        [SerializeField] Vector2 gridSize;
        private GameObject[,] gameGrid;
        private SpriteAtlas spriteAtlas;
        public event System.Action onTilesCleared;

        //matching
        private Tile.Tile[] comparingArray=new Tile.Tile[2];

        void Start()
        {
            spriteAtlas = ThemeDatabase.ThemeDatabase.instance.GetSpriteAtlas(); 
            gameGrid = new GameObject[(int)gridSize.x, (int)gridSize.y];
            GenerateGrid(gridSize);
            SetRandomSprite();

            foreach(GameObject go in gameGrid)
            {
                go.GetComponent<Tile.Tile>().OnTileClicked += TryMatchClickedTiles;
            }
        }

        #region Generate Grid    
        private void GenerateGrid(Vector2 size)
        {
            for (int i = 0; i < gridSize.x; i++)
            {
                for (int j = 0; j < gridSize.y; j++)
                {
                    gameGrid[i, j] = Instantiate(gridPrefab, new Vector3(transform.position.x + i, transform.position.y + j, transform.position.z), Quaternion.identity, gameObject.transform);
                    gameGrid[i, j].GetComponent<Tile.Tile>().SetGridMap(new Vector2Int(i, j));
                }
            }
            CenterizeGrid(this.gameObject, size);
        }

        private Vector2 GetCenterTile(Vector2 size)
        {
            Vector2 result = new Vector2(0, 0);
            //get x
            if (size.x % 2 == 1) result.x = size.x / 2;
            else result.x = size.x / 2 - 0.5f;

            //get y
            if (size.y % 2 == 1) result.y = size.y / 2;
            else result.y = size.y / 2 - 0.5f;

            return result;
        }

        private void CenterizeGrid(GameObject grid, Vector2 size)
        {
            Vector2 center = GetCenterTile(size);
            grid.transform.position -= new Vector3(center.x, center.y, 0);
        }

        #endregion

        #region Set Sprite
        private void SetRandomSprite()
        {
            List<int> temp = new List<int>();
            int coupling = 2;
            int couplingId = RandomFromAtlas();
         
            //temporary indexing sprite
            for (int i = 0; i < gameGrid.Length; i++)
            {
                if (coupling == 0)
                {
                    coupling = 2;
                    couplingId = RandomFromAtlas();
                }
                    temp.Add(couplingId);
                    coupling--;
            }

            // random tmp (not yet)

            //set sprite
            int setSprite = 0;
            foreach(GameObject go in gameGrid)
            {
                go.gameObject.GetComponent<SpriteRenderer>().sprite = spriteAtlas.GetSprite(spriteAtlas.name + "_" + temp[setSprite]);
                go.gameObject.GetComponent<Tile.Tile>().SetId(temp[setSprite]);
                setSprite++;
            }
        }

        private int RandomFromAtlas()
        {
            return UnityEngine.Random.Range(0, spriteAtlas.spriteCount);
        }

        #endregion

        #region Matching
        private void TryMatchClickedTiles(Vector2Int obj)
        {
            /*if (comparingArray[0] != null)
            {
                comparingArray[1] = gameGrid[obj.x, obj.y].GetComponent<Tile.Tile>();
                if (comparingArray[0].id == comparingArray[1].id)
                {
                    foreach (Tile.Tile t in comparingArray)
                    {
                        gameGrid[t.GetGridOnMap().x, t.GetGridOnMap().y].SetActive(false);
                    }
                }
                else
                {
                    foreach (Tile.Tile t in comparingArray)
                    {
                        gameGrid[t.GetGridOnMap().x, t.GetGridOnMap().y].GetComponent<BoxCollider2D>().enabled=false;
                    }
                }
            }

            else
            {
                comparingArray[1] = gameGrid[obj.x, obj.y].GetComponent<Tile.Tile>();
            }*/
            gameGrid[obj.x, obj.y].SetActive(false);
        }
        #endregion
    }

}
