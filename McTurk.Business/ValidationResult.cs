namespace McTurk.Business
{
    internal class ValidationResult
    {
        private List<string> _errors =new List<string>();
        public bool HasErrors => _errors.Any();
        public IEnumerable<string> Errors => _errors;
        //{
        //    get 
        //    { 
        //    return _errors; 
        //    } 
        //}

        public string ErrorString
        {
            get 
            {
                return string.Join(Environment.NewLine, _errors);
            }
        }

        public void AddError(string error)
        {
            _errors.Add(error);
        }
    }
}
