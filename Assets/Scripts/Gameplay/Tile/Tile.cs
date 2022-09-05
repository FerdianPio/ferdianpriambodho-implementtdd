using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.Tile
{
    public class Tile : MonoBehaviour, IRaycastable
    {
        [SerializeField]private Vector2Int gridOnMap;
        public int id { get; private set; }
        public event System.Action<Vector2Int> OnTileClicked;

        public void OnRaycast()
        {
            OnTileClicked.Invoke(gridOnMap);
        }

        public void SetGridMap(Vector2Int map)
        {
            gridOnMap.x = map.x;
            gridOnMap.y = map.y;
        }

        public Vector2Int GetGridOnMap()
        {
            return gridOnMap;
        }

        public void SetId(int i)
        {
            id = i;
        }
    }

}
