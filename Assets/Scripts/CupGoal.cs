using UnityEngine;

public class CupGoal : MonoBehaviour
{
    public ScoreManager scoreManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody == null) return;

        Ball ball = other.attachedRigidbody.GetComponent<Ball>();

        if (ball == null) return;
        if (ball.rb.bodyType != RigidbodyType2D.Dynamic) return;

        scoreManager.RegisterHit();
    }
}