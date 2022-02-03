using UnityEngine;

public class Movement : MonoBehaviour
{

    public float objectSpeed = 0.1f;
	[SerializeField]
	bool shouldDestroy;

	private bool stop;
	void Update()
	{

		if (stop || GameManager.Instance.isGameOver)
			return;
		if (transform.position.z <= -20)
		{
			if(shouldDestroy)
				GameObject.Destroy(gameObject);
		}
		else
			transform.Translate(0, 0, -objectSpeed * 200 * Time.deltaTime);

	}

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag.Equals("Goal"))
			stop = true;
    }
}
