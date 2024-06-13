using System;
using System.Collections;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public event Action<int> TimerDrowing;
    private int _currentCounterNumber = 0;
    private Coroutine _coroutine;
    private bool _isWorking = true;
    private float _timeDelay = 0.5f;

    private void Start()
    {
        _coroutine = StartCoroutine(SetTime(_timeDelay));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isWorking)
            {
                _isWorking = false;
                StopCoroutine(_coroutine);
            }
            else
            {
                _isWorking=true;
                _coroutine = StartCoroutine(SetTime(_timeDelay));
            }
        }
    }

    private IEnumerator SetTime(float delay)
    {
        var wait = new WaitForSeconds(delay);
        int finishTime = 1000;

        while (_currentCounterNumber < finishTime)
        {
            _currentCounterNumber++;
            TimerDrowing?.Invoke(_currentCounterNumber);
            yield return wait;
        }
    }
}