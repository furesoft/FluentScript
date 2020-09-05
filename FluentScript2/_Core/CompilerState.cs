using System.Collections.Generic;

namespace ComLib.Lang.Core
{
    public class ParseStackType
    {
        public const string Array = "array";
        public const string Map = "map";
        public const string FunctionCall = "function_call";
        public const string Block = "block";
        public const string Function = "function";
        public const string Loop = "loop";
    }

    public class ParseStack
    {
        private List<string> _stack;
        private int _currentIndex = -1;

        /// <summary>
        /// Initialize.
        /// </summary>
        public ParseStack()
        {
            _stack = new List<string>();
        }

        /// <summary>
        /// Number of items on the stack.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _stack.Count;
        }

        /// <summary>
        /// Gets the last item placed on the compilation stack.
        /// </summary>
        /// <returns></returns>
        public string Current()
        {
            return _stack[_currentIndex];
        }

        /// <summary>
        /// Push the type being currently parsed on the stack.
        /// </summary>
        /// <param name="astType"></param>
        public void Push(string astType)
        {
            _stack.Add(astType);
            _currentIndex = _currentIndex + 1;
        }

        /// <summary>
        /// Pop the last type on the stack.
        /// </summary>
        public void Pop()
        {
            _stack.RemoveAt(_currentIndex);
            _currentIndex = _currentIndex - 1;
        }
    }

    /// <summary>
    /// Used as a stack to keep track of nested elements such as functions, blocks, arrays.
    /// </summary>
    public class ParseStackManager
    {
        private ParseStack _genericStack;
        private Dictionary<string, ParseStack> _namedStack;

        public ParseStackManager()
        {
            _genericStack = new ParseStack();
            _namedStack = new Dictionary<string, ParseStack>();
            _namedStack.Add("maps", new ParseStack());
            _namedStack.Add("arrays", new ParseStack());
            _namedStack.Add("loops", new ParseStack());
            _namedStack.Add("function_calls", new ParseStack());
            _namedStack.Add("function_declares", new ParseStack());
        }

        /// <summary>
        /// Gets the last item placed on the compilation stack.
        /// </summary>
        /// <returns></returns>
        public string Current()
        {
            return _genericStack.Current();
        }

        /// <summary>
        /// Current elements on the stack.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _genericStack.Count();
        }

        /// <summary>
        /// Current elements on the stack.
        /// </summary>
        /// <returns></returns>
        public int CountOf(string namedStack)
        {
            if (!_namedStack.ContainsKey(namedStack))
                return 0;
            return _namedStack[namedStack].Count();
        }

        /// <summary>
        /// Push the type being currently parsed on the stack.
        /// </summary>
        /// <param name="astType"></param>
        public void Push(string astType)
        {
            _genericStack.Push(astType);
        }

        /// <summary>
        /// Pop the last type on the stack.
        /// </summary>
        public void Pop()
        {
            _genericStack.Pop();
        }

        /// <summary>
        /// Push the type being currently parsed on the stack.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="astType"></param>
        public void PushNamed(string name, string astType)
        {
            _genericStack.Push(astType);
            _namedStack[name].Push(astType);
        }

        /// <summary>
        /// Push the type being currently parsed on the stack.
        /// </summary>
        /// <param name="astType"></param>
        public void PopNamed(string name, string astType)
        {
            _genericStack.Pop();
            _namedStack[name].Pop();
        }

        /// <summary>
        /// Push an array on the stack
        /// </summary>
        public void PushArray()
        {
            PushNamed("arrays", ParseStackType.Array);
        }

        /// <summary>
        /// Pop an array off the stack
        /// </summary>
        public void PopArray()
        {
            PopNamed("arrays", ParseStackType.Array);
        }

        /// <summary>
        /// Push a map onto current stack
        /// </summary>
        public void PushMap()
        {
            PushNamed("maps", ParseStackType.Map);
        }

        /// <summary>
        /// Pop a map off the stack
        /// </summary>
        public void PopMap()
        {
            PopNamed("maps", ParseStackType.Map);
        }

        /// <summary>
        /// Push a function call onto current stack
        /// </summary>
        public void PushFunctionCall()
        {
            PushNamed("function_calls", ParseStackType.FunctionCall);
        }

        /// <summary>
        /// Pop a function call off current stack
        /// </summary>
        public void PopFunctionCall()
        {
            PopNamed("function_calls", ParseStackType.FunctionCall);
        }

        /// <summary>
        /// Push an array on the stack
        /// </summary>
        public void PushLoop()
        {
            PushNamed("loops", ParseStackType.Loop);
        }

        /// <summary>
        /// Push an array on the stack
        /// </summary>
        public void PopLoop()
        {
            PopNamed("loops", ParseStackType.Loop);
        }
    }
}