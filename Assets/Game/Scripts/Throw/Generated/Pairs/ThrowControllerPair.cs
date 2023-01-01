using System;
using UnityEngine;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;ThrowController&gt;`. Inherits from `IPair&lt;ThrowController&gt;`.
    /// </summary>
    [Serializable]
    public struct ThrowControllerPair : IPair<ThrowController>
    {
        public ThrowController Item1 { get => _item1; set => _item1 = value; }
        public ThrowController Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private ThrowController _item1;
        [SerializeField]
        private ThrowController _item2;

        public void Deconstruct(out ThrowController item1, out ThrowController item2) { item1 = Item1; item2 = Item2; }
    }
}