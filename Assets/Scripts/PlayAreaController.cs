using UnityEngine;
using Tweenity;

public class PlayAreaDetector : MonoBehaviour
{
    public string playerTag = "Player"; 
    private bool hasEntered = false;

    public delegate void PlayerEnteredZone();
    public static event PlayerEnteredZone OnPlayerEntered;

    [TweenityEvent]
    private void OnTriggerEnter(Collider other)
    {
        if (!hasEntered && other.CompareTag(playerTag))
        {
            hasEntered = true;

            Debug.Log("🚶‍♂️ Jugador ha entrado a la zona de juego");
            OnPlayerEntered?.Invoke();

            TweenityEvents.ReportAction(gameObject.name, nameof(PlayAreaDetector), nameof(OnTriggerEnter));
        }
    }
}
