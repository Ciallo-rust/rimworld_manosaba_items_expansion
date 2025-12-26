
using RimWorld;
using Verse;
using Verse.AI;

namespace ManosabaThings  //借鉴心灵冲击枪的目标验证逻辑，禁止对Boss使用长矛
{
	public class SimpleSpear_Target : Verb_CastTargetEffect
	{
		public override void OnGUI(LocalTargetInfo target)
		{
			if (CanHitTarget(target) && verbProps.targetParams.CanTarget(target.ToTargetInfo(caster.Map)))
			{
				Pawn pawn = target.Pawn;
				if (pawn != null)
				{
					bool flag = target.Pawn.kindDef.isBoss;
					
					if (flag)
					{
						GenUI.DrawMouseAttachment(TexCommand.CannotShoot);
						if (!string.IsNullOrEmpty(verbProps.invalidTargetPawn))
						{
							Widgets.MouseAttachedLabel(verbProps.invalidTargetPawn.CapitalizeFirst(), 0f, -20f);
						}
					}				
				}
				else
				{
					base.OnGUI(target);
				}
			}
			else
			{
				GenUI.DrawMouseAttachment(TexCommand.CannotShoot);
			}
		}

		public override bool ValidateTarget(LocalTargetInfo target, bool showMessages = true)
		{
			Pawn pawn = target.Pawn;
			if (pawn != null)
			{
				if (target.Pawn.kindDef.isBoss)
				{
					return false;
				}
			}
			return base.ValidateTarget(target, showMessages);
		}
	}
}