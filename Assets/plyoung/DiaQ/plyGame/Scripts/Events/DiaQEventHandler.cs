using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using plyBloxKit;

namespace DiaQ
{
	[AddComponentMenu("")]
	public class DiaQEventHandler : plyEventHandler
	{

		private List<plyEvent> acceptedEvents = new List<plyEvent>(0);
		private List<plyEvent> completedEvents = new List<plyEvent>(0);
		private List<plyEvent> rewardedEvents = new List<plyEvent>(0);

		// ============================================================================================================

		protected void OnDestroy()
		{
			// must unregister with DiaQEngine events
			DiaQEngine.onQuestAccepted -= OnAcceptedQuest;
			DiaQEngine.onQuestCompleted -= OnCompletedQuest;
			DiaQEngine.onQuestRewarded -= OnRewardedQuest;
		}

		public override void StateChanged()
		{
			acceptedEvents = new List<plyEvent>(0);
			completedEvents = new List<plyEvent>(0);
			rewardedEvents = new List<plyEvent>(0);
		}

		public override void AddEvent(plyEvent e)
		{
			if (e.uniqueIdent.Equals("On Quest Accepted"))
			{
				DiaQEngine.onQuestAccepted -= OnAcceptedQuest; // this is to prevent that OnAcceptQuest is added more than once
				DiaQEngine.onQuestAccepted += OnAcceptedQuest;
				acceptedEvents.Add(e);
			}
			else if (e.uniqueIdent.Equals("On Quest Completed"))
			{
				DiaQEngine.onQuestCompleted -= OnCompletedQuest; // this is to prevent that OnAcceptQuest is added more than once
				DiaQEngine.onQuestCompleted += OnCompletedQuest;
				completedEvents.Add(e);
			}
			else if (e.uniqueIdent.Equals("On Quest Rewarded"))
			{
				DiaQEngine.onQuestRewarded -= OnRewardedQuest; // this is to prevent that OnAcceptQuest is added more than once
				DiaQEngine.onQuestRewarded += OnRewardedQuest;
				rewardedEvents.Add(e);
			}
		}

		public override void CheckEvents()
		{
			enabled = acceptedEvents.Count > 0 || completedEvents.Count > 0 || rewardedEvents.Count > 0;
			acceptedEvents.TrimExcess();
			completedEvents.TrimExcess();
			rewardedEvents.TrimExcess();
		}

		// ============================================================================================================

		public void OnAcceptedQuest(DiaQuest questObj)
		{
			if (acceptedEvents.Count == 0) return;
			RunEvents(acceptedEvents,
				new plyEventArg("questName", questObj.name),
				new plyEventArg("questIdent", questObj.customIdent),
				new plyEventArg("questText", questObj.text),
				new plyEventArg("questObj", questObj)
			);
		}

		public void OnCompletedQuest(DiaQuest questObj)
		{
			if (completedEvents.Count == 0) return;
			RunEvents(completedEvents,
				new plyEventArg("questName", questObj.name),
				new plyEventArg("questIdent", questObj.customIdent),
				new plyEventArg("questText", questObj.text),
				new plyEventArg("questObj", questObj)
			);
		}

		public void OnRewardedQuest(DiaQuest questObj)
		{
			if (rewardedEvents.Count == 0) return;
			RunEvents(rewardedEvents,
				new plyEventArg("questName", questObj.name),
				new plyEventArg("questIdent", questObj.customIdent),
				new plyEventArg("questText", questObj.text),
				new plyEventArg("questObj", questObj)
			);
		}

		// ============================================================================================================
	}
}
