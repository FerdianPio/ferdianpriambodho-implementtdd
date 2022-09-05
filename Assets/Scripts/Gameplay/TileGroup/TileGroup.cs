using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.TileGroup
{
    public class TileGroup : MonoBehaviour
    {
        [SerializeField] GameObject gridPrefab;
        [SerializeField] Vector2 gridSize;
        private GameObject[,] gameGrid;
        public event System.Action onTilesCleared;
        void Start()
        {
            gameGrid = new GameObject[(int)gridSize.x, (int)gridSize.y];
            GenerateGrid(gridSize);
        }

        private void GenerateGrid(Vector2 size)
        {
            for(int i = 0; i < gridSize.x; i++)
            {
                for(int j = 0; j < gridSize.y; j++)
                {
                    gameGrid[i, j] = Instantiate(gridPrefab, new Vector3(transform.position.x+i,transform.position.y+j,transform.position.z),Quaternion.identity, gameObject.transform);
                }
            }
            CenterizeGrid(this.gameObject, size);
        }

        private Vector2 GetCenterTile(Vector2 size)
        {
            Vector2 result=new Vector2(0,0);
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
            Debug.Log(center.x);
            grid.transform.position -= new Vector3(center.x,center.y,0);
        }
    }

}
