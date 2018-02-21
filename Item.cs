using System;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	/// <summary>
	/// Governs the game items attributes
	/// </summary>
	public class Item
	{
		private string name;
		private string imageName;
		private Location locationFound;
		private RawImage itemTexture;
		private string examineText;

		public GameController gC = GameObject.Find("GameController").GetComponent<GameController> ();
		public GameTriggers gT = GameObject.Find ("GameTriggers").GetComponent<GameTriggers> ();

		public string Name {
			get {
				return name;
			} 
			set {
				name = value;
			}
		}

		public Location LocationFound {
			get {
				return locationFound;
			}
			set {
				locationFound = value;
			}
		}

		public string ImageName {
			get {
				return imageName;
			}
			set {
				imageName = value;
			}
		}

		public string ExamineText {
			get {
				return examineText;
			}
			set {
				examineText = value;
			}
		}

		public Item (string name, Location found, string imageName, string examine)
		{
			this.name = name;
			this.locationFound = found;
			this.imageName = imageName;
			this.examineText = examine;
		}

		public override string ToString ()
		{
			return Name;
		}

		/// <summary>
		/// Gets the examine text of the item to the inventory text box
		/// </summary>
		public void Examine()
		{
			gC.phone.inventoryText.text = this.examineText;
		}
	}
}