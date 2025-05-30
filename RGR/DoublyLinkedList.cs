namespace MyWinFormsApp
{
    public class DoublyLinkedList
    {
        private class Node
        {
            public int Value;
            public Node? Prev;
            public Node? Next;

            public Node(int value)
            {
                Value = value;
            }
        }

        private Node? head;
        private Node? tail;

        public void Create()
        {
            head = null;
            tail = null;
        }

        public void Initialize(int[] values)
        {
            Create();
            foreach (var val in values)
                Append(val);
        }

        public void Deinitialize()
        {
            head = null;
            tail = null;
        }

        public void Destroy()
        {
            head = null;
            tail = null;
        }

        public void Append(int value)
        {
            var newNode = new Node(value);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        public void InsertBefore(int target, int newValue)
        {
            Node? current = head;
            while (current != null)
            {
                if (current.Value == target)
                {
                    var newNode = new Node(newValue);
                    newNode.Next = current;
                    newNode.Prev = current.Prev;

                    if (current.Prev != null)
                        current.Prev.Next = newNode;
                    else
                        head = newNode;

                    current.Prev = newNode;
                    return;
                }
                current = current.Next;
            }
        }

        public void Remove(int value)
        {
            Node? current = head;
            while (current != null)
            {
                if (current.Value == value)
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                    else
                        tail = current.Prev;

                    return;
                }
                current = current.Next;
            }
        }

        public int? GetFirst()
        {
            return head?.Value;
        }

        public int? GetLast()
        {
            return tail?.Value;
        }

        public string PrintForward()
        {
            List<string> values = new();
            Node? current = head;
            while (current != null)
            {
                values.Add(current.Value.ToString());
                current = current.Next;
            }
            return string.Join(" -> ", values);
        }
    }
}
