using UnityEngine;
using UnityEngine.UI;
using System;

public class DialoguePanelController : MonoBehaviour
{
    [Header("Referencias UI")]
    public Text dialogueText;
    public Button buttonA;
    public Button buttonB;
    public Text buttonAText;
    public Text buttonBText;

    private Action onDismiss;

    private void Start()
    {
        Hide(); // Asegura que el panel esté oculto al comenzar
    }

    /// <summary>
    /// Muestra un panel con un solo botón.
    /// </summary>
    public void ShowDialogue(string text, string buttonALabel, Action onDismissAction = null)
    {
        Debug.Log("📢 Mostrando diálogo con 1 botón");

        dialogueText.text = text;

        buttonAText.text = buttonALabel;
        buttonA.gameObject.SetActive(true);
        buttonB.gameObject.SetActive(false);

        onDismiss = onDismissAction;

        // Limpia y asigna el evento del botón A
        buttonA.onClick.RemoveAllListeners();
        buttonA.onClick.AddListener(() =>
        {
            Debug.Log("🟢 Botón A presionado (versión simple)");
            onDismiss?.Invoke();
            Hide();
        });

        gameObject.SetActive(true);
    }

    /// <summary>
    /// Muestra un panel con dos botones.
    /// </summary>
    public void ShowDialogue(string text, string buttonALabel, string buttonBLabel, Action onButtonA = null, Action onButtonB = null)
    {
        Debug.Log("📢 Mostrando diálogo con 2 botones");

        dialogueText.text = text;

        buttonAText.text = buttonALabel;
        buttonBText.text = buttonBLabel;
        buttonA.gameObject.SetActive(true);
        buttonB.gameObject.SetActive(true);

        // Limpia y asigna el evento del botón A
        buttonA.onClick.RemoveAllListeners();
        buttonA.onClick.AddListener(() =>
        {
            Debug.Log("🟢 Botón A presionado (versión doble)");
            onButtonA?.Invoke();
            Hide();
        });

        // Limpia y asigna el evento del botón B
        buttonB.onClick.RemoveAllListeners();
        buttonB.onClick.AddListener(() =>
        {
            Debug.Log("🔵 Botón B presionado");
            onButtonB?.Invoke();
            Hide();
        });

        gameObject.SetActive(true);
    }

    /// <summary>
    /// Oculta el panel de diálogo.
    /// </summary>
    public void Hide()
    {
        Debug.Log("❌ Ocultando panel de diálogo");
        gameObject.SetActive(false);
    }
}
