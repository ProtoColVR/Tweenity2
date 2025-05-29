using UnityEngine;
using System;
using Tweenity;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI del diálogo")]
    public DialoguePanelController panelController;

    [Header("Cámara del jugador")]
    public Transform playerCamera;

    private void Awake()
    {
        Instance = this;
    }

    private void ShowPanel(string message, string buttonLabel, Action onDismiss = null)
    {
        Vector3 forward = playerCamera.position + playerCamera.forward * 2f;
        forward.y = playerCamera.position.y;
        panelController.transform.position = forward;
        panelController.transform.LookAt(playerCamera);
        panelController.transform.Rotate(0, 180, 0);

        Debug.Log($"🪟 Mostrando panel con mensaje: {message}");

        panelController.ShowDialogue(message, buttonLabel, onDismiss);
    }

    [TweenityEvent]
    public void ShowWelcomeDialogue()
    {
        ShowPanel("¡Bienvenido a la simulación de control de Fuegos con Tweenity!", "Continuar", ReportButtonClickA);
    }

    [TweenityEvent]
    public void RemindStepIntoPlayArea()
    {
        panelController.ShowDialogue("Por favor, entra en la zona delimitada para continuar.", "Entendido");
    }

    [TweenityEvent]
    public void ShowExtinguisherTip()
    {
        ShowPanel("Recuerda usar el extintor del color adecuado según el tipo de fuego.", "Entendido", ReportButtonClickA);
    }

    [TweenityEvent]
    public void ShowWrongExtinguisherWarning()
    {
        ShowPanel("¡Ese extintor no es el adecuado para este tipo de fuego!", "Continuar", ReportButtonClickA);
    }

    [TweenityEvent]
    public void ShowSuccessMessage()
    {
        ShowPanel("¡Bien hecho! Has extinguido el fuego correctamente.", "Continuar", ReportButtonClickA);
    }

    [TweenityEvent]
    public void ShowFailureMessage()
    {
        ShowPanel("Paso demasiado tiempo, el fuego se salió de control.", "Continuar", ReportButtonClickA);
    }

    [TweenityEvent]
    public void ReportButtonClickA()
    {
        Debug.Log("🟢 Opción A seleccionada");
        TweenityEvents.ReportAction(gameObject.name, nameof(DialogueManager), nameof(ReportButtonClickA));
    }

    [TweenityEvent]
    public void ReportButtonClickB()
    {
        Debug.Log("🟢 Opción B seleccionada");
        TweenityEvents.ReportAction(gameObject.name, nameof(DialogueManager), nameof(ReportButtonClickB));
    }

    [TweenityEvent]
    public void ShowEndOfSimulationDialogue()
    {
        Vector3 forward = playerCamera.position + playerCamera.forward * 2f;
        forward.y = playerCamera.position.y;
        panelController.transform.position = forward;
        panelController.transform.LookAt(playerCamera);
        panelController.transform.Rotate(0, 180, 0);

        panelController.ShowDialogue(
            "Has completado la simulación!",
            "Reiniciar", "Modo Libre",
            () => TweenityEvents.ReportAction(gameObject.name, nameof(DialogueManager), nameof(ReportButtonClickA)),
            () => TweenityEvents.ReportAction(gameObject.name, nameof(DialogueManager), nameof(ReportButtonClickB))
        );
    }
}
