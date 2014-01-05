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
	string buildNotesLocation = "Build Number/Name";

	string BuildNotes = "Enter Build Notes Here";
	bool developmentBuild = false;
	bool allowDebugging = false;
	bool showBuiltFolders = false;


	
	#endregion

	bool showBuildOptions = true;
	Vector2 scrollPosition;
	Vector2 scrollPosition2;
	string status = "Build Selection";

	int numberOfScenes;

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
			if( GUILayout.Button("Select Linux Build Location")) {
				Linux_Build_Location = EditorUtility.SaveFolderPanel("Linux Build Location", "", "");
			}
			Linux_Build_Location = EditorGUILayout.TextField ("", Linux_Build_Location);
			EditorGUILayout.EndToggleGroup ();
			#endregion
			
			EditorGUILayout.Space();
			
			#region Mac Group
			macGroupEnabled = EditorGUILayout.BeginToggleGroup ("Build Mac: ", macGroupEnabled);
			if( GUILayout.Button("Select Mac Build Location")) {
				Mac_Build_Location = EditorUtility.SaveFolderPanel("Mac Build Location", "", "");
			}
			Mac_Build_Location = EditorGUILayout.TextField ("", Mac_Build_Location);
			EditorGUILayout.EndToggleGroup ();
			#endregion
			
			EditorGUILayout.Space();
			
			#region PC Group
			pcGroupEnabled = EditorGUILayout.BeginToggleGroup ("Build PC: ", pcGroupEnabled);
			if( GUILayout.Button("Select PC Build Location")) {
				PC_Build_Location = EditorUtility.SaveFolderPanel("PC Build Location", PC_Build_Location, "");
			}
			PC_Build_Location = EditorGUILayout.TextField ("", PC_Build_Location);
			EditorGUILayout.EndToggleGroup ();
			#endregion
			
			EditorGUILayout.Space();
			
			#region Web Group
			webGroupEnabled = EditorGUILayout.BeginToggleGroup ("Build Web: ", webGroupEnabled);
			if( GUILayout.Button("Select Web Build Location")) {
				Web_Build_Location = EditorUtility.SaveFolderPanel("Web Build Location", "", "");
			}
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

		GUILayout.Label("Build Number / Name");
		buildNotesLocation = EditorGUILayout.TextField ("", buildNotesLocation);
		
		GUILayout.Label("Build Notes");
		scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);	
		BuildNotes = EditorGUILayout.TextArea(BuildNotes, GUILayout.Height(400));
		EditorGUILayout.EndScrollView();

		#endregion


		#endregion
		/*
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
		*/

		EditorGUILayout.Space();
		numberOfScenes = EditorGUILayout.IntField("Number of Unity Scenes:", numberOfScenes);
		string[] scenes = new string[numberOfScenes];
		scrollPosition2 = EditorGUILayout.BeginScrollView(scrollPosition2);
		EditorGUILayout.LabelField("Enter all Unity scenes include .unity");
		for(int i = 0; i < numberOfScenes; i++) {
			scenes[i] = EditorGUILayout.TextField("Scene Name:", scenes[i]);
		}
		EditorGUILayout.EndScrollView();

		#region Build Button
		if(GUILayout.Button("Build")) {

			if(pcGroupEnabled) {
				Debug.Log("Building PC");
				BuildPipeline.BuildPlayer( scenes, PC_Build_Location, BuildTarget.StandaloneWindows, BuildOptions.None);
			}

			if(macGroupEnabled) {

			}

			if(linuxGroupEnabled) {

			}

			if(webGroupEnabled) {

			}

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


	void OnInspectorUpdate() {
		this.Repaint();
	}

}