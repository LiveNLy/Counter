using System;
using System.Collections;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public event Action TimerDrowing;
    private Coroutine _coroutine;
    private bool IsWorking = true;
    private int _currentTime = 0;
    public int CurrentTime => _currentTime;

    private void Start()
    {
        _coroutine = StartCoroutine(SetTime(0.5f));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsWorking)
            {
                IsWorking = false;
                StopCoroutine(_coroutine);
            }
            else
            {
                IsWorking=true;
                _coroutine = StartCoroutine(SetTime(0.5f));
            }
        }
    }

    private IEnumerator SetTime(float delay)
    {
        var wait = new WaitForSeconds(delay);
        int finishTime = 1000;

        while (_currentTime < finishTime)
        {
            _currentTime++;
            TimerDrowing?.Invoke();
            yield return wait;
        }
    }
}