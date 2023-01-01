using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `ThrowController`. Inherits from `AtomVariableInstancer&lt;ThrowControllerVariable, ThrowControllerPair, ThrowController, ThrowControllerEvent, ThrowControllerPairEvent, ThrowControllerThrowControllerFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/ThrowController Variable Instancer")]
    public class ThrowControllerVariableInstancer : AtomVariableInstancer<
        ThrowControllerVariable,
        ThrowControllerPair,
        ThrowController,
        ThrowControllerEvent,
        ThrowControllerPairEvent,
        ThrowControllerThrowControllerFunction>
    { }
}
