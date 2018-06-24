using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class updateHr : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FirebaseApp.DefaultInstance
                   .SetEditorDatabaseUrl("https://angelhack11-7c8ce.firebaseio.com/");
        FirebaseDatabase.DefaultInstance
                        .GetReference("hr")
                        .ValueChanged += HandleValueChanged;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void HandleValueChanged(object sender, ValueChangedEventArgs args) {
        if(args.DatabaseError != null) {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        foreach (var childSnapshot in args.Snapshot.Children)
        {
            string hr = childSnapshot.Child("heartrate").Value.ToString();
            GetComponent<TextMesh>().text = hr + " bpm";
        }
    }
}
