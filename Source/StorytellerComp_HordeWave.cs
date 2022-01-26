using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Zombiefied
{
    internal class StorytellerComp_HordeWave : StorytellerComp
	{
		protected StorytellerCompProperties_HordeWave Props
		{
			get
			{
				return (StorytellerCompProperties_HordeWave)this.props;
			}
		}
		private bool EventReady
		{
			get
			{
				return (Find.TickManager.TicksGame / 1000 - 30) % (60 * 1) == 0;
			}
		}
		public override IEnumerable<FiringIncident> MakeIntervalIncidents(IIncidentTarget target)
		{
			if (!EventReady) yield break;
			Log.Message("Creating event!");
			IncidentParms parms = this.GenerateParms(IncidentCategoryDefOf.ThreatBig, target);
			yield return new FiringIncident(IncidentDef.Named("ZombieHorde"), this, parms);
		}
    }
}
