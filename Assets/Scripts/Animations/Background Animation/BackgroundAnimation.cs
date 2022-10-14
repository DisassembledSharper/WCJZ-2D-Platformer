using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Animations.BackgroundAnimation
{
    public class BackgroundAnimation : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float speed;

        [SerializeField] private Tilemap tilemap;
        private void Update()
        {
            tilemap.tileAnchor -= new Vector3(0, speed * Time.deltaTime, 0);
            if (tilemap.tileAnchor.y <= -0.5f) tilemap.tileAnchor = new Vector2(0.5f, 0.5f);
        }
    }
}