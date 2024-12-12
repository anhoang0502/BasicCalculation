using System;

namespace BasicCaculation.application
{
    public class Node
    {
        public Node next;
        public string data;
    }
    public class MyStack
    {
        Node _top;

        // Đẩy phần tử vào stack
        public void Push(string ele)
        {
            Node n = new Node();
            n.data = ele;
            n.next = _top;
            _top = n;
        }

        // Lấy phần tử từ stack và xóa 
        public Node Pop()
        {
            if (_top == null)
            {
                return null;
            }
            Node d = _top;
            _top = _top.next;
            return d;
        }

        // Lấy phần tử trên đỉnh stack nhưng không xóa 
        public object Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack rỗng!");
            return _top.data;
        }

        // Kiểm tra stack rỗng
        public bool IsEmpty()
        {
            if (_top == null)
            {
                return true;
            }
            return false;
        }
    }

}