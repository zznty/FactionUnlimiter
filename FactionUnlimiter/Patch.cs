using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using Sandbox.Game.Gui;
using SpaceEngineers.Game.GUI;

namespace FactionUnlimiter
{
    [HarmonyPatch(typeof(MyGuiScreenCreateOrEditFactionSpace), nameof(MyGuiScreenCreateOrEditFactionSpace.RecreateControls))]
    public static class Patch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldc_I4_3)
                {
                    instruction.opcode = OpCodes.Ldc_I4;
                    instruction.operand = 512;
                }
                
                yield return instruction;
            }
        }
    }
    
    [HarmonyPatch(typeof(MyGuiScreenCreateOrEditFaction), "OnOkClick")]
    public static class Patch2
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var ins = instructions.ToList();
            for (var i = 0; i < ins.Count; i++)
            {
                var instruction = ins[i];
                
                if (instruction.opcode == OpCodes.Ldc_I4_3)
                {
                    instruction.opcode = OpCodes.Ldc_I4;
                    instruction.operand = 512;
                    ins[i + 1].opcode = OpCodes.Ble_S;
                }

                yield return instruction;
            }
        }
    }
}