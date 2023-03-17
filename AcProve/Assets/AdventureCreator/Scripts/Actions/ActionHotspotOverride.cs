/*
 *
 *	Adventure Creator
 *	by Chris Burton, 2013-2021
 *	
 *	"ActionHotspotEnable.cs"
 * 
 *	This Action can enable and disable a Hotspot.
 * 
 */

using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{

	[System.Serializable]
	public class ActionHotspotOverride : Action
	{

		public int oldParameterID = -1;
		public int oldConstantID = 0;
		public Hotspot oldHotspot;
		protected Hotspot runtimeOldHotspot;

		public int newParameterID = -1;
		public int newConstantID = 0;
		public Hotspot newHotspot;
		protected Hotspot runtimeNewHotspot;

		public bool overrideHighlight = false;
		public bool overrideQuestHighlight = false;
		public bool overrideInteractions = false;

		
		public override ActionCategory Category { get { return ActionCategory.Hotspot; }}
		public override string Title { get { return "Override"; }}
		public override string Description { get { return "Turns a Hotspot on or off. To record the state of a Hotspot in save games, be sure to add the RememberHotspot script to the Hotspot in question."; }}


		public override void AssignValues (List<ActionParameter> parameters)
		{
			runtimeOldHotspot = AssignFile <Hotspot> (parameters, oldParameterID, oldConstantID, oldHotspot);
			runtimeNewHotspot = AssignFile <Hotspot> (parameters, newParameterID, newConstantID, newHotspot);
		}

		
		public override float Run ()
		{
			if (runtimeOldHotspot == null || runtimeNewHotspot == null)
			{
				return 0f;
			}

			OverrideHotspot (runtimeOldHotspot, runtimeNewHotspot);

			return 0f;
		}


		protected void OverrideHotspot (Hotspot _oldHotspot, Hotspot _newHotspot)
		{
            if (!overrideHighlight)
            {
				_newHotspot.highlight = _oldHotspot.highlight;
            }
            if (!overrideQuestHighlight)
            {
		
            }
            if (!overrideInteractions)
            {
				_newHotspot.interactionSource = _oldHotspot.interactionSource;
            }

			_oldHotspot.TurnOff();
			_newHotspot.TurnOn();
		}

		
		#if UNITY_EDITOR
		
		public override void ShowGUI (List<ActionParameter> parameters)
		{
			oldParameterID = Action.ChooseParameterGUI ("Old Hotspot", parameters, oldParameterID, ParameterType.GameObject);
			if (oldParameterID >= 0)
			{
				oldConstantID = 0;
				oldHotspot = null;
			}
			else
			{
				oldHotspot = (Hotspot) EditorGUILayout.ObjectField ("Old Hotspot:", oldHotspot, typeof (Hotspot), true);
				
				oldConstantID = FieldToID <Hotspot> (oldHotspot, oldConstantID);
				oldHotspot = IDToField <Hotspot> (oldHotspot, oldConstantID, false);
			}

			newParameterID = Action.ChooseParameterGUI("New Hotspot", parameters, newParameterID, ParameterType.GameObject);
			if (newParameterID >= 0)
			{
				newConstantID = 0;
				newHotspot = null;
			}
			else
			{
				newHotspot = (Hotspot)EditorGUILayout.ObjectField("New Hotspot:", newHotspot, typeof(Hotspot), true);

				newConstantID = FieldToID<Hotspot>(newHotspot, newConstantID);
				newHotspot = IDToField<Hotspot>(newHotspot, newConstantID, false);
			}

			overrideHighlight = EditorGUILayout.Toggle("Override Highlight", overrideHighlight);
			overrideQuestHighlight = EditorGUILayout.Toggle("Override Quest Highlight", overrideQuestHighlight);
			overrideInteractions = EditorGUILayout.Toggle("Override Interactions", overrideInteractions);
		}


		public override void AssignConstantIDs (bool saveScriptsToo, bool fromAssetFile)
		{
			if (saveScriptsToo)
			{
				AddSaveScript <RememberHotspot> (oldHotspot);
				AddSaveScript <RememberHotspot> (newHotspot);
			}
			AssignConstantID <Hotspot> (oldHotspot, oldConstantID, oldParameterID);
			AssignConstantID <Hotspot> (newHotspot, newConstantID, newParameterID);
		}
		
		#endif


		/**
		 * <summary>Creates a new instance of the 'Hotspot: Enable or disable' Action</summary>
		 * <param name = "hotspotToAffect">The Hotspot to affect</param>
		 * <param name = "changeToMake">The type of change to make</param>
		 * <returns>The generated Action</returns>
		 */
		public static ActionHotspotEnable CreateNew (Hotspot hotspotToAffect, ChangeType changeToMake)
		{
			ActionHotspotEnable newAction = CreateNew<ActionHotspotEnable> ();
			newAction.hotspot = hotspotToAffect;
			newAction.changeType = changeToMake;
			return newAction;
		}
		
	}

}