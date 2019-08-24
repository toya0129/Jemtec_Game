using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class PlayerPrefsEditor : MonoBehaviour
{
    [MenuItem("PlayerPrefs/DeleteAll")]
	public static void DeleteAll(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Flush ();
		Debug.Log("Delete All Data of PlayerPrefs");
	}
}
