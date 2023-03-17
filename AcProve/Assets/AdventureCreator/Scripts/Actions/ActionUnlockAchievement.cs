
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{

	[System.Serializable]
	public class ActionUnlockAchievement : Action
	{
		
		// Declare properties here
		public override ActionCategory Category { get { return ActionCategory.Custom; }}
		public override string Title { get { return "Unlock Achievement"; }}
		public override string Description { get { return "This is a blank Action template."; }}

		// Declare variables here
		public int achievementId = 0;
		
		public override float Run ()
		{
			
			return 0f;			
		}
		
		#if UNITY_EDITOR

		public override void ShowGUI ()
		{
			achievementId = CustomGUILayout.IntField("Achievement Id", achievementId);
		}
		
		#endif
		
	}

}