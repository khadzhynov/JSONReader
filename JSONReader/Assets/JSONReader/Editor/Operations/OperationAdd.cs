using SimpleJSON;

namespace JSONReader.Operations
{
    public class OperationAdd : IJSONNodeOperation
    {
        private readonly JSONArray _array;

        public OperationAdd(JSONArray array)
        {
            _array = array;
        }

        public void Execute()
        {
            JSONNode lastNode;
            if (_array.Count > 0)
            {
                lastNode = _array[_array.Count - 1];
            }
            else
            {
                lastNode = JSONNull.CreateOrGet();
            }

            _array.Add(JSONNode.Copy(lastNode));
        }
    }
}