using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace MatchPicture.ThemeDatabase
{
    public class ThemeDatabase : MonoBehaviour
    {
        [SerializeField] private SpriteAtlas[] spriteAtlas;
        private int activeAtlasId=0;

        public static ThemeDatabase instance { get; private set; }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                instance = this;
            }
        }

        public int GetAtlasArrayLength()
        {
            return spriteAtlas.Length;
        }

        public int GetAtlasId()
        {
            return activeAtlasId;
        }

        public SpriteAtlas GetSpriteAtlas()
        {
            return spriteAtlas[activeAtlasId];
        }
    }

}
