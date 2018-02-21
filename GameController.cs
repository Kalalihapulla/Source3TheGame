using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AssemblyCSharp;
using System.Collections.Generic;
using System;


/// <summary>
/// This class controls the movements assets in the game and menus, and loads all the locations and items
/// </summary>
public class GameController : MonoBehaviour {

	public List<Location> rooms = new List<Location> ();


	//all the rooms in the game, with map references to the right for clearance during design
	public GameObject moveOverlay;
	public GameObject menuOverlay;

	public GameObject bikerHideout;
	public GameObject northRoad; 		//between factory and hideout
	public GameObject factory;
	public GameObject tunnel;
	public GameObject industrialArea;

	public GameObject mainRoad1W; 		//northernmost
	public GameObject mainRoad1E;
	public GameObject mainRoad2W;		//between chinatown and familytown
	public GameObject mainRoad3W;		//W of chinatown
	public GameObject mainRoad4E;		//fobba
	public GameObject mainRoad5W;		//town square E
	public GameObject mainRoad5E;		//bank of gaben
	public GameObject mainRoad6WE;		//overpass over road
	public GameObject mainRoad7W;		//E of travel center
	public GameObject mainRoadSign;

	public GameObject church;
	public GameObject graveyard;
	public GameObject churchCYard;

	public GameObject china1;			//NW
	public GameObject china2;			//NE
	public GameObject china3;			//restaurant
	public GameObject china4;			//S of restaurant
	public GameObject china5;			//SW

	public GameObject family1;			//restaurant
	public GameObject family2;			//park
	public GameObject family3;			//intersection
	public GameObject family4;			//NE
	public GameObject family5;			//E of fire
	public GameObject family6;			//W of school
	public GameObject family7;			//N of school
	public GameObject family8;			//E of school
	public GameObject family9;			//E of fobba
	public GameObject family10;			//intersection SW of school
	public GameObject family11;			//S of school
	public GameObject family12;			//SE of school
	public GameObject family13;			//NW of alko
	public GameObject family14;			//E of alko

	public GameObject mountainRoad;
	public GameObject mountainArea;

	public GameObject fancy1;			//E of bar parking lot
	public GameObject fancy2;			//SW of alko
	public GameObject fancy3;			//SE of alko
	public GameObject fancy4;			//AB
	public GameObject fancy5;			//AC
	public GameObject fancy6;			//ABCD
	public GameObject fancy7;			//BD
	public GameObject fancy8;			//intersection between fancy and ghetto
	public GameObject fancy9;			//CD
	public GameObject fancy10;			//S of CD
	public GameObject fancy11;			//SE of D

	public GameObject ghetto1;			//BEN
	public GameObject ghetto2;			//SE of BEN
	public GameObject ghetto3;			//S of BEN
	public GameObject ghetto4;			//S of playground
	public GameObject ghetto5;			//N ghetto intersection
	public GameObject ghetto6;			//E of ghetto5
	public GameObject ghetto7;			//entrance to forest
	public GameObject ghetto8;			//trashcan area, 3 S of BEN
	public GameObject ghetto9;			//SE ghetto
	public GameObject ghetto10;			//NW of nekkers
	public GameObject ghetto11;			//N of nekkers
	public GameObject ghetto12;			//NE of nekkers
	public GameObject ghetto13;			//spugehoods

	public GameObject forest1;			//road to shack
	public GameObject forest2;			//shack outside
	public GameObject forest3;			//water by shack
	public GameObject forest4;			//beach
	public GameObject forest5;			//pier
	public GameObject forest6;			//road to pier
	public GameObject forest7;			//camping site
	public GameObject forest8;			//camping site entrance
	public GameObject forest9;			//path to camp site
	public GameObject forest10;			//path in forest near fancy and going to camp site

	public GameObject center1;			//office
	public GameObject center2;			//cafe
	public GameObject center3;			//kuja
	public GameObject center4;			//store
	public GameObject center5;			//S of store parking
	public GameObject center6;			//parking lot
	public GameObject center7;			//town square NW
	public GameObject center8;			//town square NE
	public GameObject center9;			//town square SW
	public GameObject center10;			//town square SE
	public GameObject center11;			//office parking hall

	public GameObject tourist1;			//medic
	public GameObject tourist2;			//bar exterior
	public GameObject tourist3;			//bar parking lot
	public GameObject tourist4;			//W of casino
	public GameObject tourist5;			//town hall
	public GameObject tourist6;			//S of casino

	public GameObject hotelRoom;
	public GameObject hotelHW;
	public GameObject hotelLobby;
	public GameObject shop1;
	public GameObject shop2;
	public GameObject cafe;
	public GameObject office;
	public GameObject parkingHall;
	public GameObject home;
	public GameObject house1;
	public GameObject house2;
	public GameObject hospitalLobby;
	public GameObject hospitalRoom;
	public GameObject townHall;
	public GameObject casino;
	public GameObject barDanceFloor;
	public GameObject barBackRoom;
	public GameObject travelCenter;
	public GameObject caravan;
	public GameObject boyzHideout;
	public GameObject boyzGunz;
	public GameObject playground;
	public GameObject fishingShack;
	public GameObject forestCellar;
	public GameObject ben;
	public GameObject bankLobby;
	public GameObject bankVault;
	public GameObject policeLobby;
	public GameObject policeJail;
	public GameObject alko;
	public GameObject fireStation;
	public GameObject school;
	public GameObject mountainShack;
	public GameObject mountainCellar;
	public GameObject familyRestaurant;
	public GameObject restaurantKitchen;
	public GameObject familyPark;
	public GameObject chineseRestaurant;
	public GameObject chineseBackroom;
	public GameObject churchInside;
	public GameObject factoryInside;
	public GameObject factoryLab;
	public GameObject bikerHideoutInside;
	public GameObject bikerGarage;

	public Button closeMap;
	public Button moveNorth;
	public Button moveEast;
	public Button moveSouth;
	public Button moveWest;
	public Button phoneButton;

	public Button object1;
	public Button object2;
	public Button object3;
	public Button object4;
	public Button object5;
	public Button object6;

	public GameObject textBoxImage;
	public Button textBoxButton;
	public Text playerLocationName;
	public Text textBox;

	public GameObject startScreen;
	public Button startGame;
	public Button quitGame;

	public AudioClip phoneOpen;
	public AudioClip moveSound;
	public AudioClip inventoryAddSound;
	public AudioClip startSound;

	public Player player = new Player ();
	public PhoneScript phone;
	public GameTriggers gT;
	public List <int> rng = new List <int> ();
	private int homeLoc;

	public List <Item> gameItems = new List <Item> ();

	void Awake() 
	{
	}

