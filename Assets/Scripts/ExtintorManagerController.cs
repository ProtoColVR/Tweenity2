using UnityEngine;
using Tweenity;

public class FireExtinguisherManager : MonoBehaviour
{
    [Header("Extintores en escena")]
    public FireExtinguisher redExtinguisher;
    public FireExtinguisher blueExtinguisher;

    [TweenityEvent]
    public void ShowRedExtinguisher()
    {
        if (redExtinguisher != null)
            redExtinguisher.gameObject.SetActive(true);
    }

    [TweenityEvent]
    public void HideRedExtinguisher()
    {
        if (redExtinguisher != null)
            redExtinguisher.gameObject.SetActive(false);
    }

    [TweenityEvent]
    public void ShowBlueExtinguisher()
    {
        if (blueExtinguisher != null)
            blueExtinguisher.gameObject.SetActive(true);
    }

    [TweenityEvent]
    public void HideBlueExtinguisher()
    {
        if (blueExtinguisher != null)
            blueExtinguisher.gameObject.SetActive(false);
    }

    [TweenityEvent]
    public void ShowAllExtinguishers()
    {
        ShowRedExtinguisher();
        ShowBlueExtinguisher();
    }

    [TweenityEvent]
    public void HideAllExtinguishers()
    {
        HideRedExtinguisher();
        HideBlueExtinguisher();
    }

    [TweenityEvent]
    public void ResetExtinguishers()
    {
        if (redExtinguisher != null)
            redExtinguisher.ResetToInitialPosition();

        if (blueExtinguisher != null)
            blueExtinguisher.ResetToInitialPosition();
    }

    [TweenityEvent]
    public void RestartSimulation()
    {
        ResetExtinguishers();
        HideAllExtinguishers();
    }
}
