using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.InputRaycast
{
    public class InputRaycast : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastObject(Input.mousePosition);
            }
        }

        private void RaycastObject(Vector2 sreenPosition)
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(sreenPosition);
            var hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }

}
