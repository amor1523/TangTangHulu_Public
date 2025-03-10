using System.Collections;
using UnityEngine;

public class Shutter : GenericSingleton<Shutter>
{
    [SerializeField] private Animator shutterAnimator;
    [SerializeField] private GameObject shutterObj;

    public IEnumerator ShutterUp()
    {
        shutterAnimator.SetTrigger("ShutterUp");
        yield return new WaitForSeconds(1.84f);
        shutterObj.SetActive(false);
    }

    public void ShutterDown()
    {
        shutterObj.SetActive(true);
        shutterAnimator.Play("ShutterUp_Idle", -1, 1f); // 강제로 열린 상태로 설정
        shutterAnimator.SetTrigger("ShutterDown");
    }

    public void DelayShutterUp(float delay)
    {
        StartCoroutine(DelayShutterUpCoroutine(delay));
    }

    public void DelayShutterDown(float delay)
    {
        StartCoroutine(DelayShutterDownCoroutine(delay));
    }

    private IEnumerator DelayShutterUpCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(ShutterUp());
    }

    private IEnumerator DelayShutterDownCoroutine(float delay)
    {
        ShutterDown();
        yield return new WaitForSeconds(delay);
    }
}