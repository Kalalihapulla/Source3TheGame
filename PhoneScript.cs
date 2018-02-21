using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace AssemblyCSharp
{
	/// <summary>
	/// Controls the functions of the phone overlay
	/// </summary>
	public class PhoneScript: MonoBehaviour{

		public Button inventoryButton;
		public Button mapButton;
		public Button closePhoneButton;
		public Button quitGameButton;
		public Button closeMapButton;
		public Button closeInventoryButton;
		public Button examineButton;

		public Button inventorySlot1Button;
		public Button inventorySlot2Button;
		public Button inventorySlot3Button;
		public Button inventorySlot4Button;
		public Button inventorySlot5Button;
		public Button inventorySlot6Button;
		public Button inventorySlot7Button;
		public Button inventorySlot8Button;
		public Button inventorySlot9Button;
		public Button inventorySlot10Button;
		public Button inventorySlot11Button;
		public Button inventorySlot12Button;
		public Button inventorySlot13Button;
		public Button inventorySlot14Button;
		public Button inventorySlot15Button;
		public Button inventorySlot16Button;
		public Button inventorySlot17Button;
		public Button inventorySlot18Button;
		public Button inventorySlot19Button;
		public Button inventorySlot20Button;

		public GameObject mapObject;
		public GameObject phoneObject;
		public GameObject inventoryObject;
		public GameObject inventorySlot;
		public GameObject inventoryConfirm;

		public AudioClip phoneCloseSound;
		public AudioClip examineItemSound;
		public AudioClip mapSound;
		public AudioClip phoneOpen;

		public GameTriggers gT;
		public GameController gC;

		public Text inventoryText;
		public Text timeText;
		private string completeInventory;
		private int inventoryCount;
		private RawImage itemImage;

		public List <Item> playerInventory = new List <Item> ();


		public GameObject PhoneObject {
			get {
				return phoneObject;
			}
			set {
				phoneObject = value;
			}
		}

		public Button InventoryButton {
			get {
				return inventoryButton;
			}
			set {
				inventoryButton = value;
			}
		}

		public Button MapButton {
			get {
				return mapButton;
			}
			set {
				mapButton = value;
			}
		}

		public Button ClosePhoneButton {
			get {
				return closePhoneButton;
			}
			set {
				closePhoneButton = value;
			}
		}

		public Button QuitGameButton {
			get {
				return quitGameButton;
			}
			set {
				quitGameButton = value;
			}
		}

		public string CompleteInventory {
			get {
				return completeInventory;
			}
			set {
				completeInventory = value;
			}
		}

		public int InventoryCount {
			get {
				return inventoryCount;
			}
			set {
				inventoryCount = value;
			}
		}

		/// <summary>
		/// Gives the phones buttons their methods and gives the current game time
		/// </summary>
		public void ActivatePhone() 
		{
			inventoryButton.onClick.AddListener (() => OpenInventory ());
			mapButton.onClick.AddListener (() => OpenMap ());
			closePhoneButton.onClick.AddListener (() => ClosePhone ());
			quitGameButton.onClick.AddListener (() => QuitGame ());
			closeMapButton.onClick.AddListener (() => CloseMap ());
			closeInventoryButton.onClick.AddListener (() => CloseInventory ());
			InventoryCount = 1;
			timeText.text = gC.player.CalculateTotalTime ();
		}

		/// <summary>
		/// Returns the names of the items in the players inventory
		/// </summary>
		/// <returns>The names of the items in the inventory</returns>
		public string DisplayInventory()
		{
			completeInventory = null;
			foreach (Item item in playerInventory) {
				completeInventory = completeInventory + "\n" + item.ToString ();
			}
			return completeInventory;
		}

		/// <summary>
		/// Shows the images of the items in the players inventory
		/// </summary>
		public void DisplayInventoryItems()
		{
			inventoryText.text = null;
			foreach (Item item in gC.player.inventory) {
				itemImage = GameObject.Find ("InventorySlot" + InventoryCount).GetComponent <RawImage> ();
				itemImage.texture = Resources.Load <Texture> (item.ImageName);
				inventoryCount = inventoryCount + 1;
			}
			InventoryCount = 1;
			SetButtons ();

		}

		/// <summary>
		/// Gives the inventory items their onclick function
		/// </summary>
		public void SetButtons() {
			inventorySlot1Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[0]));
			inventorySlot2Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[1]));
			inventorySlot3Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[2]));
			inventorySlot4Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[3]));
			inventorySlot5Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[4]));
			inventorySlot6Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[5]));
			inventorySlot7Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[6]));
			inventorySlot8Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[7]));
			inventorySlot9Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[8]));
			inventorySlot10Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[9]));
			inventorySlot11Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[10]));
			inventorySlot12Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[11]));
			inventorySlot13Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[12]));
			inventorySlot14Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[13]));
			inventorySlot15Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[14]));
			inventorySlot16Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[15]));
			inventorySlot17Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[16]));
			inventorySlot18Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[17]));
			inventorySlot19Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[18]));
			inventorySlot20Button.onClick.AddListener (() => ConfirmHLTV(gC.player.inventory[19]));
		}

		/// <summary>
		/// Opens the phone interface
		/// </summary>
		public void OpenPhone()
		{
			phoneObject.transform.SetAsLastSibling ();
		}

		/// <summary>
		/// Opens the inventory interface
		/// </summary>
		public void OpenInventory()
		{
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = phoneOpen;
			audio.Play ();
			inventoryObject.transform.SetAsLastSibling ();
			ClosePhone ();
			DisplayInventoryItems ();
		}

		/// <summary>
		/// Opens the map interface
		/// </summary>
		public void OpenMap()
		{
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = mapSound;
			audio.Play ();
			mapObject.transform.SetAsLastSibling ();
			ClosePhone ();
		}
			
		/// <summary>
		/// Gives the examineButton the onclick method for displaying the items examine text
		/// </summary>
		/// <param name="item">The item to be examined</param>
		public void ConfirmHLTV(Item item)
		{
			inventoryText.text = null;
			examineButton.onClick.RemoveAllListeners ();
			try
			{
				examineButton.onClick.AddListener (() => item.Examine ());
				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = examineItemSound;
				audio.Play ();
			} catch (NullReferenceException) {
				examineButton.onClick.AddListener (() => inventoryText.text = "There is no item there");
			} catch (ArgumentOutOfRangeException) {
				inventoryText.text = "There is no item there";
			}
		}

		/// <summary>
		/// Closes the phone interface
		/// </summary>
		public void ClosePhone()
		{
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = phoneCloseSound;
			audio.Play ();
			phoneObject.transform.SetAsFirstSibling ();
		}

		/// <summary>
		/// Quits the game
		/// </summary>
		public void QuitGame()
		{
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = phoneOpen;
			audio.Play ();
			Application.Quit ();
		}

		/// <summary>
		/// Closes the map
		/// </summary>
		public void CloseMap()
		{
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = phoneOpen;
			audio.Play ();
			mapObject.transform.SetAsFirstSibling ();
		}

		/// <summary>
		/// Closes the inventory interface
		/// </summary>
		public void CloseInventory()
		{
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = phoneOpen;
			audio.Play ();
			inventoryObject.transform.SetAsFirstSibling ();
		}
	}
}