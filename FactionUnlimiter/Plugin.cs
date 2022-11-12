using System.Reflection;
using HarmonyLib;
using VRage.Plugins;

namespace FactionUnlimiter
{
    public class Plugin : IPlugin
    {
        public void Dispose()
        {
        }

        public void Init(object gameInstance)
        {
            new Harmony("FactionUnlimiter").PatchAll(Assembly.GetExecutingAssembly());
        }

        public void Update()
        {
        }
    }
}