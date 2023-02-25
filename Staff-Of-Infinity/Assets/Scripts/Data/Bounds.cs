using System;

namespace Data
{
    [Serializable]
    public struct HorizontalBounds
    {
        public float left;
        public float right;
    }

    [Serializable]
    public struct VerticalBounds
    {
        public float down;
        public float up;
    }
}