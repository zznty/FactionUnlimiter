using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using Sandbox.Game.Gui;

namespace FactionUnlimiter
{
    [HarmonyPatch(typeof(MyGuiScreenCreateOrEditFaction), "OnOkClick")]
    public static class Patch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            return new CodeMatcher(instructions)
                .SearchForward(b => b.opcode == OpCodes.Ldc_I4_3)
                .Advance(1)
                .SetOpcodeAndAdvance(OpCodes.Ble_S)
                .InstructionEnumeration();
        }
    }
}