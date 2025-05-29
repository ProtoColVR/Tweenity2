using UnityEngine;
using Tweenity;

public class FireManager : MonoBehaviour
{
    public GameObject fireOrange;
    public GameObject fireRed;

    [TweenityEvent]
    public void ActivateRedFire()
    {
        TweenityEvents.ReportAction(gameObject.name, nameof(FireManager), nameof(ActivateRedFire));
        fireRed?.SetActive(true);
    }

    [TweenityEvent]
    public void ActivateOrangeFire()
    {
        TweenityEvents.ReportAction(gameObject.name, nameof(FireManager), nameof(ActivateOrangeFire));
        fireOrange?.SetActive(true);
    }

    [TweenityEvent]
    public void DeactivateRedFire()
    {
        TweenityEvents.ReportAction(gameObject.name, nameof(FireManager), nameof(DeactivateRedFire));
        fireRed?.SetActive(false);
    }

    [TweenityEvent]
    public void DeactivateOrangeFire()
    {
        TweenityEvents.ReportAction(gameObject.name, nameof(FireManager), nameof(DeactivateOrangeFire));
        fireOrange?.SetActive(false);
    }
}
