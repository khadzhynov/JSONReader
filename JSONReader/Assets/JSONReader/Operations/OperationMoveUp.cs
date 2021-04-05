using SimpleJSON;

namespace JSONReader.Operations
{
    public class OperationMoveUp : IJSONNodeOperation
    {
        protected readonly JSONArray _array;
        protected readonly JSONNode _item;

        public OperationMoveUp(JSONArray array, JSONNode item)
        {
            _array = array;
            _item = item;
        }

        public virtual void Execute()
        {
            int index = _array.IndexOf(_item);
            if (index > 0)
            {
                _array.Swap(index, index - 1);
            }
        }
    }
}