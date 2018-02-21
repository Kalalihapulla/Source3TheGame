using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	/// <summary>
	/// Is used for setting and determining a game locations relative locations
	/// </summary>
	public class Location
	{
		private GameObject currentLocation;
		private GameObject northLocation;
		private GameObject eastLocation;
		private GameObject southLocation;
		private GameObject westLocation;

		private Location insideLocation;
		private Location outsideLocation;
		private Location locationNow;
		private Location north;
		private Location east;
		private Location south;
		private Location west;

		private string name;
		private bool isRoom;
		private bool isVisited = false;
		private int id;
		public List <Item> obtainableItems = new List <Item> ();

		public GameController gC = GameObject.Find("GameController").GetComponent<GameController> ();


		public GameObject CurrentLocation {
			get {
				return currentLocation;
			}
			set {
				currentLocation = value;
			}
		}

		public GameObject NorthLocation {
			get {
				return northLocation;
			}
			set {
				northLocation = value;
			}
		}

		public GameObject EastLocation {
			get {
				return eastLocation;
			}
			set {
				eastLocation = value;
			}
		}

		public GameObject SouthLocation {
			get {
				return southLocation;
			}
			set {
				southLocation = value;
			}
		}

		public GameObject WestLocation {
			get {
				return westLocation;
			}
			set {
				westLocation = value;
			}
		}

		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}

		public bool IsRoom {
			get {
				return isRoom;
			}
			set {
				isRoom = value;
			}
		}

		public int ID {
			get {
				return id;
			}
			set {
				id = value;
			}
		}

		public Location LocationNow {
			get {
				return locationNow;
			}
			set {
				locationNow = value;
			}
		}

		public Location North {
			get {
				return north;
			}
			set {
				north = value;
			}
		}

		public Location East {
			get {
				return east;
			}
			set {
				east = value;
			}
		}

		public Location South {
			get {
				return south;
			}
			set {
				south = value;
			}
		}

		public Location West {
			get {
				return west;
			}
			set {
				west = value;
			}
		}

		public Location InsideLocation {
			get {
				return insideLocation;
			}
			set {
				insideLocation = value;
			}
		}

		public Location OutsideLocation {
			get {
				return outsideLocation;
			}
			set {
				outsideLocation = value;
			}
		}

		public bool IsVisited {
			get {
				return isVisited;
			}
			set {
				isVisited = value;
			}
		}

		public Location (string name, GameObject roomCurrent, GameObject roomNorth, GameObject roomEast, GameObject roomSouth, GameObject roomWest, bool isRoom, int idnum)
		{
			this.Name = name;
			this.CurrentLocation = roomCurrent;
			this.NorthLocation = roomNorth;
			this.EastLocation = roomEast;
			this.SouthLocation = roomSouth;
			this.WestLocation = roomWest;
			this.IsRoom = isRoom;
			this.ID = idnum;
		}

		/// <summary>
		/// Assigns the locations relative to the current locations according to directions
		/// </summary>
		/// <param name="current">The current location</param>
		/// <param name="north">The location to the north of the current location</param>
		/// <param name="east">The location to the east of the current location</param>
		/// <param name="south">The location to the south of the current location</param>
		/// <param name="west">The location to the east of the current location</param>
		public void SetNextLocations(Location current, Location north, Location east, Location south, Location west)
		{
			this.LocationNow = current;
			this.North = north;
			this.East = east;
			this.South = south;
			this.West = west;
		}

		/// <summary>
		/// Associates an item with the location
		/// </summary>
		/// <param name="item">The item that is found in the location</param>
		public void AddItemToLocation (Item item) 
		{
			obtainableItems.Add (item);
		}
	}
}