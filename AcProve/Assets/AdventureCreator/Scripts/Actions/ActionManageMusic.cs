using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{

	[System.Serializable]
	public class ActionManageMusic : Action
	{
		
		public enum MusicAction { Play, Stop }

		// Declare properties here
		public override ActionCategory Category { get { return ActionCategory.Custom; }}
		public override string Title { get { return "Music Manager"; }}
		public override string Description { get { return "Used to manage the currently played music"; }}


		// Declare variables here
		public MusicAction action = MusicAction.Play;
		public string songIntroAddressableName;
		public string songLoopAddressableName;
		public float transitionDuration = 0.5f;
		
		public override float Run ()
		{
			

			switch (action)
            {
                case MusicAction.Play:

					if (!string.IsNullOrEmpty(songIntroAddressableName))
					{
					
					}
					else if (!string.IsNullOrEmpty(songLoopAddressableName))
					{
						
					}

					break;
                case MusicAction.Stop:					



					break;
                default:
                    break;
            }
            
			
			isRunning = false;
			return 0f;
		}


		public override void Skip ()
		{
			 Run ();
		}

		
		#if UNITY_EDITOR

		public override void ShowGUI ()
		{
			action = (MusicAction)EditorGUILayout.EnumPopup("Action", action);
			songIntroAddressableName = EditorGUILayout.TextField("Song Intro Addressable Name", songIntroAddressableName);
			songLoopAddressableName = EditorGUILayout.TextField("Song Loop Addressable Name", songLoopAddressableName);
			transitionDuration = EditorGUILayout.FloatField("Transition Duration", transitionDuration);
		}
		
		#endif
		
	}

}