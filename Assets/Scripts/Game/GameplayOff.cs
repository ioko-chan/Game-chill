using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

namespace Game
{
    public class GameplayOff : MonoBehaviour
    {
        [SerializeField]
        private EventDispatcher _startMoveOff;

        [SerializeField]
        private EventDispatcher _startInstatiateEat;

        [SerializeField]
        private EventListener _startGameplay;

        [SerializeField]
        private float _timeExistsOff = 10;

        private bool _moveOff = false;

        private void OnEnable()
        {
            _startGameplay.OnEventHappened += Gameplay;
        }

        private void OnDisable()
        {
            _startGameplay.OnEventHappened -= Gameplay;
        }

        private void Gameplay()
        {
            
        }

        private void Start()
        {
            _moveOff = true;
            StartCoroutine(StartGamplay());
        }

        private IEnumerator StartGamplay()
        {
            while (_moveOff)
            {
                yield return new WaitForSeconds(5);
                _startMoveOff.Dispatch();
                _startInstatiateEat.Dispatch();
                yield return new WaitForSeconds(_timeExistsOff);
            }
        }
    }
}