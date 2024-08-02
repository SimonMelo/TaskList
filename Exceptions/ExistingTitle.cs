[Serializable]

    public class ExistingTitleException : Exception
    {
        public ExistingTitleException() : base() {  }
        public ExistingTitleException(string message) : base(message) {  }
        public ExistingTitleException(string message, Exception inner) : base(message, inner) {  }
    }