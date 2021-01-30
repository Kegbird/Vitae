using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/New Dialogue")]
    public class Dialogue : ScriptableObject
    {
        [SerializeField]
        private string[] lines;
        [SerializeField]
        public float speed;

        public string GetLineByIndex(int index)
        {
            if (index == lines.Length)
                return null;
            return lines[index];
        }

        public int GetLength()
        {
            return lines.Length - 1;
        }
    }
}
