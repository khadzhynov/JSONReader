namespace SimpleJSON
{
    public partial class JSONNode
    {
        public static JSONNode Copy(JSONNode node)
        {
            JSONNode result = null;
            if (node.IsBoolean)
            {
                result = new JSONBool(false);
            }
            if (node.IsNumber)
            {
                result = new JSONNumber(0);
            }
            if (node.IsString)
            {
                result = new JSONString(string.Empty);
            }
            if (node.IsNull)
            {
                result = JSONNull.CreateOrGet();
            }
            if (node.IsArray)
            {
                result = new JSONArray();
                foreach (var arrayItem in node)
                {
                    result.Add(Copy(arrayItem));
                }
            }
            if (node.IsObject)
            {
                result = new JSONObject();
                foreach (var field in node)
                {
                    result.Add(field.Key, Copy(field));
                }
            }
            return result;
        }
    }

    public partial class JSONArray : JSONNode
    {
        public int IndexOf(JSONNode item)
        {
            if (m_List != null && m_List.Count > 0)
            {
                return m_List.FindIndex(x => ReferenceEquals(item, x));
            }
            return -1;
        }

        public bool Swap(JSONNode item1, JSONNode item2)
        {
            if (m_List.Contains(item1) && m_List.Contains(item2))
            {
                int index1 = m_List.IndexOf(item1);
                int index2 = m_List.IndexOf(item2);
                return Swap(index1, index2);
            }
            return false;
        }

        public bool Swap(int index1, int index2)
        {
            if (index1 >= 0 && index1 < m_List.Count && index2 >= 0 && index2 < m_List.Count)
            {
                JSONNode temp = m_List[index1];
                m_List[index1] = m_List[index2];
                m_List[index2] = temp;
                return true;
            }
            return false;
        }
    }
}