using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTriggerMove : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseEnter()
    {
        _animator.SetBool("normal", false);
    }

    private void OnMouseExit()
    {
        _animator.SetBool("normal", true);
    }

}
