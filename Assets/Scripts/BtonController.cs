using UnityEngine;

public class SprayButton : MonoBehaviour
{
    [Header("Referencia al extintor")]
    public FireExtinguisher extinguisher;

    public void OnPress()
    {
        if (extinguisher != null)
        {
            Debug.Log("🟢 SprayButton → OnPress()");
            extinguisher.StartSpray();
        }
        else
        {
            Debug.LogWarning("🚨 SprayButton → OnPress: No se asignó el extintor.");
        }
    }

    public void OnRelease()
    {
        if (extinguisher != null)
        {
            Debug.Log("🔵 SprayButton → OnRelease()");
            extinguisher.StopSpray();
        }
        else
        {
            Debug.LogWarning("🚨 SprayButton → OnRelease: No se asignó el extintor.");
        }
    }
}