	/// <summary>
	/// Is run at start, loads the locations and sets the onClick attributes for the buttons on the overlay
	/// </summary>
	void Start () {
		homeLoc = AssignHome ();
		LoadLocations ();
		LoadItems ();
		AssignStartingItems ();

		phone.ActivatePhone ();
		gT.LoadTextEntries ();
		player.SetToStart (rooms [90]);
		playerLocationName.text = player.CurrentLocation.Name;
		phone.CloseMap ();
		phone.CloseInventory ();
		phone.ClosePhone ();

		moveNorth.onClick.AddListener (() => MoveNorth ());
		moveEast.onClick.AddListener (() => MoveEast ());
		moveSouth.onClick.AddListener (() => MoveSouth());
		moveWest.onClick.AddListener (() => MoveWest ());
		phoneButton.onClick.AddListener (() => ClickPhone ());
		textBoxButton.onClick.AddListener (() => textBoxImage.SetActive (false));
		quitGame.onClick.AddListener (() => phone.QuitGame ());
		startGame.onClick.AddListener (() => StartTheGame ());

		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = startSound;
		audio.Play ();
	}

	/// <summary>
	/// Assigns the games items to their starting location
	/// </summary>
	public void AssignStartingItems() {
		foreach (Item item in gameItems) {
			try {
				item.LocationFound.AddItemToLocation (item);
			} catch (NullReferenceException) {
			}
		}
	}

	/// <summary>
	/// Opens the phone object of the Phone class
	/// </summary>
	public void ClickPhone()
	{
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = phoneOpen;
		audio.Play ();
		phone.OpenPhone ();
	}

	/// <summary>
	/// Moves the player north if able
	/// </summary>
	public void MoveNorth()
	{
		if (rooms[player.CurrentLocation.ID] == rooms[player.CurrentLocation.North.ID]) {
			textBox.text = gT.textBoxEntries [0];
		} else if (player.CurrentLocation.NorthLocation == null) {
			textBox.text = gT.textBoxEntries [0];
		} else {
			player.CurrentLocation.NorthLocation.transform.SetAsLastSibling ();
			player.MovePlayer (player.CurrentLocation.NorthLocation, "north");
			MoveAssets ();
		}
	}

	/// <summary>
	/// Moves the player east if able
	/// </summary>
	public void MoveEast()
	{
		if (rooms[player.CurrentLocation.ID] == rooms[player.CurrentLocation.East.ID]) {
			textBox.text = gT.textBoxEntries [0];
		} else if (player.CurrentLocation.EastLocation == null) {
			textBox.text = gT.textBoxEntries [0];
		} else {
			player.CurrentLocation.EastLocation.transform.SetAsLastSibling ();
			player.MovePlayer (player.CurrentLocation.EastLocation, "east");
			MoveAssets ();
		}
	}

	/// <summary>
	/// Moves the player south if able
	/// </summary>
	public void MoveSouth()
	{
		if (rooms[player.CurrentLocation.ID] == rooms[player.CurrentLocation.South.ID]) {
			textBox.text = gT.textBoxEntries [0];
		} else if (player.CurrentLocation.SouthLocation == null) {
			textBox.text = gT.textBoxEntries [0];
		} else {
			player.CurrentLocation.SouthLocation.transform.SetAsLastSibling ();
			player.MovePlayer (player.CurrentLocation.SouthLocation, "south");
			MoveAssets ();
		}
	}

	/// <summary>
	/// Moves the player west if able
	/// </summary>
	public void MoveWest()
	{
		if (rooms[player.CurrentLocation.ID] == rooms[player.CurrentLocation.West.ID]) {
			textBox.text = gT.textBoxEntries [0];
		} else if (player.CurrentLocation.WestLocation == null) {
			textBox.text = gT.textBoxEntries [0];
		} else {
			player.CurrentLocation.WestLocation.transform.SetAsLastSibling ();
			player.MovePlayer (player.CurrentLocation.WestLocation, "west");
			MoveAssets ();
		}
	}

	/// <summary>
	/// Moves the player inside
	/// </summary>
	public void MoveInside()
	{
		try {
			player.MoveInside (player.CurrentLocation.InsideLocation);
			player.CurrentLocation.CurrentLocation.transform.SetAsLastSibling ();
			MoveAssets ();
		} catch (NullReferenceException) {
			Debug.Log ("Can't move in");
		}
	}

	/// <summary>
	/// Moves the player outside
	/// </summary>
	public void MoveOutisde()
	{
		try {
			player.MoveInside (player.CurrentLocation.OutsideLocation);
			player.CurrentLocation.CurrentLocation.transform.SetAsLastSibling ();
			MoveAssets ();
		} catch (NullReferenceException) {
			Debug.Log ("Can't move out");
		}
	}

