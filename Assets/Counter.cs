using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CounterView _counterView;

    private const float ValueIncrease = 1f;
    private const float WaitTime = 0.5f;

    private float _value;

    private IEnumerator _coroutine;
    private WaitForSeconds _waitForSeconds = new(WaitTime);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine == null)
                StartCounting();
            else
                StopCounting();
        }
    }

    private void StartCounting()
    {
        _coroutine = Counting();
        StartCoroutine(_coroutine);
    }

    private void StopCounting()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private IEnumerator Counting()
    {
        while (_coroutine != null)
        {
            yield return _waitForSeconds;
            _value += ValueIncrease;
            _counterView.ShowValue(_value);
        }
    }
}
