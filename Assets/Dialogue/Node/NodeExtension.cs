using UnityEngine;

namespace Dialogue
{
    public static class NodeExtension
    {
        public static T CreateRuntimeCopy<T>(this T original) where T : ScriptableObject
        {
            // 创建新实例并复制数据
            var copy = ScriptableObject.CreateInstance<T>();
            var jsonData = JsonUtility.ToJson(original);
            JsonUtility.FromJsonOverwrite(jsonData, copy);
            return copy;
        }
    }
}