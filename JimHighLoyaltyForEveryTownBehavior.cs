using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.CampaignSystem.SceneInformationPopupTypes;
using TaleWorlds.Core;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace JimHighLoyaltyForEveryTown
{
    internal class JimHighLoyaltyForEveryTownBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.DailyTickSettlementEvent.AddNonSerializedListener(this, DailyTickSettlementFunction);
        }

        private void DailyTickSettlementFunction(Settlement settlement)
        {
            // Your code for doing something involving a settlement.
            try
            {
                if (settlement.IsTown || settlement.IsCastle)
                {
                    settlement.Town.Loyalty += 100;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                InformationManager.DisplayMessage(new InformationMessage(ex.Message));
            }
        }

        public override void SyncData(IDataStore dataStore)
        {
        }
    }
}