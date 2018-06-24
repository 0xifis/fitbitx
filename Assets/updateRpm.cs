using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class updateRpm : MonoBehaviour {
    private UnityEngine.AI.NavMeshAgent bikeAgent;

	// Use this for initialization
	void Start () {
        FirebaseApp.DefaultInstance
                   .SetEditorDatabaseUrl("https://angelhack11-7c8ce.firebaseio.com/");
        FirebaseDatabase.DefaultInstance
                        .GetReference("rpm")
                        .ValueChanged += HandleValueChanged;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        foreach (var childSnapshot in args.Snapshot.Children)
        {
            string rps = childSnapshot.Child("rpm").Value.ToString();
            int rpm = (int) float.Parse(rps, System.Globalization.CultureInfo.InvariantCulture);
            GetComponent<TextMesh>().text = rpm + " rpm";
            bikeAgent = GameObject.Find("MainChar")
                                  .GetComponent<UnityEngine.AI.NavMeshAgent>();
            bikeAgent.speed = (float)rpm / 20f;
        }
    }
}
