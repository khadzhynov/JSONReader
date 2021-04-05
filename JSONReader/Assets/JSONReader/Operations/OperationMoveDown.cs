using SimpleJSON;

namespace JSONReader.Operations
{
    public class OperationMoveDown : OperationMoveUp
    {
        public OperationMoveDown(JSONArray array, JSONNode item) : base(array, item) { }

        public override void Execute()
        {
            int index = _array.IndexOf(_item);
            if (index + 1 < _array.Count)
            {
                _array.Swap(index, index + 1);
            }
        }
    }
}