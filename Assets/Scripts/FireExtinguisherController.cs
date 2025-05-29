using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Tweenity;

public class FireExtinguisher : MonoBehaviour
{
    [Header("Componentes")]
    public XRGrabInteractable grabInteractable;
    public ParticleSystem sprayEffect;
    public Collider sprayZoneCollider;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void OnEnable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }
    }

    private void OnDisable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }

    [TweenityEvent]
    private void OnGrab(SelectEnterEventArgs args)
    {
        TweenityEvents.ReportAction(gameObject.name, nameof(FireExtinguisher), nameof(OnGrab));
        Debug.Log($"🟢 [FireExtinguisher] '{name}' fue agarrado.");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        StopSpray(); // Por si el jugador suelta el extintor mientras está disparando
    }

    public void StartSpray()
    {
        Debug.Log("🟠 [FireExtinguisher] StartSpray");

        sprayEffect?.Play();

        if (sprayZoneCollider != null)
            sprayZoneCollider.enabled = true;
    }

    public void StopSpray()
    {
        Debug.Log("🔴 [FireExtinguisher] StopSpray");

        if (sprayEffect != null && sprayEffect.isPlaying)
            sprayEffect.Stop();

        if (sprayZoneCollider != null)
            sprayZoneCollider.enabled = false;
    }

    public void ResetToInitialPosition()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (grabInteractable != null && grabInteractable.isSelected)
            grabInteractable.interactionManager.CancelInteractableSelection((IXRSelectInteractable)grabInteractable);

        transform.SetPositionAndRotation(initialPosition, initialRotation);
        StopSpray();
        Debug.Log($"♻️ Extintor '{name}' reseteado a posición inicial.");
    }
}
