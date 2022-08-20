using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

namespace Game
{
    public class Vegetables : MonoBehaviour
    {
        [SerializeField]
        private EventDispatcher _dragEat;

        [SerializeField]
        private EventDispatcher _noDragEat;

        [SerializeField]
        private EventDispatcher _destroyEat;

        private void OnMouseDrag()
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            _dragEat.Dispatch();
        }

        private void OnMouseUp()
        {
            _noDragEat.Dispatch();
            _destroyEat.Dispatch();
        }
    }
}