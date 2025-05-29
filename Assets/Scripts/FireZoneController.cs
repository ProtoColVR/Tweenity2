using UnityEngine;
using Tweenity;

public class FireZone : MonoBehaviour
{
    [Header("Zona del fuego")]
    public Collider fireCollider;

    [Header("Zona de impacto del spray")]
    public Collider sprayZone;

    [Header("Lógica de fuego")]
    public GameObject fireVisual;

    private bool fireIsActive = true;

    private void Start()
    {
        if (fireVisual != null)
            fireVisual.SetActive(true);
    }

    private void Update()
    {
        if (!fireIsActive || fireCollider == null || sprayZone == null) return;

        // Verifica si hay intersección entre las hitboxes del fuego y del spray
        if (fireCollider.bounds.Intersects(sprayZone.bounds))
        {
            ExtinguishFire();
        }
    }

    [TweenityEvent]
    private void ExtinguishFire()
    {
        if (!fireIsActive) return;

        fireIsActive = false;

        if (fireVisual != null)
            fireVisual.SetActive(false);

        TweenityEvents.ReportAction(gameObject.name, nameof(FireZone), nameof(ExtinguishFire));
        Debug.Log("🧯 Fuego extinguido correctamente en: " + gameObject.name);
    }

    [TweenityEvent]
    public void ResetFire()
    {
        fireIsActive = true;

        if (fireVisual != null)
            fireVisual.SetActive(true);
    }
}
