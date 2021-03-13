using UnityEngine;

// Show hand and controllers
public class SpawnControllerModel : MonoBehaviour
{
	[SerializeField] private bool _showHand = false;
	[SerializeField] private GameObject _hand = null;
	[SerializeField] private GameObject _controllers = null;

	private void Start() => SpawnHandAndController();

	private void SpawnHandAndController()
	{
		if (_showHand)
		{
			GameObject spawnedHand = Instantiate(_hand, transform);
			spawnedHand.name = _hand.name;
		}
		else
		{
			GameObject spawnedController = Instantiate(_controllers, transform);
			spawnedController.name = _controllers.name;
		}
	}
}
