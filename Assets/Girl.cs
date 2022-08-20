using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

namespace Game
{
    public class Girl : MonoBehaviour
    {
        [SerializeField]
        private EventListener _girlSad;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private Sprite _girlSadTexture;

        [SerializeField]
        private Sprite _girlNormalTexture;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _girlSad.OnEventHappened += UpdateState;
        }

        private void OnDisable()
        {
            _girlSad.OnEventHappened -= UpdateState;
        }
        private void UpdateState()
        {
            _spriteRenderer.sprite = _girlSadTexture;
        }
    }
}