using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Win!!!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

}
