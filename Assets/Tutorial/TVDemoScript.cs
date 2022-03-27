using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVDemoScript : MonoBehaviour
{
    public Renderer Mat, Mat2;
    public Transform SecondScreen, Eye1, Eye2;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            StartCoroutine(SlideLeft());
        if(Input.GetKeyDown(KeyCode.W))
            StartCoroutine(SlideBack());
        if(Input.GetKeyDown(KeyCode.E))
            StartCoroutine(FadeIn());
        if(Input.GetKeyDown(KeyCode.T))
            StartCoroutine(FadeIn2());
        if(Input.GetKeyDown(KeyCode.Y))
            StartCoroutine(FadeOut2());
        if(Input.GetKeyDown(KeyCode.R))
            StartCoroutine(FadeOut());
        if(Input.GetKeyDown(KeyCode.U))
            StartCoroutine(ExtendEyes());
    }

    private IEnumerator ExtendEyes()
    {
        float time = Time.time;
        while(Time.time - time < 2f)
        {
            Eye1.localScale = new Vector3(12f * (Time.time - time) / 2f, 1f, 1f);
            Eye2.localScale = new Vector3(12f * (Time.time - time) / 2f, 1f, 1f);
            yield return null;
        }
        Eye1.localScale = new Vector3(12f, 1f, 1f);
        Eye2.localScale = new Vector3(12f, 1f, 1f);
    }

    private IEnumerator FadeOut2()
    {
        float time = Time.time;
        while(Time.time - time < 2f)
        {
            Mat.material.SetFloat("fade_factor_two", Mathf.Lerp(1f, 0f, (Time.time - time) / 2f));
            Mat2.material.SetFloat("fade_factor_two", Mathf.Lerp(1f, 0f, (Time.time - time) / 2f));
            yield return null;
        }
        Mat.material.SetFloat("fade_factor_two", 0f);
        Mat2.material.SetFloat("fade_factor_two", 0f);
    }

    private IEnumerator FadeIn2()
    {
        float time = Time.time;
        while(Time.time - time < 2f)
        {
            Mat.material.SetFloat("fade_factor_two", Mathf.Lerp(0f, 1f, (Time.time - time) / 2f));
            Mat2.material.SetFloat("fade_factor_two", Mathf.Lerp(0f, 1f, (Time.time - time) / 2f));
            yield return null;
        }
        Mat.material.SetFloat("fade_factor_two", 1f);
        Mat2.material.SetFloat("fade_factor_two", 1f);
    }

    private IEnumerator FadeOut()
    {
        float time = Time.time;
        while(Time.time - time < 2f)
        {
            Mat.material.SetFloat("fade_factor", Mathf.Lerp(1f, 0f, (Time.time - time) / 2f));
            Mat2.material.SetFloat("fade_factor", Mathf.Lerp(1f, 0f, (Time.time - time) / 2f));
            yield return null;
        }
        Mat.material.SetFloat("fade_factor", 0f);
        Mat2.material.SetFloat("fade_factor", 0f);
    }

    private IEnumerator FadeIn()
    {
        float time = Time.time;
        while(Time.time - time < 2f)
        {
            Mat.material.SetFloat("fade_factor", Mathf.Lerp(0f, 1f, (Time.time - time) / 2f));
            Mat2.material.SetFloat("fade_factor", Mathf.Lerp(0f, 1f, (Time.time - time) / 2f));
            yield return null;
        }
        Mat.material.SetFloat("fade_factor", 1f);
        Mat2.material.SetFloat("fade_factor", 1f);
    }

    private IEnumerator SlideBack()
    {
        float time = Time.time;
        while(Time.time - time < 2f)
        {
            transform.localPosition = new Vector3(0f, Mathf.Lerp(0.575f, 0.772f, (Time.time - time) / 2f), 0f);
            SecondScreen.localScale = Mathf.Lerp(0f, 1f, (Time.time - time) / 2f) * Vector3.one;
            yield return null;
        }
        transform.localPosition = new Vector3(0f, 0.772f, 0f);
        SecondScreen.localScale = 1f * Vector3.one;
    }

    private IEnumerator SlideLeft()
    {
        float time = Time.time;
        while(Time.time - time < 2f)
        {
            transform.parent.localEulerAngles = ((Time.time - time) / 2f) * new Vector3(10f, 10f, 40f);
            yield return null;
        }
        transform.parent.localEulerAngles = new Vector3(10f, 10f, 40f);
    }
}
