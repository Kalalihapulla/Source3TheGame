using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	/// <summary>
	/// Is used for moving the player and calculating game time
	/// </summary>
	public class Player
	{
		private Location currentLocation;
		private GameObject playerLocation;
		public List <Item> inventory = new List <Item> ();
		private int minutes = 0;
		private int hours = 10;
		private int days = 1;


		public Location CurrentLocation {
			get {
				return currentLocation;
			}
			set {
				currentLocation = value;
			}
		}

		public GameObject PlayerLocation {
			get {
				return playerLocation;
			}
			set {
				playerLocation = value;
			}
		}

		public int Minutes {
			get {
				return minutes;
			} 
			set {
				minutes = minutes + value;
				if (minutes > 59) {
					minutes = minutes - 60;
					Hours = 1;
				} else {
				}
			}
		}

		public int Hours {
			get {
				return hours;
			}
			set {
				hours = hours + value;
				if (hours > 23) {
					hours = hours - 24;
					Days = 1;
				} else {
				}
			}
		}

		public int Days {
			get {
				return days;
			}
			set {
				days = days + value;
			}
		}

		public Player ()
		{

		}

		/// <summary>
		/// Sets the player to the starting location
		/// </summary>
		/// <param name="startLocation">Start location for the game</param>
		public void SetToStart(Location startLocation)
		{
			CurrentLocation = startLocation;
			PlayerLocation = startLocation.CurrentLocation;
		}


		/// <summary>
		/// Moves the player to the direction
		/// </summary>
		/// <param name="nextRoom">The next location in the given direction</param>
		/// <param name="direction">Direction to move to</param>
		public void MovePlayer(GameObject nextRoom, string direction)
		{
			this.playerLocation = nextRoom;
			if (direction == "north") {
				currentLocation = currentLocation.North;	
			} else if (direction == "east") {
				currentLocation = currentLocation.East;
			} else if (direction == "south") {
				currentLocation = currentLocation.South;
			} else {
				currentLocation = currentLocation.West;
			}
		}

		/// <summary>
		/// Moves the player to an inside location
		/// </summary>
		/// <param name="insideLocation">The indoors location associated with the current location</param>
		public void MoveInside(Location insideLocation)
		{
			currentLocation = insideLocation;
			playerLocation = insideLocation.CurrentLocation;
		}
			
		/// <summary>
		/// Calculates the total time
		/// </summary>
		/// <returns>The total time in a readable format</returns>
		public string CalculateTotalTime() 
		{
			return "Day " + Days.ToString () + ", " + Hours.ToString () + ":" + Minutes.ToString ();
		}
	}
}