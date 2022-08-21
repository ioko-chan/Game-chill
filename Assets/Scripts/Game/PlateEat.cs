using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

namespace Game
{
    public class PlateEat : MonoBehaviour
    {
        [SerializeField]
        private EventListener _dragEat;

        [SerializeField]
        private EventListener _noDragEat;

        [SerializeField]
        private EventDispatcher _destroy;

        [SerializeField]
        private EventDispatcher _catSad;

        [SerializeField]
        private GameObject _inPlate;

        private bool _drugMouseEat = false;

        private bool _isEatInPlate = false;

        public bool _eatOnMouse = false;

        private void OnEnable()
        {
            _dragEat.OnEventHappened += UpdateIsEat;
            _noDragEat.OnEventHappened += UpdateIsntEat;
        }

        private void OnDisable()
        {
            _dragEat.OnEventHappened -= UpdateIsEat;
            _noDragEat.OnEventHappened -= UpdateIsntEat;
        }

        private void UpdateIsntEat()
        {
            _drugMouseEat = false;
            StartCoroutine(EatOnMouse());
        }

        private IEnumerator EatOnMouse()
        {
            yield return new WaitForSeconds(1);
            _eatOnMouse = false;
            yield return null;
        }
        private void UpdateIsEat()
        {
            _drugMouseEat = true;
            _eatOnMouse = true;
        }

        private void OnMouseEnter()
        {// лисэнеры переделать для интерфейса еды и в интерфейсе свое поведение сделать
            if (!_drugMouseEat && !_isEatInPlate && _eatOnMouse)
            {
                Instantiate(_inPlate);
                _isEatInPlate = true;
                _eatOnMouse = false;
                _catSad.Dispatch();
            }
        }
    }

}