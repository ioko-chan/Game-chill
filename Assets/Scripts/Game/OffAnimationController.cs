using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class OffAnimationController : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartLeft()
        {
            _animator.SetBool("go_left", true);
        }

        public void StartRight()
        {
            _animator.SetBool("go_right", true);
        }

        public void EndLeft()
        {
            _animator.SetBool("go_left", false);
        }

        public void EndRight()
        {
            _animator.SetBool("go_right", false);
        }
    }
}