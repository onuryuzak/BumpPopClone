using UnityEngine;
using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable of type `ThrowController`. Inherits from `AtomVariable&lt;ThrowController, ThrowControllerPair, ThrowControllerEvent, ThrowControllerPairEvent, ThrowControllerThrowControllerFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/ThrowController", fileName = "ThrowControllerVariable")]
    public sealed class ThrowControllerVariable : AtomVariable<ThrowController, ThrowControllerPair, ThrowControllerEvent, ThrowControllerPairEvent, ThrowControllerThrowControllerFunction>
    {
        protected override bool ValueEquals(ThrowController other)
        {
            return this == other;
        }
    }
}
