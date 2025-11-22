using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using LabApi.Loader.Features.Plugins;
using PlayerStatsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecontainmentDamageIncreaseDisabled
{
    public class PluginMain : Plugin
    {
        public override string Name => "DecontainmentDamageIncreaseDisabled";

        public override string Description => "-";

        public override string Author => "Creydra";

        public override Version Version => new Version("1.0.0");

        public override Version RequiredApiVersion => new Version("1.1.4.1");

        public static void OnPlayerHurting(PlayerHurtingEventArgs ev)
        {
            if(ev.DamageHandler is UniversalDamageHandler handler && handler.TranslationId == DeathTranslations.Decontamination.Id)
            {
                ((StandardDamageHandler)ev.DamageHandler).Damage = ev.Player.MaxHealth * 0.1f;
            }
        }

        public override void Disable()
        {
            PlayerEvents.Hurting -= OnPlayerHurting;
        }

        public override void Enable()
        {
            PlayerEvents.Hurting += OnPlayerHurting;
        }
    }
}
