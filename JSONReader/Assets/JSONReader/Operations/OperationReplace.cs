using SimpleJSON;

namespace JSONReader.Operations
{
    public class OperationReplace : IJSONNodeOperation
    {
        private readonly string _replaceKey;
        private readonly JSONNode _replaceWhere;
        private readonly JSONNode _replaceWith;
        private readonly JSONNode _replaceWhat;

        public OperationReplace(string replaceKey, JSONNode replaceWhere, JSONNode replaceWith, JSONNode replaceWhat)
        {
            _replaceKey = replaceKey;
            _replaceWhere = replaceWhere;
            _replaceWith = replaceWith;
            _replaceWhat = replaceWhat;
        }

        public void Execute()
        {
            if (_replaceWith.IsArray)
            {
                _replaceWhere.Remove(_replaceKey);
                _replaceWhere.Add(_replaceKey, _replaceWith);
            }
            else
            {
                if (_replaceWhere.IsArray)
                {
                    _replaceWhere.Remove(_replaceWhat);
                    _replaceWhere.Add(_replaceWith);
                }
                else
                {
                    _replaceWhere[_replaceKey] = _replaceWith;
                }
            }
        }
    }
}