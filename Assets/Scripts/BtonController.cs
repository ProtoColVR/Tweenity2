using UnityEngine;
using UnityEngine.Events;

public class FireExtinguisherButton : MonoBehaviour
{
    [Header("Setup")]
    public GameObject buttonVisual;
    public UnityEvent onPress;
    public UnityEvent onRelease;

    [Tooltip("Tag del objeto que puede presionar este botón (ej: 'GameController')")]
    public string validTag = "GameController";

    [Tooltip("Cuánto se hunde el botón al presionarse (en metros)")]
    public float pressDepth = 0.005f;

    private GameObject presser;
    private bool isPressed;

    private Vector3 releasedPosition;
    private Vector3 pressedPosition;

    void Start()
    {
        if (buttonVisual == null)
            buttonVisual = this.gameObject;

        // Guarda la posición inicial como posición "liberada"
        releasedPosition = buttonVisual.transform.localPosition;

        // Calcula posición presionada bajando solo en Y
        pressedPosition = releasedPosition - new Vector3(0, pressDepth, 0);

        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPressed || !other.CompareTag(validTag)) return;

        buttonVisual.transform.localPosition = pressedPosition;
        presser = other.gameObject;
        onPress.Invoke();
        isPressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != presser) return;

        buttonVisual.transform.localPosition = releasedPosition;
        onRelease.Invoke();
        isPressed = false;
    }
}
