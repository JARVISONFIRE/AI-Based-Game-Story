using UnityEngine;

public class TurnTimer : MonoBehaviour {
    public float turnDuration = 30f;  // Duration of each turn in seconds
    private float timer;

    void Start() {
        timer = turnDuration;
    }

    void Update() {
        timer -= Time.deltaTime;
        // Update UI here if needed (e.g., countdown text)
        if (timer <= 0f) {
            // Signal to GameFlowManager that the turn should end
            GameFlowManager.Instance.EndTurn();
            timer = turnDuration; // Reset timer for next turn
        }
    }

    // Optionally, add a method to reset the timer when a turn is ended manually
    public void ResetTimer() {
        timer = turnDuration;
    }
}
