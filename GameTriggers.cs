using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	/// <summary>
	/// Determines different location based triggers and button triggers
	/// </summary>
	public class GameTriggers : MonoBehaviour {

		public List <string> textBoxEntries = new List <string> ();
		public GameController gC;
		public PhoneScript phone;
		public GameObject winScreen;
		public Text winText;
		public bool disc = false;
		public AudioClip doorLockedSound;
		public AudioClip noItemSound;
		public AudioClip winSound;
		public Text timeText;

		/// <summary>
		/// Creates all the randomised text entries to a list
		/// </summary>
		public void LoadTextEntries() 
		{
			textBoxEntries.Add ("I cannot go there.");
			textBoxEntries.Add ("I found nothing of value");
			textBoxEntries.Add ("There seems to be nothing of importance.");
			textBoxEntries.Add ("Nothing interesting happens.");
			textBoxEntries.Add ("I can only see rubbish.");
			textBoxEntries.Add ("Nothing valuable here.");
			textBoxEntries.Add ("The door seems locked.");
			textBoxEntries.Add ("Nobody is home I guess.");
			textBoxEntries.Add ("The door wont budge.");
			textBoxEntries.Add ("It seems stuck.");
			textBoxEntries.Add ("I don't think I'm supposed to go there.");

		}
			
		/// <summary>
		/// Checks the players location and items it associates with
		/// </summary>
		public void CheckTriggers()
		{
			if ((gC.player.inventory.Contains (gC.gameItems [0])) && (gC.player.inventory.Contains (gC.gameItems [1])) && (gC.player.CurrentLocation == gC.rooms [98])) {
				try {
					gC.object1 = GameObject.Find (gC.player.PlayerLocation.name + "Object1").GetComponent<Button> ();
					gC.object1.onClick.AddListener (() => WinGame ());
					CheckTextBox ();
					gC.textBox.text = "Finally home with my stuff, I should open my computer now.";
				} catch (NullReferenceException) {
				}
			} else if (gC.player.CurrentLocation == gC.rooms [109]) {
				CheckTextBox ();
				if (gC.player.inventory.Contains (gC.gameItems [2])) {
					CheckTextBox ();
					gC.textBox.text = "Aight we cool fam.";
				} else if ((gC.player.inventory.Contains (gC.gameItems [18])) && (gC.player.inventory.Contains (gC.gameItems [2]))) {
					CheckTextBox ();
					gC.player.inventory.Remove (gC.gameItems [18]);
					gC.textBox.text = "Hey fam thanks for bringin' us the stuff, you ass should head out to the park in Familytown, we hid that golden statue there. Be seeing you around mah nigs.";
				} else {
					CheckTextBox ();
					gC.textBox.text = "Who you think you are coming sneaking about here fool?";
				}	
			} else if (gC.player.CurrentLocation == gC.rooms [92]) {
				CheckTextBox ();
				gC.textBox.text = "Hello, welcome to the hotel. Enjoy your stay.";
			} else if (gC.player.CurrentLocation == gC.rooms [93]) {
				if (gC.player.inventory.Contains (gC.gameItems [3])) {
					CheckTextBox ();
					gC.textBox.text = "Hey, I remember you from last night, did you end up going to Ben's?";
				} else {
				}
			} else if (gC.player.CurrentLocation == gC.rooms [62]) {
				if (gC.player.inventory.Contains (gC.gameItems [9])) {
					CheckTextBox ();
					gC.textBox.text = "Hey man that's my favorite.";
					gC.player.inventory.Remove (gC.gameItems [9]);
				} else {
				}
			} else if (gC.player.CurrentLocation == gC.rooms [129]) {
				if (gC.player.inventory.Contains (gC.gameItems [10])) {
					CheckTextBox ();
					gC.player.inventory.Remove (gC.gameItems [10]);
					gC.textBox.text = "Bless thee for bringing us the holy idol. You can have this since we do not need it.";
					gC.player.inventory.Add (gC.gameItems [0]);
				} else {
				}
			} else if (gC.player.CurrentLocation == gC.rooms [114]) {
				if (gC.player.inventory.Contains (gC.gameItems [19])) {
					CheckTextBox ();
					gC.textBox.text = "Oh I see you're looking for the idol, I heard the factory workers have some knowledge of its location.";
				} else {
				}
			} else if (gC.player.CurrentLocation == gC.rooms [131]) {
				if (gC.player.inventory.Contains (gC.gameItems [19])) {
					CheckTextBox ();
					gC.textBox.text = "Ah you're looking for the idol are you now? You should take this to the Boyz in the Ghetto.";
					gC.player.inventory.Add (gC.gameItems [18]);
				} else {
					CheckTextBox ();
					gC.textBox.text = "You should not be here.";
				}
			} else if (gC.player.CurrentLocation == gC.rooms [126]) {
				CheckTextBox ();
				gC.textBox.text = "After searching for a while you find a golden statue. It looks familiar.";
				gC.player.inventory.Add (gC.gameItems [10]);
			} else if (gC.player.CurrentLocation == gC.rooms [120]) {
				if (gC.player.inventory.Contains (gC.gameItems [12])) {
					CheckTextBox ();
					gC.textBox.text = "Oh I was getting really hungry, thank you so much. You should talk the Disciples to the northwest, they were asking for you earlier.";
					gC.player.inventory.Remove (gC.gameItems [12]);
				} else {
				}
			} else if (gC.player.CurrentLocation == gC.rooms [133]) {
				if ((!gC.player.inventory.Contains (gC.gameItems [12])) && (gC.rooms [120].IsVisited)) {
					CheckTextBox ();
					gC.textBox.text = "We would like you to get us the menu of MingLees, we want to order some chinese you see. Get it for us and we're going to reward you.";
				} else if ((!gC.player.inventory.Contains (gC.gameItems [12])) && (gC.rooms [120].IsVisited) && (gC.player.inventory.Contains (gC.gameItems [14]))) {
					CheckTextBox ();
					disc = true;
					gC.textBox.text = "Thank you very much. Go to the parking hall near the GreyFace Industries office to receive your reward.";
				} else {
				}
			} else if (gC.player.CurrentLocation == gC.rooms [97]) {
				if (disc) {
					CheckTextBox ();
					gC.textBox.text = "Here is your reward.";
					gC.player.inventory.Add (gC.gameItems [1]);
				} else {
					CheckTextBox ();
					gC.textBox.text = "This place feels ominous.";
				}
			} else if (gC.player.CurrentLocation == gC.rooms [103]) {
				if (gC.player.inventory.Contains (gC.gameItems [5])) {
					CheckTextBox ();
					gC.textBox.text = "That's a very nice painting you have there.";
				} else {
				}
			} else if (gC.player.CurrentLocation == gC.rooms [115]) {
				if (gC.player.inventory.Contains (gC.gameItems [11])) {
					CheckTextBox ();
					gC.textBox.text = "You should not be here with that thing.";
				} else {
				}
			} else if (gC.player.CurrentLocation == gC.rooms [121]) {
				if (gC.player.inventory.Contains (gC.gameItems [11])) {
					CheckTextBox ();
					gC.textBox.text = "Get out of here right now.";
				} else {
				}
			} else if (gC.player.CurrentLocation == gC.rooms [4]) {
				if (gC.player.inventory.Contains (gC.gameItems [8])) {
					CheckTextBox ();
					gC.textBox.text = "Thats one shiny thing you have there.";
				} else {
				}
			} else {
			}
		}

		/// <summary>
		/// Sets the games victory condition
		/// </summary>
		public void WinGame() {
			winScreen.transform.SetAsLastSibling ();
			winText.text = "You won the game.\n It took you " + (gC.player.Days - 1) + " days, " + (gC.player.Hours - 10) + " hours and " + gC.player.Minutes + " minutes to complete the game.";
			timeText.text = (gC.player.Days - 1) * 24 + (gC.player.Hours - 10) + " hrs";
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = winSound;
			audio.Play ();
		}

		/// <summary>
		/// Interaction for an object without a particular use
		/// </summary>
		public void NoInt () {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = noItemSound;
			audio.Play ();
			CheckTextBox ();
			gC.textBox.text = RandomiseObjectOutput();
		}

		/// <summary>
		/// Interaction for a door that cant be accessed
		/// </summary>
		public void DoorLocked() {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = doorLockedSound;
			audio.Play ();
			CheckTextBox ();
			gC.textBox.text = RandomiseDoorOutput();
		}

		/// <summary>
		/// Tells the player what item was found
		/// </summary>
		/// <param name="itemName">The items name</param>
		public void FindItem(string itemName) {
			CheckTextBox ();
			gC.textBox.text = ("You found " + itemName);
		}

		/// <summary>
		/// Opens the text box
		/// </summary>
		public void CheckTextBox() {
			gC.textBoxImage.SetActive (true);
		}

		/// <summary>
		/// Chooses randomly one of the possible text that is displayed when running DoorLocked
		/// </summary>
		/// <returns>The text from the list</returns>
		public string RandomiseDoorOutput() {
			int random = UnityEngine.Random.Range (6, 10);
			return textBoxEntries [random];
		}

		/// <summary>
		/// Chooses randomly one of the possible text that is displayed when running NoInt
		/// </summary>
		/// <returns>The text from the list</returns>
		public string RandomiseObjectOutput() {
			int random = UnityEngine.Random.Range (1, 5);
			return textBoxEntries [random];
		}
			
		/// <summary>
		/// Sets the onclick methods for objects in the location if able
		/// </summary>
		public void SetInteractionObjects()
		{
			try {
				gC.object1.onClick.RemoveAllListeners();
				gC.object2.onClick.RemoveAllListeners();
				gC.object3.onClick.RemoveAllListeners();
				gC.object4.onClick.RemoveAllListeners();
				gC.object5.onClick.RemoveAllListeners();
				gC.object6.onClick.RemoveAllListeners();

			} catch (NullReferenceException) {
			}
			try {
				gC.object1 = GameObject.Find (gC.player.PlayerLocation.name + "Object1").GetComponent<Button> ();
				if (gC.player.CurrentLocation.IsRoom == true)
				{
					gC.object1.onClick.AddListener (() => gC.MoveOutisde());
				} else {
					gC.object1.onClick.AddListener (() => gC.MoveInside());
				}

			} catch (NullReferenceException) {
			}
		
			try {
				gC.object2 = GameObject.Find (gC.player.PlayerLocation.name + "Object2").GetComponent<Button> ();
				if (gC.player.CurrentLocation.IsRoom == true) 
				{
					gC.object2.onClick.AddListener (() => gC.MoveInside());
				} else {
				}
			} catch (NullReferenceException) {
			}

			try {
				gC.object3 = GameObject.Find (gC.player.PlayerLocation.name + "Object3").GetComponent<Button> ();
				gC.object3.onClick.AddListener (() => gC.AddToInventory(gC.player.CurrentLocation.obtainableItems[0], gC.object3));
			} catch (NullReferenceException) {
			}
		
			try {
				gC.object4 = GameObject.Find (gC.player.PlayerLocation.name + "Object4").GetComponent<Button> ();
				gC.object4.onClick.AddListener (() => gC.AddToInventory(gC.player.CurrentLocation.obtainableItems[1], gC.object4));
			} catch (NullReferenceException) {
			}

			try {
				gC.object5 = GameObject.Find (gC.player.PlayerLocation.name + "Object5").GetComponent<Button> ();
				gC.object5.onClick.AddListener (() => NoInt());
			} catch (NullReferenceException) {
			}

			try {
				gC.object6 = GameObject.Find (gC.player.PlayerLocation.name + "Object6").GetComponent<Button> ();
				gC.object6.onClick.AddListener (() => DoorLocked());
			} catch (NullReferenceException) {
			}
		}
	}
}
