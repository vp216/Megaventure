using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Interaction : MonoBehaviour {

	public GameObject canvasObject; 
	public GhostFreeRoamCamera camera;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	/*
	 * Created a class called 'Info' which holds information for an individual ride
	 * Each attribute is represented by a string variable, which is initiated to 'null'
	 * There is also a variable (imagesrc) which represents the relative file path to the ride's thumbnail
	 * 
	 */

	[System.Serializable]
	public class Info
	{
		public string year = "null";
		public string minh = "null";
		public string mincost = "null";
		public string maxspeed = "null";
		public string ftrack = "null";
		public string force = "null";
		public string tlength = "null";
		public string age = "null";
		//public string imagesrc = Application.dataPath + "/Ride Pictures/";
		public string imagesrc = "ridepics/";
	}


	/*
	 * Created a class called 'RideInfo' which holds the ride information for every ride, with each ride represented by the 'Info' class explained above
	 * This was done so that each ride 'Info' object could be referenced explicitly, as opposed to using an array 
	 * 
	 * 
	 */

	[System.Serializable]
	public class RideInfo
	{
		public Info bumpercars;
		public Info orbiter;
		public Info gravity;
		public Info twister;
		public Info vortex;
		public Info mysticswing;
		public Info teacupride;
		public Info krisskross;
		public Info feriswheel;
		public Info pirateship;
		public Info velocity;
	}

	/*Include at the end
	 * 
	 * The clicked object is marked active, and the camera movement and rotation is disabled before loading the ride information on screen
	 * 
	 * 
	 */

	public void OnMouseDown()
	{
		canvasObject.SetActive(true);
		camera.allowMovement = false;
		camera.allowRotation = false;
		SetDetails ();
	}

	/*In this section the data is loaded from a JSON file and stored in the 'RideInfo' data structure explained previously 
	 * The selected objects' tag is checked and the appropriate ride is selected from the 'RideInfo' object.
	 * Finally, the text labels on screen are set from the ride 'Info' object along with the thumbnail
	 * 
	 * 
	 */

	void SetDetails()
	{
		string json_file_dir = "rideinfo";
		TextAsset json_file = Resources.Load (json_file_dir, typeof(TextAsset)) as TextAsset;
		RideInfo rideInfo = JsonUtility.FromJson<RideInfo> (json_file.text);

		//RideInfo rideInfo = JsonUtility.FromJson<RideInfo>(File.ReadAllText(Application.dataPath + "/rideinfo.json"));
		Info ride;
		switch (transform.gameObject.tag)
		{
		case "Bumper Cars":
			ride = rideInfo.bumpercars;
			ride.imagesrc = ride.imagesrc + "bumpercar";
			break;
		case "Orbiter":
			ride = rideInfo.orbiter;
			ride.imagesrc = ride.imagesrc + "orbiter";
			break;
		case "Gravity":
			ride = rideInfo.gravity;
			ride.imagesrc = ride.imagesrc + "gravity";
			break;
		case "Twister":
			ride = rideInfo.twister;
			ride.imagesrc = ride.imagesrc + "twister";
			break;
		case "Vortex":
			ride = rideInfo.vortex;
			ride.imagesrc = ride.imagesrc + "vortex";
			break;
		case "Mystic Swing":
			ride = rideInfo.mysticswing;
			ride.imagesrc = ride.imagesrc + "mysticswing";
			break;
		case "Teacup Ride":
			ride = rideInfo.teacupride;
			ride.imagesrc = ride.imagesrc + "teacupride";
			break;
		case "Kriss Kross":
			ride = rideInfo.krisskross;
			ride.imagesrc = ride.imagesrc + "krisskross";
			break;
		case "Feris Wheel":
			ride = rideInfo.feriswheel;
			ride.imagesrc = ride.imagesrc + "feriswheel";
			break;
		case "Pirate Ship":
			ride = rideInfo.pirateship;
			ride.imagesrc = ride.imagesrc + "pirateship";
			break;
		case "Velocity":
			ride = rideInfo.velocity;
			ride.imagesrc = ride.imagesrc + "velocity";
			break;
		default:
			ride = new Info();
			break;
		}
		Text year = canvasObject.transform.Find ("Gameplaybox/year").GetComponent<Text> ();
		year.text = ride.year;
		Text minh = canvasObject.transform.Find ("Gameplaybox/minh").GetComponent<Text> ();
		minh.text = ride.minh;
		Text mincost = canvasObject.transform.Find ("Gameplaybox/mincost").GetComponent<Text> ();
		mincost.text = ride.mincost;
		Text maxspeed = canvasObject.transform.Find ("Gameplaybox/maxspeed").GetComponent<Text> ();
		maxspeed.text = ride.maxspeed;
		Text ftrack = canvasObject.transform.Find ("Gameplaybox/ftrack").GetComponent<Text> ();
		ftrack.text = ride.ftrack;
		Text force = canvasObject.transform.Find ("Gameplaybox/force").GetComponent<Text> ();
		force.text = ride.force;
		Text tlength = canvasObject.transform.Find ("Gameplaybox/tlength").GetComponent<Text> ();
		tlength.text = ride.tlength;
		Text age = canvasObject.transform.Find ("Gameplaybox/age").GetComponent<Text> ();
		age.text = ride.age;
	
		Texture2D texture = Resources.Load (ride.imagesrc, typeof(Texture2D)) as Texture2D;
		Sprite sprite = Sprite.Create(texture, new Rect(0,0,205,190), new Vector2(0.5f,0.0f), 1.0f);
		Image pic = canvasObject.transform.Find ("Gameplaybox/ridepic").GetComponent<Image> ();
		pic.sprite = sprite;
	}

	/*Include at the end
	 * 
	 * INTERACTION PART
	 * 
	 */




}