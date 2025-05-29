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
        Hide();
    }

    public void ShowDialogue(string text, string buttonALabel, Action onDismissAction = null)
    {
        Debug.Log("📢 Mostrando diálogo con 1 botón");

        dialogueText.text = text;

        // Configurar botón A
        buttonAText.text = buttonALabel;
        buttonA.gameObject.SetActive(true);
        buttonB.gameObject.SetActive(false);
        onDismiss = onDismissAction;

        gameObject.SetActive(true);

        buttonA.onClick.RemoveAllListeners();
        buttonA.onClick.AddListener(() =>
        {
            Debug.Log("🟢 Botón A presionado (versión simple)");
            onDismiss?.Invoke();
            Hide();
        });
    }

    public void ShowDialogue(string text, string buttonALabel, string buttonBLabel, Action onButtonA = null, Action onButtonB = null)
    {
        Debug.Log("📢 Mostrando diálogo con 2 botones");

        dialogueText.text = text;

        // Configurar ambos botones
        buttonAText.text = buttonALabel;
        buttonBText.text = buttonBLabel;
        buttonA.gameObject.SetActive(true);
        buttonB.gameObject.SetActive(true);

        gameObject.SetActive(true);

        buttonA.onClick.RemoveAllListeners();
        buttonA.onClick.AddListener(() =>
        {
            Debug.Log("🟢 Botón A presionado (versión doble)");
            onButtonA?.Invoke();
            Hide();
        });

        buttonB.onClick.RemoveAllListeners();
        buttonB.onClick.AddListener(() =>
        {
            Debug.Log("🔵 Botón B presionado");
            onButtonB?.Invoke();
            Hide();
        });
    }

    public void Hide()
    {
        Debug.Log("❌ Ocultando panel de diálogo");
        gameObject.SetActive(false);
    }
}
