using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{

	[System.Serializable]
	public class ActionLockCharacterChange : Action
	{
		
		// Declare properties here
		public override ActionCategory Category { get { return ActionCategory.RainbowHigh; }}
		public override string Title { get { return "Lock Character Change"; }}
		public override string Description { get { return "This is a blank Action template."; }}


		// Declare variables here
		public bool locked;
		
		


		public override void Skip ()
		{
			 Run ();
		}

		
		#if UNITY_EDITOR

		public override void ShowGUI ()
		{
			locked = EditorGUILayout.Toggle("Lock Character Change:", locked);
		}
		
		#endif
		
	}

}