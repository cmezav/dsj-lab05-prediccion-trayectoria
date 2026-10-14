
using UnityEngine;

public class Trajectory : MonoBehaviour
{
	[SerializeField] int dotsNumber;
	[SerializeField] GameObject dotsParent;
	[SerializeField] GameObject dotPrefab;
	[SerializeField] float dotSpacing;
	[SerializeField] [Range (0.01f, 0.3f)] float dotMinScale;
	[SerializeField] [Range (0.3f, 1f)] float dotMaxScale;

	Transform[] dotsList;

	Vector2 pos;
	//dot pos
	float timeStamp;

	//--------------------------------
	void Start ()
	{
		//hide trajectory in the start
		Hide ();
		//prepare dots
		PrepareDots ();
	}

	void PrepareDots ()
	{
		dotsList = new Transform[dotsNumber];
		dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

		float scale = dotMaxScale;
		float scaleFactor = scale / dotsNumber;

		for (int i = 0; i < dotsNumber; i++) {
			dotsList [i] = Instantiate (dotPrefab, null).transform;
			dotsList [i].parent = dotsParent.transform;

			dotsList [i].localScale = Vector3.one * scale;
			if (scale > dotMinScale)
				scale -= scaleFactor;
		}
	}

	public void UpdateDots(Vector3 ballPos, Vector2 initialVelocity)
	{
		timeStamp = dotSpacing;

		Vector2 gravity =
			Physics2D.gravity * GameManager.Instance.ball.rb.gravityScale;

		for (int i = 0; i < dotsNumber; i++)
		{
			Vector2 predictedPosition =
				(Vector2)ballPos
				+ initialVelocity * timeStamp
				+ 0.5f * gravity * timeStamp * timeStamp;

			dotsList[i].position = predictedPosition;
			timeStamp += dotSpacing;
		}
	}

	public void Show ()
	{
		dotsParent.SetActive (true);
	}

	public void Hide ()
	{
		dotsParent.SetActive (false);
	}
}
