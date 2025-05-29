using UnityEngine;

public class MaintainLocalOffset : MonoBehaviour
{
    [Header("Objetivo")]
    public Transform target; // El objeto del que se quiere mantener el offset (ej: extintor)

    private Vector3 initialLocalPosition;
    private Quaternion initialLocalRotation;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("🎯 MaintainLocalOffset: No se asignó target.");
            enabled = false;
            return;
        }

        // Calcula el offset inicial en espacio local
        initialLocalPosition = transform.position - target.position;
        initialLocalRotation = Quaternion.Inverse(target.rotation) * transform.rotation;
    }

    private void LateUpdate()
    {
        // Reconstruye la posición global aplicando el mismo offset
        transform.position = target.position + target.rotation * initialLocalPosition;
        transform.rotation = target.rotation * initialLocalRotation;
    }
}
