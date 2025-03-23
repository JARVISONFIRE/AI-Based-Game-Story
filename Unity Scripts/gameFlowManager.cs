using UnityEngine;
using Mirror; // Import Mirror networking namespace

public class GameFlowManager : NetworkBehaviour {
    public static GameFlowManager Instance;
    public float turnDuration = 30f;
    public int currentTurnIndex = 0;
    public GameObject[] players; // Populate these either at runtime or via the inspector

    void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Call this method to signal end of turn (from timer or player action)
    [Server]
    public void EndTurn() {
        // Update turn index (e.g., round-robin)
        currentTurnIndex = (currentTurnIndex + 1) % players.Length;
        RpcStartTurn(currentTurnIndex);
    }

    // Use RPC so all clients update their state
    [ClientRpc]
    void RpcStartTurn(int activePlayerIndex) {
        // Update your UI and enable input only for players[activePlayerIndex]
        Debug.Log("Turn changed. Active player: " + activePlayerIndex);
        // For example: Disable input on all players except the one at activePlayerIndex
    }
}
