using UnityEngine;
using UnityEngine.UI;

//
// The team is looking to implement an external payment solution to be able to handle
// purchases on web. As a result, the game needs a button that opens up a webpage
// to process the payment. When trying locally in the editor, the following script works
// however when the build is deployed, there is inconsistent behaviour. On some browsers and
// operating systems it works fine, but on something like iOS Safari a "popup blocked" warning appears.
//
// You can assume no compile errors and that any references are correctly linked in the Unity inspector.
// You can also assume the URL is correct for the purposes of this exercise.
//
// 1. Why might we be seeing this warning? (think more about Unity's implementation than browser security)
// 2. Make any changes/additions to prevent the warning in the first place.
//
public class StoreController : MonoBehaviour
{
	[SerializeField]
	Button buyButton;

	const string BASE_URL = "http://localhost:8080";

	public void Start()
	{
		buyButton.onClick.AddListener(BuyItem);
	}

	void BuyItem()
	{
		// I have to use a third party unity In App Browser asset to make the Unity game to open a in app browser when it's ran on mobile.
		// Popup warning should no longer appear.
		#if UNITY_STANDALONE_OSX || UNITY_STANDALONE
		Application.OpenURL(string.Format("{0}/buyItem", BASE_URL));
		#else
		InAppBrowser.OpenURL(string.Format("{0}/buyItem", BASE_URL));
		#endif
	}
}
