using UnityEngine;

public class Endpoint : MonoBehaviour
{
    [SerializeField] Checkpoint[] checkpoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Keggy")
            return;

        bool isWon = true;

        foreach (var checkpoint in checkpoints)
        {
            if (!checkpoint.IsChecked)
                isWon = false;
        }

        if (isWon)
            Debug.LogWarning("Won!");
    }
}
