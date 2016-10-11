using UnityEngine;
using System.Collections;

public class TestJar : MonoBehaviour {

	private AndroidJavaObject mod_fatctory = null;
	private AndroidJavaObject activityContext = null;
	// Use this for initialization
	void Start () {
		if (null != mod_fatctory)
			return;
		using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
		}
		using(AndroidJavaClass pluginClass = new AndroidJavaClass("com.openems.stim.EMSFactory")) {
			if (pluginClass != null) {
				mod_fatctory = pluginClass.CallStatic<AndroidJavaObject>("inst");
				mod_fatctory.Call("setContext", activityContext);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("mod_factory = " + (null == mod_fatctory ? "NULL" : "Not NULL"));
	}
}
