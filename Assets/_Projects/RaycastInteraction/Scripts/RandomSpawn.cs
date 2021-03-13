using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RandomSpawn : MonoBehaviour
{
	[SerializeField] private XRGrabInteractable _prefab = null;
	[SerializeField] private float _spawnRadius = 1.5f;
	[SerializeField, Range(0f, 3f)] private float _maxRadius = 1.5f;
	[SerializeField, Range(0, 100)] private int _maxSpawn = 50;

	private int _spawnNumber = 0;

	private void OnValidate() => _spawnRadius = Mathf.Clamp(_spawnRadius, 0f, _maxRadius);

	public void Spawn()
	{
		if (!_prefab) { return; }
		if (_maxSpawn < _spawnNumber) { return; }

		Vector3 randPos = transform.position + UnityEngine.Random.insideUnitSphere * _spawnRadius;

		XRGrabInteractable grab = Instantiate(_prefab, randPos, Quaternion.identity, transform);
		grab.name = $"{_prefab.name}_{_spawnNumber}";
		_spawnNumber++;
	}
}
