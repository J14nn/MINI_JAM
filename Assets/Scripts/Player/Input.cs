using UnityEngine;
using UnityEngine.InputSystem;

public static class Input
{
	public static PlayerInputAsset.PlayerActions player;
	public static PlayerInputAsset asset = new PlayerInputAsset();

	static Input()
	{
		player = asset.Player;
		asset.Enable();
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void Init()
	{
		if (asset == null)
		{
			asset = new PlayerInputAsset();
			player = asset.Player;
		}

		asset.Enable();
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void BindQuit()
	{
		Application.quitting += () => asset?.Disable();
	}

	public static Vector2 mousePosition => player.MousePosition.ReadValue<Vector2>();

	public static bool GetKeyDown(Key key)
	{
		return Keyboard.current[key].wasPressedThisFrame;
	}

	public static bool GetKeyUp(Key key)
	{
		return Keyboard.current[key].wasReleasedThisFrame;
	}

	public static bool GetKey(Key key)
	{
		return Keyboard.current[key].isPressed;
	}
}