using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

namespace Game
{
    public class OffController : MonoBehaviour
    {
        [SerializeField]
        private Transform _leftPosition;

        [SerializeField]
        private Transform _rightPosition;

        [SerializeField]
        private float _speed = 5;

        [SerializeField]
        private EventListener _moveOff;

        [SerializeField]
        private OffAnimationController _animatorOff;

        [SerializeField]
        private EventDispatcher _destroeEat;


        private bool _leftTarget = true;

        private void OnEnable()
        {
            _moveOff.OnEventHappened += Move;
        }

        private void OnDisable()
        {
            _moveOff.OnEventHappened -= Move;
        }
        private void Move()
        {
            if (_leftTarget)
            {
                StartCoroutine(MoveToTarger(_leftPosition));            
            }
            else
            {
                StartCoroutine(MoveToTarger(_rightPosition));
            }
        }

        private IEnumerator MoveToTarger(Transform position)
        {
            if (_leftTarget)
            {
                _animatorOff.StartLeft();
            }
            else
            {
                _animatorOff.StartRight();
            }

            while(transform.position != position.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, position.position, Time.deltaTime*_speed);
                yield return null;

            }

            _destroeEat.Dispatch();

            if (_leftTarget)
            {
                _animatorOff.EndLeft();
            }
            else
            {
                _animatorOff.EndRight();
            }

            _leftTarget = !_leftTarget;
        }
    }
}