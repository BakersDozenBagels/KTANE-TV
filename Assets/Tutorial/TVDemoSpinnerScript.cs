using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVDemoSpinnerScript : MonoBehaviour
{
    public CameraRig Rig;

    private void Start()
    {
        StartCoroutine(SpinSpinner());
        StartCoroutine(Spin(2));
    }

    private IEnumerator Spin(int dirMode)
    {
        bool wobble = false;// Random.Range(0, 2) == 0;
        //if(wobble)
        //    Rig.ArrowParent.localEulerAngles = new Vector3(0f, 90f * dirMode, 0f);
        float timer = 0f;
        while(true)
        {
            timer += Time.deltaTime;
            Rig.Arrow.localEulerAngles =/* !wobble ? new Vector3(0f, 90f * dirMode + 30f * WobbleCurve.Evaluate(timer / 6f), 0f) :*/ new Vector3(-60f * timer, 0f, 0f);
            yield return null;
        }
    }

    private IEnumerator SpinSpinner()
    {
        while(true)
        {
            Rig.BackSpinner.localEulerAngles += new Vector3(0f, Time.deltaTime * 60f, 0f);
            yield return null;
        }
    }
}
