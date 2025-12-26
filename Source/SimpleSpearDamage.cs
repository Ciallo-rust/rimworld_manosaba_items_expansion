
using RimWorld;
using Verse;
using System.Linq;

namespace ManosabaItemsExpansion   //长矛造成伤害的逻辑，无接口
{
	public class SimpleSpearDamage : CompTargetEffect
	{
		public override void DoEffectOn(Pawn user, Thing target)
		{
			Pawn pawn = (Pawn)target;
			
			// 只要目标未死亡就必定执行
			if (!pawn.Dead)
			{
				BodyPartRecord corePart = pawn.def.race.body.corePart;
				


				if (corePart != null)
				{
					
					int amount = 2147483647; 
					pawn.TakeDamage(new DamageInfo(DamageDefOf.Cut, amount, 0f, -1f, user, corePart, parent.def));
				}
			}
		}
	}
}