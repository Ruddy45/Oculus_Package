using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR;

// Play hand animation
[RequireComponent(typeof(Animator))]
public class HandPresence : MonoBehaviour
{
	private const string TRIGGER_ID = "Trigger";
	private const string GRIP_ID = "Grip";

	[SerializeField] InputDeviceCharacteristics _controllerCharacteristics = InputDeviceCharacteristics.Left;

	private Animator _handAnimator = null;
	private InputDevice _targetDevice = new InputDevice();

	private void Start()
	{
		_handAnimator = GetComponent<Animator>();
		_targetDevice = GetDevice();
	}

	private void Update() => UpdateHandAnimation();

	private InputDevice GetDevice()
	{
		List<InputDevice> devices = new List<InputDevice>();

		InputDevices.GetDevicesWithCharacteristics(_controllerCharacteristics, devices);
		if (0 < devices.Count)
		{
			return devices[0];
		}

		Debug.LogError("Devices not found.");
		return new InputDevice();
	}

	private void UpdateHandAnimation()
	{
		if (!_targetDevice.isValid) { return; }

		TriggerAnimation();
		GripAnimation();
	}

	private void TriggerAnimation()
	{
		float triggerValue = 0f;
		if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float value))
		{
			triggerValue = value;
		}

		_handAnimator.SetFloat(TRIGGER_ID, triggerValue);
	}

	private void GripAnimation()
	{
		float gripValue = 0f;
		if (_targetDevice.TryGetFeatureValue(CommonUsages.grip, out float value))
		{
			gripValue = value;
		}

		_handAnimator.SetFloat(GRIP_ID, gripValue);
	}
}
