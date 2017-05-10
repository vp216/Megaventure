using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour {
	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown textureQualityDropdown;
	public Dropdown antialiasingDropdown;
	public Button applyButton;

	public Resolution[] resolutions;
	public GameSettings gameSettings;

	void OnEnable()
	{
		gameSettings = new GameSettings ();

		fullscreenToggle.onValueChanged.AddListener (delegate {
			OnFullscreenToggle ();
		});
		resolutionDropdown.onValueChanged.AddListener (delegate {
			OnResolutionChange ();
		});
		textureQualityDropdown.onValueChanged.AddListener (delegate {
			OnTextureQualityChange ();
		});
		antialiasingDropdown.onValueChanged.AddListener (delegate {
			OnAntialiasingChange ();
		});
		applyButton.onClick.AddListener (delegate {
			OnApplyButtonClick ();
		});

		resolutions = Screen.resolutions;
		foreach (Resolution resolution in resolutions) {
			resolutionDropdown.options.Add (new Dropdown.OptionData (resolution.ToString ()));
		}

	}

	public void OnFullscreenToggle()
	{
		gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}
	public void OnResolutionChange()
	{
		Screen.SetResolution (resolutions [resolutionDropdown.value].width, resolutions [resolutionDropdown.value].height, Screen.fullScreen);
		gameSettings.resolutionIndex = resolutionDropdown.value;	
	}
	public void OnTextureQualityChange()
	{
		QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
	}
	public void OnAntialiasingChange()
	{
		QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow (2f, antialiasingDropdown.value);
	}
	public void OnApplyButtonClick()
	{
		SaveSettings ();
	}
	public void SaveSettings()
	{
		string jsonData = JsonUtility.ToJson (gameSettings, true);
		File.WriteAllText (Application.persistentDataPath + "/gamesettings.json", jsonData);
	}
	public void LoadSettings()
	{
		gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

		antialiasingDropdown.value = gameSettings.antialiasing;
		textureQualityDropdown.value = gameSettings.textureQuality;
		resolutionDropdown.value = gameSettings.resolutionIndex;
		fullscreenToggle.isOn = gameSettings.fullscreen;
		Screen.fullScreen = gameSettings.fullscreen;

		resolutionDropdown.RefreshShownValue ();
	}
}
