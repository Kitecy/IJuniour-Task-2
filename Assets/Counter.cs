using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const float ValueIncrease = 1f;
    private const float WaitTime = 0.5f;

    private float _value;
    private bool _isCounting = false;

    private WaitForSeconds _waitForSeconds = new(WaitTime);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
                _isCounting = false;
            else
                StartCounting();
        }
    }

    private void StartCounting()
    {
        _isCounting = true;
        StartCoroutine(Counting());
    }

    private IEnumerator Counting()
    {
        while (_isCounting)
        {
            yield return new WaitForSeconds(WaitTime);
            _value += ValueIncrease;
            Debug.Log($"Value = {_value}");
        }
    }
}
