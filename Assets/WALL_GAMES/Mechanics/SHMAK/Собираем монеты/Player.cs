using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] GameObject coinNumPrefab;

	CoinsManager coinsManager;

	void Start ()
	{
		coinsManager = FindObjectOfType<CoinsManager> ();
	}

	public void CoinDrop()
    {
		coinsManager.AddCoins(transform.position, 10);
		Destroy(Instantiate(coinNumPrefab, transform.position, Quaternion.identity), 0.1f);
	}
}
