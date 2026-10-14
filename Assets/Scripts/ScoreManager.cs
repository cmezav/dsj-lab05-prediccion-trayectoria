using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }
    bool scoredThisShot;

    public void BeginShot()
    {
        scoredThisShot = false;
    }

    public void RegisterHit()
    {
        if (scoredThisShot) return;

        scoredThisShot = true;
        Score++;
        Debug.Log("Puntuación: " + Score);
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 28;
        style.normal.textColor = Color.black;

        GUI.Label(
            new Rect(20, 20, 300, 50),
            "Puntos: " + Score,
            style
        );
    }
}