using UnityEditor;
using UnityEngine;

public class Multiple_Builds : EditorWindow {

	#region build Variables
	bool pcGroupEnabled;
	string PC_Build_Location = "PC Build Location";

	bool macGroupEnabled;
	string Mac_Build_Location = "Mac Build Location";

	bool linuxGroupEnabled;
	string Linux_Build_Location  = "Linux Build Location";

	bool webGroupEnabled;
	string Web_Build_Location = "Web Build Location";

	bool appendBuildNotesEnabled;
	string buildNotesLocation = "Build Note Location";

	string BuildNotes = "Enter Build Notes Here";
	bool developmentBuild = false;
	bool allowDebugging = false;
	bool showBuiltFolders = false;

	#endregion

	bool showBuildOptions = true;
	Vector2 scrollPosition;
	string status = "Build Selection";

	// Add menu item named "My Window" to the Window menu
	[MenuItem("Window/Multiple Builds Window")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(Multiple_Builds));
	}
	
	void OnGUI()
	{
		GUILayout.Label ("Build Settings", EditorStyles.boldLabel);

		GUILayout.Label("Check the Platforms you would like to build.");

		#region Build Fold Out

		EditorGUILayout.Space();

		showBuildOptions = EditorGUILayout.Foldout(showBuildOptions, status);
		EditorGUILayout.Space();
		if(showBuildOptions){


			#region Build Options
			EditorGUILayout.Space();
			
			#region Linux Group
			linuxGroupEnabled = EditorGUILayout.BeginToggleGroup ("Build Linux: ", linuxGroupEnabled);
			Linux_Build_Location = EditorGUILayout.TextField ("", Linux_Build_Location);
			EditorGUILayout.EndToggleGroup ();
			#endregion
			
			EditorGUILayout.Space();
			
			#region Mac Group
			macGroupEnabled = EditorGUILayout.BeginToggleGroup ("Build Mac: ", macGroupEnabled);
			Mac_Build_Location = EditorGUILayout.TextField ("", Mac_Build_Location);
			EditorGUILayout.EndToggleGroup ();
			#endregion
			
			EditorGUILayout.Space();
			
			#region PC Group
			pcGroupEnabled = EditorGUILayout.BeginToggleGroup ("Build PC: ", pcGroupEnabled);
			PC_Build_Location = EditorGUILayout.TextField ("", PC_Build_Location);
			EditorGUILayout.EndToggleGroup ();
			#endregion
			
			EditorGUILayout.Space();
			
			#region Web Group
			webGroupEnabled = EditorGUILayout.BeginToggleGroup ("Build Web: ", webGroupEnabled);
			Web_Build_Location = EditorGUILayout.TextField ("", Web_Build_Location);
			EditorGUILayout.EndToggleGroup ();
			#endregion
			
			EditorGUILayout.Space();
			#endregion

		}

		#endregion

		#region Build Notes

		EditorGUILayout.Space();
		EditorGUILayout.Space();

		#region Build Note Text Area

		GUILayout.Label("Build Notes");
		scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);	
		BuildNotes = EditorGUILayout.TextArea(BuildNotes, GUILayout.Height(400));
		EditorGUILayout.EndScrollView();

		#endregion


		#endregion

		#region Build Extensions

		EditorGUILayout.Space();

		developmentBuild = EditorGUILayout.BeginToggleGroup("Development Build", developmentBuild);
			allowDebugging = EditorGUILayout.Toggle("Allow Debugging", allowDebugging);
		EditorGUILayout.EndToggleGroup();

		if(!developmentBuild){
			allowDebugging = false;
		}

		EditorGUILayout.Space();

		showBuiltFolders = EditorGUILayout.Toggle("Show Built Folders", showBuiltFolders);

		EditorGUILayout.Space();
		#endregion

		#region Append Build Notes
		appendBuildNotesEnabled = EditorGUILayout.BeginToggleGroup ("Append Build Notes: ", appendBuildNotesEnabled);
		buildNotesLocation = EditorGUILayout.TextField ("", buildNotesLocation);
		EditorGUILayout.EndToggleGroup ();
		#endregion

		#region Build Button
		if(GUILayout.Button("Build")) {
			
			//Check if selected fields are blank or not
			
			
			Debug.Log("Building");
		}
		#endregion
		
		#region Building Text
		EditorGUILayout.Space();
		
		if(!BuildPipeline.isBuildingPlayer){
			
			GUILayout.Label ("Build Status: Waiting To Build", EditorStyles.boldLabel);
		}else{
			
			GUILayout.Label ("Build Status: Building", EditorStyles.boldLabel);
		}
		
		#endregion
	}

	void BuildPC () {

		Debug.Log("Building PC");
		//BuildPipeline.BuildPlayer( UnityEditor.EditorBuildSettings.scenes, PC_Build_Location, BuildTarget.StandaloneWindows, BuildOptions.None);
	}

	void OnInspectorUpdate() {
		this.Repaint();
	}

}