	/// <summary>
	/// Adds the targeted item to the player inventory and removes it's object from the location
	/// </summary>
	/// <param name="item">The item to move to the inventory</param>
	/// <param name="pleb">The button to hide</param>
	public void AddToInventory(Item item, Button pleb)
	{
		if (!player.inventory.Contains (item)) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = inventoryAddSound;
			audio.Play ();
			player.inventory.Add (item);
			pleb.transform.gameObject.SetActive (false);
			gT.FindItem (item.Name);
		} else {
		}
	}

	/// <summary>
	/// Assigns the location for the player home via a randomiser
	/// </summary>
	/// <returns>The ID of the location that takes you home</returns>
	public int AssignHome() {
		bool check = true;
		int randomHome;
		while (check) {
			randomHome = UnityEngine.Random.Range (1, 11);
			if (!rng.Contains(randomHome)) {
				rng.Add(randomHome);
				check = false;
			} else {
			}
		}
		if (rng [0] == 1) {
			return 19;
		} else if (rng [0] == 2) {
			return 22;
		} else if (rng [0] == 3) {
			return 40;
		} else if (rng [0] == 4) {
			return 42;
		} else if (rng [0] == 5) {
			return 43;
		} else if (rng [0] == 6) {
			return 45;
		} else if (rng [0] == 7) {
			return 47;
		} else if (rng [0] == 8) {
			return 55;
		} else if (rng [0] == 9) {
			return 58;
		} else if (rng [0] == 10) {
			return 62;
		} else if (rng [0] == 11) {
			return 87;
		} else {
			return 0;
		}

	}

	/// <summary>
	/// Sets the player to the first game location from the start menu
	/// </summary>
	public void StartTheGame() {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = phoneOpen;
		audio.Play ();
		startScreen.SetActive (false);
		player.PlayerLocation.transform.SetAsLastSibling ();
		menuOverlay.transform.SetAsLastSibling ();
		moveOverlay.transform.SetAsLastSibling ();
		MoveAssets ();
		textBoxImage.SetActive (true);
		textBox.text = "I don't remember anything from the past days, but I definetly want to get back home. Maybe someone in town could help me?";
		audio.clip = startSound;
		audio.Stop ();

	}

	/// <summary>
	/// Assigns different layout objects their parameters and checks for locational triggers
	/// </summary>
	public void MoveAssets() {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = moveSound;
		audio.Play ();
		menuOverlay.transform.SetAsLastSibling ();
		if (player.CurrentLocation.IsRoom == false) {
			moveOverlay.transform.SetAsLastSibling ();
		} else {
			moveOverlay.transform.SetAsFirstSibling ();
		}
		playerLocationName.text = player.CurrentLocation.Name;
		textBoxImage.SetActive (false);
		gT.CheckTriggers ();
		gT.SetInteractionObjects ();
		player.Minutes = 6;
		if (player.CurrentLocation.IsVisited == false) {
			player.CurrentLocation.IsVisited = true;
		} else {
		}
	}

	/// <summary>
	/// Creates all the games items to a list
	/// </summary>
	public void LoadItems()
	{
		gameItems.Add (new Item ("Wallet", null, "wallet item", "It seems I live at " + rooms[98].OutsideLocation.Name + "."));
		gameItems.Add (new Item ("Keys", null, "keys item", "These must be the keys to my home."));
		gameItems.Add (new Item ("Watermelon", rooms[94], "watermelon item", "Juicy and fresh."));
		gameItems.Add (new Item ("Receipt", rooms [90], "receipt item", "Beer\t\t\t2\nTomato\t5\n\nThank you for visitin Steamy Sales, please come again!"));
		gameItems.Add (new Item ("Flashlight", rooms[95], "flashlight item", "Enlightening."));
		gameItems.Add (new Item ("Painting", rooms [96], "huuto", "This is definetly not a forgery."));
		gameItems.Add (new Item ("Medicine", rooms [102], "medicine bottle item", "At least I won't get sick now."));
		gameItems.Add (new Item ("Marlboro", rooms [114], "cigarette item", "These can't be good for my health."));
		gameItems.Add (new Item ("Gold Bar", rooms [116], "Gold bar item", "It's heavier than I thought."));
		gameItems.Add (new Item ("Vergi", rooms [119], "vergi item", "Fresh and tasty."));
		gameItems.Add (new Item ("Holy Idol of Gaben", null, "idol of gaben", "This seems like something the cultists would like their hands on."));
		gameItems.Add (new Item ("Gun", rooms [110], "gun item", "Pew pew."));
		gameItems.Add (new Item ("Gamburger", rooms [125], "hamburger item", "Cyka blyat!"));
		gameItems.Add (new Item ("Ring", rooms [16], "ring item", "This feels precious to me."));
		gameItems.Add (new Item ("MingLee's Menu", rooms [128], "mingree menu item", "Herro, wercome to MingRee's noodre shop. If no like noodre soup, prease go to famiry restaurant on oder side of town. Thanka you prease come again!"));
		gameItems.Add (new Item ("Note from Doctor", rooms [101], "note from doctor item", "Be adviced, the homeless have some sort of disease which we can not determine. I think we need to look into this matter."));
		gameItems.Add (new Item ("Napkin", rooms [106], "Napkin item", "There appears to be a beerstain on it. 'Meet me at the hut in the forest' is also written on the napkin."));
		gameItems.Add (new Item ("Car Keys", rooms [123], "carkeys item", "Someone must be looking for these."));
		gameItems.Add (new Item ("Odd Chemical Concoction", null, "chemical vial item", "Time to get wrecked!"));
		gameItems.Add (new Item ("Note from the Church", rooms [107], "note from church item", "The not says:\n'We are looking for a golden holy idol that went missing. If found, please return to the church for a reward.'"));
	}


	/// <summary>
	/// Loads all the games locations and assigns their parameters
	/// </summary>
	public void LoadLocations()
	{
		rooms.Add (new Location ("Gabens Disciples Hideout", bikerHideout, bikerHideout, northRoad, bikerHideout, bikerHideout, false, 0));
		rooms.Add (new Location ("North Road", northRoad, northRoad, factory, northRoad, bikerHideout, false, 1));
		rooms.Add (new Location ("Factory", factory, factory, mainRoad1W, factory, northRoad, false, 2));
		rooms.Add (new Location ("Tunnel", tunnel, tunnel, tunnel, mainRoad1W, tunnel, false, 3));
		rooms.Add (new Location ("Industrial Area", industrialArea, industrialArea, industrialArea, industrialArea, mainRoad1E, false, 4));
		rooms.Add (new Location ("Main Road North West", mainRoad1W, tunnel, mainRoad1E, mainRoad2W, factory, false, 5));
		rooms.Add (new Location ("Main Road North East", mainRoad1E, mainRoad1E, industrialArea, mainRoad2W, mainRoad1W, false, 6));
		rooms.Add (new Location ("Main Road Chinatown", mainRoad2W, mainRoad1W, mainRoad2W, mainRoad3W, china2, false, 7));
		rooms.Add (new Location ("Main Road Familytown", mainRoad3W, mainRoad2W, family1, mainRoad4E, mainRoad3W, false, 8));
		rooms.Add (new Location ("Main Road Police Station", mainRoad4E, mainRoad3W, mainRoad4E, mainRoad5W, center6, false, 9));
		rooms.Add (new Location ("Main Road Town Square", mainRoad5W, mainRoad4E, mainRoad5E, mainRoad6WE, center10, false, 10));
		rooms.Add (new Location ("Main Road Bank", mainRoad5E, mainRoad4E, mainRoad5E, mainRoad6WE, mainRoad5W, false, 11));
		rooms.Add (new Location ("Main Road Overpass", mainRoad6WE, mainRoad5W, fancy10, mainRoad7W, tourist6, false, 12));
		rooms.Add (new Location ("Main Road Travel Center", mainRoad7W, mainRoad6WE, mainRoad7W, mainRoadSign, mainRoad7W, false, 13));
		rooms.Add (new Location ("Main Road Sign", mainRoadSign, mainRoad7W, mainRoadSign, mainRoadSign, mainRoadSign, false, 14));
		rooms.Add (new Location ("Church", church, church, church, churchCYard, church, false, 15));
		rooms.Add (new Location ("Graveyard", graveyard, graveyard, churchCYard, graveyard, graveyard, false, 16));
		rooms.Add (new Location ("Church Courtyard", churchCYard, church, churchCYard, center1, graveyard, false, 17));
		rooms.Add (new Location ("Chinatown North Corner", china1, china1, china2, china3, china1, false, 18));
		rooms.Add (new Location ("Chinatown North Street", china2, china2, mainRoad2W, china2, china1, false, 19));
		rooms.Add (new Location ("Chinatown Restaurant", china3, china1, china3, china4, china3, false, 20));
		rooms.Add (new Location ("Chinatown West Street", china4, china3, china4, china5, china4, false, 21));
		rooms.Add (new Location ("Chinatown South Street", china5, china4, china5, center3, china5, false, 22));
		rooms.Add (new Location ("Familytown Firestation", family1, family1, family2, family1, mainRoad3W, false, 23));
		rooms.Add (new Location ("Familytown Park", family2, family2, family3, family5, family1, false, 24));
		rooms.Add (new Location ("Familytown North Intersection", family3, family3, family4, family6, family2, false, 25));
		rooms.Add (new Location ("Familytown North Street", family4, family4, family4, family8, family3, false, 26));
		rooms.Add (new Location ("Familytown West District", family5, family2, family5, family9, family5, false, 27));
		rooms.Add (new Location ("Familytown School Intersection", family6, family3, family7, family10, family6, false, 28));
		rooms.Add (new Location ("Familytown School", family7, family7, family8, family7, family6, false, 29));
		rooms.Add (new Location ("Familytown East Street", family8, family4, mountainRoad, family12, family7, false, 30));
		rooms.Add (new Location ("Familytown Police Station", family9, family5, family10, family13, family9, false, 31));
		rooms.Add (new Location ("Familytown South Intersection", family10, family6, family11, family14, family9, false, 32));
		rooms.Add (new Location ("Familytown South Side", family11, family11, family12, family11, family10, false, 33));
		rooms.Add (new Location ("Familytown South Street", family12, family8, family12, family12, family11, false, 34));
		rooms.Add (new Location ("Familytown Bank District", family13, family9, family14, family13, family13, false, 35));
		rooms.Add (new Location ("Familytwn South Intersection", family14, family10, family14, fancy3, family13, false, 36));
		rooms.Add (new Location ("Mountain Road", mountainRoad, mountainArea, mountainRoad, mountainRoad, family8, false, 37));
		rooms.Add (new Location ("Abandoned Mine", mountainArea, mountainArea, mountainArea, mountainRoad, mountainArea, false, 38));
		rooms.Add (new Location ("Fancytown Main Intersection", fancy1, fancy1, fancy2, fancy1, tourist3, false, 39));
		rooms.Add (new Location ("Fancytown North Street", fancy2, fancy2, fancy3, fancy4, fancy1, false, 40));
		rooms.Add (new Location ("Fancytown North Intersection", fancy3, family14, ghetto1, fancy8, fancy2, false, 41));
		rooms.Add (new Location ("Fancytown 1st Street", fancy4, fancy2, fancy4, fancy6, fancy4, false, 42));
		rooms.Add (new Location ("Fancytown 2nd Street", fancy5, fancy5, fancy6, fancy5, fancy5, false, 43));
		rooms.Add (new Location ("Fancytown Main District", fancy6, fancy4, fancy7, fancy9, fancy5, false, 44));
		rooms.Add (new Location ("Fancytown 3rd Street", fancy7, fancy7, fancy8, fancy7, fancy6, false, 45));
		rooms.Add (new Location ("Fancytown East Intersection", fancy8, fancy3, ghetto4, fancy11, fancy7, false, 46));
		rooms.Add (new Location ("Fancytown 4th Street", fancy9, fancy6, fancy9, fancy10, fancy9, false, 47));
		rooms.Add (new Location ("Fancytown South Intersection", fancy10, fancy9, fancy11, forest10, mainRoad6WE, false, 48));
		rooms.Add (new Location ("Fancytonw South Street", fancy11, fancy8, ghetto9, fancy11, fancy10, false, 49));
		rooms.Add (new Location ("Ben's Gas Station", ghetto1, ghetto1, ghetto2, ghetto3, fancy3, false, 50));
		rooms.Add (new Location ("Ghetto North Street", ghetto2, ghetto2, ghetto2, ghetto7, ghetto1, false, 51));
		rooms.Add (new Location ("Ghetto Playground", ghetto3, ghetto1, ghetto3, ghetto5, ghetto3, false, 52));
		rooms.Add (new Location ("Ghetto West Street", ghetto4, ghetto4, ghetto5, ghetto4, fancy8, false, 53));
		rooms.Add (new Location ("Ghetto North Intersection", ghetto5, ghetto3, ghetto6, ghetto8, ghetto4, false, 54));
		rooms.Add (new Location ("Ghetto East Street", ghetto6, ghetto6, ghetto7, ghetto6, ghetto5, false, 55));
		rooms.Add (new Location ("Ghetto Forest Street", ghetto7, ghetto2, forest1, ghetto12, ghetto6, false, 56));
		rooms.Add (new Location ("Ghetto Hood Street", ghetto8, ghetto5, ghetto8, ghetto10, ghetto8, false, 57));
		rooms.Add (new Location ("Ghetto Corner Street", ghetto9, ghetto9, ghetto10, ghetto9, fancy11, false, 58));
		rooms.Add (new Location ("Ghetto South Intersection", ghetto10, ghetto8, ghetto11, ghetto13, ghetto9, false, 59));
		rooms.Add (new Location ("Boyz in da Hood", ghetto11, ghetto11, ghetto12, ghetto11, ghetto10, false, 60));
		rooms.Add (new Location ("Ghetto South Street", ghetto12, ghetto7, ghetto12, ghetto12, ghetto11, false, 61));
		rooms.Add (new Location ("Ghetto Homeless Hood", ghetto13, ghetto10, ghetto13, ghetto13, ghetto13, false, 62));
		rooms.Add (new Location ("Forest Road", forest1, forest1, forest2, forest1, ghetto7, false, 63));
		rooms.Add (new Location ("Forest Shack", forest2, forest2, forest2, forest3, forest1, false, 64));
		rooms.Add (new Location ("Lake Road", forest3, forest2, forest3, forest4, forest3, false, 65));
		rooms.Add (new Location ("Lake Beach", forest4, forest3, forest4, forest5, forest4, false, 66));
		rooms.Add (new Location ("Lake Pier", forest5, forest4, forest5, forest6, forest5, false, 67));
		rooms.Add (new Location ("Road to Pier", forest6, forest5, forest6, forest6, forest7, false, 68));
		rooms.Add (new Location ("Camping Site", forest7, forest7, forest6, forest8, forest9, false, 69));
		rooms.Add (new Location ("Camping Site Entrance", forest8, forest7, forest8, forest8, forest8, false, 70));
		rooms.Add (new Location ("Path to Camp Site", forest9, forest9, forest7, forest9, forest10, false, 71));
		rooms.Add (new Location ("Path from Fancytown", forest10, fancy10, forest9, forest10, forest10, false, 72));
		rooms.Add (new Location ("Office Building", center1, churchCYard, center2, center11, center1, false, 73));
		rooms.Add (new Location ("Café", center2, center2, center3, center2, center1, false, 74));
		rooms.Add (new Location ("Steamy Alley", center3, china5, center4, center3, center2, false, 75));
		rooms.Add (new Location ("Steamy Sales", center4, center4, center5, center7, center3, false, 76));
		rooms.Add (new Location ("Hotel Street", center5, center6, center5, center8, center4, false, 77));
		rooms.Add (new Location ("Steam Sales Parking Lot", center6, center6, mainRoad4E, center5, center6, false, 78));
		rooms.Add (new Location ("Northwest Town Square", center7, center4, center8, center9, center7, false, 79));
		rooms.Add (new Location ("Northeast Town Square", center8, center5, center8, center10, center7, false, 80));
		rooms.Add (new Location ("Southwest Town Square", center9, center7, center10, tourist2, center9, false, 81));
		rooms.Add (new Location ("Southeast Town Square", center10, center8, mainRoad5W, tourist3, center9, false, 82));
		rooms.Add (new Location ("Office Parking Hall", center11, center1, tourist2, tourist1, center11, false, 83));
		rooms.Add (new Location ("Hospital", tourist1, center11, tourist1, tourist4, tourist1, false, 84));
		rooms.Add (new Location ("Bar Exterior", tourist2, center9, tourist3, tourist2, center11, false, 85));
		rooms.Add (new Location ("Bar Parking Lot", tourist3, center10, fancy1, tourist3, tourist2, false, 86));
		rooms.Add (new Location ("Valuetown West Street", tourist4, tourist1, tourist4, tourist5, tourist4, false, 87));
		rooms.Add (new Location ("Town Hall", tourist5, tourist4, tourist6, tourist5, tourist5, false, 88));
		rooms.Add (new Location ("Casino", tourist6, tourist6, mainRoad6WE, tourist6, tourist5, false, 89));
		rooms.Add(new Location("Hotel Room", hotelRoom,hotelLobby,null,null,null,true,90));
		rooms.Add(new Location("Hotel Hallway", hotelHW,null,null,null,null,true,91));
		rooms.Add(new Location("Hotel Lobby", hotelLobby,center7,null,hotelRoom,null,true,92));
		rooms.Add(new Location("Shop Cash Register", shop1,center4,null,shop2,null,true,93));
		rooms.Add(new Location("Back Of The Shop", shop2, shop1, null,null,null,true,94));
		rooms.Add(new Location("Cafe",cafe,center2,null,null,null,true,95));
		rooms.Add(new Location("Office",office,center1,null,null,null,true,96));
		rooms.Add(new Location("Parking Hall",parkingHall,center11,null,null,null,true,97));
		rooms.Add(new Location("Home",home,rooms[homeLoc].CurrentLocation,null,null,null,true,98));										//add rng to these 3 if time
		rooms.Add(new Location("Random House1",house1,fancy5,null,null,null,true,99));
		rooms.Add(new Location("Random House2",house2,china4,null,null,null,true,100));
		rooms.Add(new Location("Hospital Lobby",hospitalLobby,tourist1,null,hospitalRoom,null,true,101));
		rooms.Add(new Location("Hospital Room",hospitalRoom,hospitalLobby,null,null,null,true,102));
		rooms.Add(new Location("Town Hall",townHall,tourist5,null,null,null,true,103));
		rooms.Add(new Location("Casino Gambling Room",casino,tourist6,null,null,null,true,104));
		rooms.Add(new Location("Bar Dance Floor",barDanceFloor,tourist2,null,barBackRoom,null,true,105));
		rooms.Add(new Location("Bar Backroom",barBackRoom,barDanceFloor,null,null,null,true,106));
		rooms.Add(new Location("Travel Center",travelCenter,mainRoad7W,null,null,null,true,107));
		rooms.Add(new Location("Camping Site Caravan",caravan,forest7,null,null,null,true,108));
		rooms.Add(new Location("Boyz In Da Hood Hideout",boyzHideout,ghetto11,null,boyzGunz,null,true,109));
		rooms.Add(new Location("Boyz In Da Hood Gun Service",boyzGunz,boyzHideout,null,null,null,true,110));
		rooms.Add(new Location("Ghetto Playground",playground,ghetto1,null,ghetto4,null,true,111));
		rooms.Add(new Location("Fishing Shack",fishingShack,forest2,null,null,forestCellar,true,112));
		rooms.Add(new Location("Forest cellar",forestCellar,fishingShack,null,null,null,true,113));
		rooms.Add(new Location("Ben's Gas Station",ben,ghetto1,null,null,null,true,114));
		rooms.Add(new Location("Bank Lobby",bankLobby,mainRoad5E,null,bankVault,null,true,115));
		rooms.Add(new Location("Bank Vault",bankVault,bankLobby,null,null,null,true,116));
		rooms.Add(new Location("Police Station Lobby",policeLobby,mainRoad4E,null,policeJail,null,true,117));
		rooms.Add(new Location("Police Station Jail",policeJail,policeLobby,null,null,null,true,118));
		rooms.Add(new Location("Liquor Store",alko,family14,null,null,null,true,119));
		rooms.Add(new Location("Fire Station",fireStation,family1,null,null,null,true,120));
		rooms.Add(new Location("School",school,family7,null,null,null,true,121));
		rooms.Add(new Location("Old Mining Shack",mountainShack,null,null,null,null,true,122));						//not used
		rooms.Add(new Location("Mining Shack Cellar",mountainCellar,mountainArea,null,null,null,true,123));
		rooms.Add(new Location("Family Restaurant",familyRestaurant,family1,null,restaurantKitchen,null,true,124));
		rooms.Add(new Location("Family Restaurant Kitchen",restaurantKitchen,familyRestaurant,null,null,null,true,125));
		rooms.Add(new Location("Family Park",familyPark,family2,null,null,null,true,126));
		rooms.Add(new Location("Chinese Restaurant",chineseRestaurant,china3,null,chineseBackroom,null,true,127));
		rooms.Add(new Location("Chinese Restaurant Backroom",chineseBackroom,chineseRestaurant,null,null,null,true,128));
		rooms.Add(new Location("Church Of Gaben",churchInside,church,null,null,null,true,129));
		rooms.Add(new Location("Factory",factoryInside,factory,null,factoryLab,null,true,130));
		rooms.Add(new Location("Factory Lab",factoryLab,factoryInside,null,null,null,true,131));
		rooms.Add(new Location("Gaben's Disciples Garage",bikerGarage,bikerHideout,null,bikerHideoutInside,null,true,132));
		rooms.Add(new Location("Gaben's Disciples Hideout",bikerHideoutInside,bikerGarage,null,null,null,true,133));

		rooms[0].SetNextLocations(rooms[0], rooms[0], rooms[1], rooms[0], rooms[0]);
		rooms[1].SetNextLocations(rooms[1], rooms[1], rooms[2], rooms[1], rooms[0]);
		rooms[2].SetNextLocations(rooms[2], rooms[2], rooms[5], rooms[2], rooms[1]);
		rooms[3].SetNextLocations(rooms[3], rooms[3], rooms[3], rooms[5], rooms[3]);
		rooms[4].SetNextLocations(rooms[4], rooms[4], rooms[4], rooms[4], rooms[6]);
		rooms[5].SetNextLocations(rooms[5], rooms[3], rooms[6], rooms[7], rooms[2]);
		rooms[6].SetNextLocations(rooms[6], rooms[6], rooms[4], rooms[7], rooms[5]);
		rooms[7].SetNextLocations(rooms[7], rooms[5], rooms[7], rooms[8], rooms[19]);
		rooms[8].SetNextLocations(rooms[8], rooms[7], rooms[23], rooms[9], rooms[8]);
		rooms[9].SetNextLocations(rooms[9], rooms[8], rooms[9], rooms[10], rooms[78]);
		rooms[10].SetNextLocations(rooms[10], rooms[9], rooms[11], rooms[12], rooms[82]);
		rooms[11].SetNextLocations(rooms[11], rooms[9], rooms[11], rooms[12], rooms[10]);
		rooms[12].SetNextLocations(rooms[12], rooms[10], rooms[48], rooms[13], rooms[89]);
		rooms[13].SetNextLocations(rooms[13], rooms[12], rooms[13], rooms[14], rooms[13]);
		rooms[14].SetNextLocations(rooms[14], rooms[13], rooms[14], rooms[14], rooms[14]);
		rooms[15].SetNextLocations(rooms[15], rooms[15], rooms[15], rooms[17], rooms[15]);
		rooms[16].SetNextLocations(rooms[16], rooms[16], rooms[17], rooms[16], rooms[16]);
		rooms[17].SetNextLocations(rooms[17], rooms[15], rooms[17], rooms[73], rooms[16]);
		rooms[18].SetNextLocations(rooms[18], rooms[18], rooms[19], rooms[20], rooms[18]);
		rooms[19].SetNextLocations(rooms[19], rooms[19], rooms[7], rooms[19], rooms[18]);
		rooms[20].SetNextLocations(rooms[20], rooms[18], rooms[20], rooms[21], rooms[20]);
		rooms[21].SetNextLocations(rooms[21], rooms[20], rooms[20], rooms[22], rooms[20]);
		rooms[22].SetNextLocations(rooms[22], rooms[21], rooms[22], rooms[74], rooms[22]);
		rooms[23].SetNextLocations(rooms[23], rooms[23], rooms[24], rooms[23], rooms[8]);
		rooms[24].SetNextLocations(rooms[24], rooms[24], rooms[25], rooms[27], rooms[23]);
		rooms[25].SetNextLocations(rooms[25], rooms[25], rooms[26], rooms[28], rooms[24]);
		rooms[26].SetNextLocations(rooms[26], rooms[26], rooms[26], rooms[30], rooms[25]);
		rooms[27].SetNextLocations(rooms[27], rooms[24], rooms[27], rooms[31], rooms[27]);
		rooms[28].SetNextLocations(rooms[28], rooms[25], rooms[29], rooms[32], rooms[28]);
		rooms[29].SetNextLocations(rooms[29], rooms[29], rooms[30], rooms[29], rooms[28]);
		rooms[30].SetNextLocations(rooms[30], rooms[26], rooms[37], rooms[34], rooms[29]);
		rooms[31].SetNextLocations(rooms[31], rooms[27], rooms[32], rooms[35], rooms[31]);
		rooms[32].SetNextLocations(rooms[32], rooms[28], rooms[33], rooms[36], rooms[31]);
		rooms[33].SetNextLocations(rooms[33], rooms[33], rooms[34], rooms[33], rooms[32]);
		rooms[34].SetNextLocations(rooms[34], rooms[30], rooms[34], rooms[34], rooms[33]);
		rooms[35].SetNextLocations(rooms[35], rooms[31], rooms[36], rooms[35], rooms[35]);
		rooms[36].SetNextLocations(rooms[36], rooms[32], rooms[36], rooms[41], rooms[35]);
		rooms[37].SetNextLocations(rooms[37], rooms[38], rooms[37], rooms[37], rooms[30]);
		rooms[38].SetNextLocations(rooms[38], rooms[38], rooms[38], rooms[37], rooms[38]);
		rooms[39].SetNextLocations(rooms[39], rooms[39], rooms[40], rooms[39], rooms[86]);
		rooms[40].SetNextLocations(rooms[40], rooms[40], rooms[41], rooms[42], rooms[39]);
		rooms[41].SetNextLocations(rooms[41], rooms[36], rooms[50], rooms[46], rooms[40]);
		rooms[42].SetNextLocations(rooms[42], rooms[40], rooms[42], rooms[44], rooms[42]);
		rooms[43].SetNextLocations(rooms[43], rooms[43], rooms[44], rooms[43], rooms[43]);
		rooms[44].SetNextLocations(rooms[44], rooms[42], rooms[45], rooms[47], rooms[43]);
		rooms[45].SetNextLocations(rooms[45], rooms[45], rooms[46], rooms[45], rooms[44]);
		rooms[46].SetNextLocations(rooms[46], rooms[41], rooms[53], rooms[49], rooms[45]);
		rooms[47].SetNextLocations(rooms[47], rooms[44], rooms[47], rooms[48], rooms[47]);
		rooms[48].SetNextLocations(rooms[48], rooms[47], rooms[49], rooms[72], rooms[12]);
		rooms[49].SetNextLocations(rooms[49], rooms[46], rooms[58], rooms[49], rooms[48]);
		rooms[50].SetNextLocations(rooms[50], rooms[50], rooms[51], rooms[52], rooms[41]);
		rooms[51].SetNextLocations(rooms[51], rooms[51], rooms[51], rooms[56], rooms[50]);
		rooms[52].SetNextLocations(rooms[52], rooms[50], rooms[52], rooms[54], rooms[52]);
		rooms[53].SetNextLocations(rooms[53], rooms[53], rooms[54], rooms[53], rooms[46]);
		rooms[54].SetNextLocations(rooms[54], rooms[52], rooms[55], rooms[57], rooms[53]);
		rooms[55].SetNextLocations(rooms[55], rooms[55], rooms[56], rooms[55], rooms[54]);
		rooms[56].SetNextLocations(rooms[56], rooms[51], rooms[63], rooms[61], rooms[55]);
		rooms[57].SetNextLocations(rooms[57], rooms[54], rooms[57], rooms[59], rooms[57]);
		rooms[58].SetNextLocations(rooms[58], rooms[58], rooms[59], rooms[58], rooms[49]);
		rooms[59].SetNextLocations(rooms[59], rooms[57], rooms[60], rooms[62], rooms[58]);
		rooms[60].SetNextLocations(rooms[60], rooms[60], rooms[61], rooms[60], rooms[59]);
		rooms[61].SetNextLocations(rooms[61], rooms[56], rooms[61], rooms[61], rooms[60]);
		rooms[62].SetNextLocations(rooms[62], rooms[59], rooms[62], rooms[62], rooms[62]);
		rooms[63].SetNextLocations(rooms[63], rooms[63], rooms[64], rooms[63], rooms[56]);
		rooms[64].SetNextLocations(rooms[64], rooms[64], rooms[64], rooms[65], rooms[63]);
		rooms[65].SetNextLocations(rooms[65], rooms[64], rooms[65], rooms[66], rooms[65]);
		rooms[66].SetNextLocations(rooms[66], rooms[65], rooms[66], rooms[67], rooms[66]);
		rooms[67].SetNextLocations(rooms[67], rooms[66], rooms[67], rooms[68], rooms[67]);
		rooms[68].SetNextLocations(rooms[68], rooms[67], rooms[68], rooms[68], rooms[69]);
		rooms[69].SetNextLocations(rooms[69], rooms[69], rooms[68], rooms[70], rooms[71]);
		rooms[70].SetNextLocations(rooms[70], rooms[69], rooms[70], rooms[70], rooms[70]);
		rooms[71].SetNextLocations(rooms[71], rooms[71], rooms[69], rooms[71], rooms[72]);
		rooms[72].SetNextLocations(rooms[72], rooms[48], rooms[71], rooms[72], rooms[72]);
		rooms[73].SetNextLocations(rooms[73], rooms[17], rooms[74], rooms[83], rooms[73]);
		rooms[74].SetNextLocations(rooms[74], rooms[74], rooms[75], rooms[74], rooms[73]);
		rooms[75].SetNextLocations(rooms[75], rooms[22], rooms[76], rooms[75], rooms[74]);
		rooms[76].SetNextLocations(rooms[76], rooms[76], rooms[77], rooms[79], rooms[75]);
		rooms[77].SetNextLocations(rooms[77], rooms[78], rooms[77], rooms[80], rooms[76]);
		rooms[78].SetNextLocations(rooms[78], rooms[78], rooms[9], rooms[77], rooms[78]);
		rooms[79].SetNextLocations(rooms[79], rooms[76], rooms[80], rooms[81], rooms[79]);
		rooms[80].SetNextLocations(rooms[80], rooms[77], rooms[80], rooms[82], rooms[79]);
		rooms[81].SetNextLocations(rooms[81], rooms[79], rooms[82], rooms[85], rooms[81]);
		rooms[82].SetNextLocations(rooms[82], rooms[80], rooms[10], rooms[86], rooms[81]);
		rooms[83].SetNextLocations(rooms[83], rooms[73], rooms[85], rooms[84], rooms[83]);
		rooms[84].SetNextLocations(rooms[84], rooms[83], rooms[84], rooms[87], rooms[84]);
		rooms[85].SetNextLocations(rooms[85], rooms[81], rooms[86], rooms[85], rooms[83]);
		rooms[86].SetNextLocations(rooms[86], rooms[82], rooms[39], rooms[86], rooms[85]);
		rooms[87].SetNextLocations(rooms[87], rooms[84], rooms[87], rooms[88], rooms[87]);
		rooms[88].SetNextLocations(rooms[88], rooms[87], rooms[89], rooms[88], rooms[88]);
		rooms[89].SetNextLocations(rooms[89], rooms[89], rooms[12], rooms[89], rooms[88]);
		rooms[90].SetNextLocations(rooms[90], rooms[92], rooms[90], rooms[90], rooms[90]);
		rooms[91].SetNextLocations(rooms[91], rooms[91], rooms[91], rooms[91], rooms[91]);
		rooms[92].SetNextLocations(rooms[92], rooms[79], rooms[92], rooms[90], rooms[92]);
		rooms[93].SetNextLocations(rooms[93], rooms[76], rooms[93], rooms[93], rooms[93]);
		rooms[94].SetNextLocations(rooms[94], rooms[93], rooms[94], rooms[94], rooms[94]);
		rooms[95].SetNextLocations(rooms[95], rooms[74], rooms[95], rooms[95], rooms[95]);
		rooms[96].SetNextLocations(rooms[96], rooms[73], rooms[96], rooms[96], rooms[96]);
		rooms[97].SetNextLocations(rooms[97], rooms[83], rooms[97], rooms[97], rooms[97]);
		rooms[98].SetNextLocations(rooms[98], rooms[25], rooms[98], rooms[98], rooms[98]);
		rooms[99].SetNextLocations(rooms[99], rooms[43], rooms[99], rooms[99], rooms[99]);
		rooms[100].SetNextLocations(rooms[100], rooms[21], rooms[100], rooms[100], rooms[100]);
		rooms[101].SetNextLocations(rooms[101], rooms[84], rooms[101], rooms[102], rooms[101]);
		rooms[102].SetNextLocations(rooms[102], rooms[101], rooms[102], rooms[102], rooms[102]);
		rooms[103].SetNextLocations(rooms[103], rooms[88], rooms[103], rooms[103], rooms[103]);
		rooms[104].SetNextLocations(rooms[104], rooms[89], rooms[104], rooms[104], rooms[104]);
		rooms[105].SetNextLocations(rooms[105], rooms[85], rooms[105], rooms[106], rooms[105]);
		rooms[106].SetNextLocations(rooms[106], rooms[105], rooms[106], rooms[106], rooms[106]);
		rooms[107].SetNextLocations(rooms[107], rooms[13], rooms[107], rooms[107], rooms[107]);
		rooms[108].SetNextLocations(rooms[108], rooms[69], rooms[108], rooms[108], rooms[108]);
		rooms[109].SetNextLocations(rooms[109], rooms[60], rooms[109], rooms[110], rooms[109]);
		rooms[110].SetNextLocations(rooms[110], rooms[109], rooms[110], rooms[110], rooms[110]);
		rooms[111].SetNextLocations(rooms[111], rooms[53], rooms[111], rooms[111], rooms[111]);
		rooms[112].SetNextLocations(rooms[112], rooms[64], rooms[112], rooms[112], rooms[112]);
		rooms[113].SetNextLocations(rooms[113], rooms[64], rooms[113], rooms[113], rooms[113]);
		rooms[114].SetNextLocations(rooms[114], rooms[50], rooms[114], rooms[114], rooms[114]);
		rooms[115].SetNextLocations(rooms[115], rooms[11], rooms[115], rooms[116], rooms[115]);
		rooms[116].SetNextLocations(rooms[116], rooms[115], rooms[116], rooms[116], rooms[116]);
		rooms[117].SetNextLocations(rooms[117], rooms[9], rooms[117], rooms[118], rooms[117]);
		rooms[118].SetNextLocations(rooms[118], rooms[117], rooms[118], rooms[118], rooms[118]);
		rooms[119].SetNextLocations(rooms[119], rooms[36], rooms[119], rooms[119], rooms[119]);
		rooms[120].SetNextLocations(rooms[120], rooms[23], rooms[120], rooms[120], rooms[120]);
		rooms[121].SetNextLocations(rooms[121], rooms[29], rooms[121], rooms[121], rooms[121]);
		//rooms[122].SetNextLocations(rooms[122], rooms[38], rooms[122], rooms[123], rooms[122]);
		rooms[123].SetNextLocations(rooms[123], rooms[38], rooms[123], rooms[123], rooms[123]);
		rooms[124].SetNextLocations(rooms[124], rooms[23], rooms[124], rooms[125], rooms[124]);
		rooms[125].SetNextLocations(rooms[125], rooms[124], rooms[125], rooms[125], rooms[125]);
		rooms[126].SetNextLocations(rooms[126], rooms[24], rooms[126], rooms[126], rooms[126]);
		rooms[127].SetNextLocations(rooms[127], rooms[20], rooms[127], rooms[128], rooms[127]);
		rooms[128].SetNextLocations(rooms[128], rooms[127], rooms[128], rooms[128], rooms[128]);
		rooms[129].SetNextLocations(rooms[129], rooms[15], rooms[129], rooms[129], rooms[129]);
		rooms[130].SetNextLocations(rooms[130], rooms[3], rooms[130], rooms[131], rooms[130]);
		rooms[131].SetNextLocations(rooms[131], rooms[130], rooms[131], rooms[131], rooms[131]);
		rooms[132].SetNextLocations(rooms[132], rooms[1], rooms[132], rooms[133], rooms[132]);
		rooms[133].SetNextLocations(rooms[133], rooms[132], rooms[133], rooms[133], rooms[133]);

		rooms[92].InsideLocation = rooms[90];
		rooms[93].InsideLocation = rooms[94];
		rooms[101].InsideLocation = rooms[102];
		rooms[105].InsideLocation = rooms[106];
		rooms[109].InsideLocation = rooms[110];
		rooms[112].InsideLocation = rooms[113];
		rooms[115].InsideLocation = rooms[116];
		rooms[117].InsideLocation = rooms[118];
		rooms[124].InsideLocation = rooms[125];
		rooms[127].InsideLocation = rooms[128];
		rooms[130].InsideLocation = rooms[131];
		rooms[132].InsideLocation = rooms[133];
		rooms[23].InsideLocation = rooms [120];
		rooms[8].InsideLocation = rooms [124];
		rooms[79].InsideLocation = rooms [92];
		rooms[76].InsideLocation = rooms [93];
		rooms[74].InsideLocation = rooms [95];
		rooms[73].InsideLocation = rooms [96];
		rooms[84].InsideLocation = rooms [101];
		rooms[88].InsideLocation = rooms [103];
		rooms[89].InsideLocation = rooms [104];
		rooms[85].InsideLocation = rooms [105];
		rooms[13].InsideLocation = rooms [107];
		rooms[69].InsideLocation = rooms [108];
		rooms[60].InsideLocation = rooms [109];
		rooms[53].InsideLocation = rooms [111];
		rooms[64].InsideLocation = rooms [112];
		rooms[50].InsideLocation = rooms [114];
		rooms[11].InsideLocation = rooms [115];
		rooms[9].InsideLocation = rooms [117];
		rooms[36].InsideLocation = rooms [119];
		rooms[29].InsideLocation = rooms [121];
		rooms[38].InsideLocation = rooms [123];
		rooms[24].InsideLocation = rooms [126];
		rooms[20].InsideLocation = rooms [127];
		rooms[15].InsideLocation = rooms [129];
		rooms[2].InsideLocation = rooms [130];
		rooms[0].InsideLocation = rooms [132];
		rooms [homeLoc].InsideLocation = rooms [98];

		rooms[92].OutsideLocation = rooms[79];
		rooms[93].OutsideLocation = rooms[76];
		rooms[95].OutsideLocation = rooms[74];
		rooms[96].OutsideLocation = rooms[73];
		rooms[98].OutsideLocation = rooms[homeLoc];
		rooms[101].OutsideLocation = rooms[84];
		rooms[103].OutsideLocation = rooms[88];
		rooms[104].OutsideLocation = rooms[89];
		rooms[105].OutsideLocation = rooms[85];
		rooms[107].OutsideLocation = rooms[13];
		rooms[108].OutsideLocation = rooms[69];
		rooms[109].OutsideLocation = rooms[60];
		rooms[111].OutsideLocation = rooms[53];
		rooms[112].OutsideLocation = rooms[64];
		rooms[114].OutsideLocation = rooms[50];
		rooms[115].OutsideLocation = rooms[11];
		rooms[117].OutsideLocation = rooms[9];
		rooms[119].OutsideLocation = rooms[36];
		rooms[120].OutsideLocation = rooms[23];
		rooms[121].OutsideLocation = rooms[29];
		//rooms[122].OutsideLocation = rooms[38];
		rooms[124].OutsideLocation = rooms[8];
		rooms[126].OutsideLocation = rooms[24];
		rooms[127].OutsideLocation = rooms[20];
		rooms[129].OutsideLocation = rooms[15];
		rooms[130].OutsideLocation = rooms[2];
		rooms[132].OutsideLocation = rooms[0];
		rooms[90].OutsideLocation = rooms[92];
		rooms[94].OutsideLocation = rooms[93];
		rooms[102].OutsideLocation = rooms[101];
		rooms[106].OutsideLocation = rooms[105];
		rooms[110].OutsideLocation = rooms[109];
		rooms[113].OutsideLocation = rooms[112];
		rooms[116].OutsideLocation = rooms[115];
		rooms[118].OutsideLocation = rooms[117];
		rooms[123].OutsideLocation = rooms[38];
		rooms[125].OutsideLocation = rooms[124];
		rooms[128].OutsideLocation = rooms[127];
		rooms[131].OutsideLocation = rooms[130];
		rooms[133].OutsideLocation = rooms[132];
	}
}
