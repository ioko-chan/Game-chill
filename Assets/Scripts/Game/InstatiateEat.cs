using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Events;

namespace Game
{
    public class InstatiateEat : MonoBehaviour
    {
        public enum ProductEnum
        {
            Vegetable,
            Dessert,
            Meat,
            Drink
        }

        public ProductEnum CurrentProduct;

        [SerializeField]
        private GameObject _prefadVegetable;

        [SerializeField]
        private GameObject _prefadDessert;

        [SerializeField]
        private GameObject _prefadMeat;

        [SerializeField]
        private GameObject _prefadDrink;

        [SerializeField]
        private GameObject _prefadOff;

        [SerializeField]
        private Transform _leftPositionEat;

        [SerializeField]
        private Transform _rightPositionEat;

        [SerializeField]
        private EventListener _productInstatiate;

        [SerializeField]
        private EventListener _productDestroy;

        [SerializeField]
        private EventListener _productDestroyOnMouse;

        [SerializeField]
        private EventListener _dragEat;

        [SerializeField]
        private EventListener _noDragEat;

        private bool _leftTarget = true;

        private bool _isDrag = false ;

        public List<GameObject> product;

        private void OnEnable()
        {
            _productInstatiate.OnEventHappened += Instatiate;
            _productDestroy.OnEventHappened += Destroy;
            _dragEat.OnEventHappened += Drag;
            _noDragEat.OnEventHappened += noDragEat;
            _productDestroyOnMouse.OnEventHappened += DestroyN;
        }


        private void OnDisable()
        {
            _productInstatiate.OnEventHappened -= Instatiate;
            _productDestroy.OnEventHappened -= Destroy;
            _dragEat.OnEventHappened -= Drag;
            _noDragEat.OnEventHappened += noDragEat;
            _productDestroyOnMouse.OnEventHappened -= DestroyN;
        }

        private void noDragEat()
        {
            _isDrag = false;
        }

        public void Instatiate()
        {
            product.Add( Instantiate(_prefadVegetable));
            int count = 0;

            if (product.Count > 1)
                count = product.Count - 1;
            else
                count = 0;

            product[count].transform.parent = _prefadOff.transform;

            if (_leftTarget)
            {
                product[count].transform.position = _rightPositionEat.position;
                _leftTarget = false;
            }
            else
            {
                product[count].transform.position = _leftPositionEat.position;
                _leftTarget = true;
            }
        }

        private void DestroyN()
        {
            int count = 0;
            if (product.Count > 1)
            {
                count = product.Count - 1;

            }
            else
            {
                count = 0;

            }

            Destroy(product[0]);
            product.Remove(product[0]);
        }

        private void Drag()
        {
            int count = 0;
            if (product.Count > 1)
            {
                count = product.Count - 1;

            }
            else
            {
                count = 0;

            }
            _isDrag = true;
            product[0].transform.parent = null;
        }


        public void Destroy()
        {
            int count = 0;
            if (product.Count > 1)
            {
                count = product.Count - 1;

            }
            else
            {
                count = 0;

            }
            if ((_isDrag && product.Count > 1) || (!_isDrag && product.Count > 0))
            {
                Destroy(product[count]);
                product.Remove(product[count]);
            }
        }

        public void RandomizeCurrentProduct()
        {
            System.Random r = new System.Random();
            int rInt = r.Next(0, 3);

            switch (rInt)
            {
                case 0:
                    {
                        CurrentProduct = ProductEnum.Vegetable;
                        break;
                    }
                case 1:
                    {
                        CurrentProduct = ProductEnum.Dessert;
                        break;
                    }
                case 2:
                    {
                        CurrentProduct = ProductEnum.Meat;
                        break;
                    }
                case 3:
                    {
                        CurrentProduct = ProductEnum.Drink;
                        break;
                    }
            }

        }
    }
}