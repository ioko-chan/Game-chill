using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTriggerMove : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private EventDispatcher _audio;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        StartCoroutine(SartCponk());
    }

    private IEnumerator SartCponk()
    {
        _animator.SetBool("normal", false);
        _audio.Dispatch();
        yield return new WaitForSeconds(0.09f);
        _animator.SetBool("normal", true);
    }
}
