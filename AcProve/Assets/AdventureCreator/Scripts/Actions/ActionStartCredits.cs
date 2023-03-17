using UnityEngine;


namespace AC
{

	[System.Serializable]
	public class ActionStartCredits : Action
	{
		// Declare properties here
		public override ActionCategory Category { get { return ActionCategory.RainbowHigh; }}
		public override string Title { get { return "Start Credits"; }}
		public override string Description { get { return "Launches the credits in game"; }}

		private bool mustBePlayed = true;
	

        public override void AssignValues()
        {
            base.AssignValues();
			mustBePlayed = true;
        }

        public override float Run ()
		{	
			if (!isRunning && mustBePlayed)
			{			
				StartCredits();
				isRunning = true;
				mustBePlayed = false;
			}

			if (isRunning)
			{
				return 1f;
			}

			return 0f;
		}

		private async void StartCredits()
        {

		}

		private async void EndCredits()
        {
			
		}
	}

}