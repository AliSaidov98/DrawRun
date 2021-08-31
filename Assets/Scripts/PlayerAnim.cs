using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator _animator;
    private string _started = "started";
    private string _finish = "finish";
    private string _die = "die";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run()
    {
        _animator.SetBool(_started, true);
    }

    public void Finish()
    {
        _animator.SetBool(_finish, true);
    }

    public void Die()
    {
        _animator.SetBool(_die, true);
    }
}
