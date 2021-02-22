using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace laba4
{
    class Storage<ClassName> 
    {
        private class Node
        {
            private ClassName data;             //хранит объект
            private Node next;                  //ссылки на следующую и следующую ячейку
            private Node previous;
            public Node(ClassName data)         //конструктор ячейки(помещает объект)
            {
                next = null;
                previous = null;
                this.data = data;
            }

            //геттеры и сеттеры
            public ClassName Data
            {
                get
                {
                    return data;
                }

                set
                {
                    data = value;
                }
            }
            public Node Next
            {
                get
                {
                    return next;
                }

                set
                {
                    next = value;
                }
            }
            public Node Previous
            {
                get
                {
                    return previous;
                }

                set
                {
                    previous = value;
                }
            }
        }

        private Node head;
        private Node current;
        private Node tail;
        private int size;

        public Storage()//конструктор без парам
        {
            head = current = tail = null;
            size = 0;
        }

        public void AddTail(ClassName newObject)//установка посл элемента
        {
            Node newNode = new Node(newObject);
            if (tail == null)
                current = head = tail = newNode;
            else
            {
                newNode.Previous = tail;
                current = tail = newNode;
                newNode.Previous.Next = tail;
            }
            size++;
        }

        public void DeleteHead()//удаление первого
        {
            if (head == null)
            {
                Console.WriteLine("Delete: first is null");
                return;
            }
            else if (size == 1)
            {
                head = tail = current = null;
                size--;
                return;
            }
            else
            {
                current = head = head.Next;
                head.Previous = null;
                size--;
                return;
            }
        }
        public void DeleteTail()//удаление послед
        {
            if (tail == null)
            {
                Console.WriteLine("Delete: last is null");
                return;
            }
            else if (size == 1)
            {
                head = tail = current = null;
                size--;
                return;
            }
            else
            {
                current = tail = tail.Previous;
                tail.Next = null;
                size--;
                return;
            }
        }
        public void DeleteCurrent()//удаление текущего
        {
            if (current == null)
                return;
            else if (current == head)
                DeleteHead();
            else if (current == tail)
                DeleteTail();
            else
            {
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
                current = current.Next;
                size--;
                return;
            }
        }

        public void deleteAll()//удаление всех эл
        {
            current = head;
            while (!eol())
                DeleteHead();
        }
        public void Next()//к следующему
        {
            if (current == null)
                return;
            else if (current.Next != null)
            {
                current = current.Next;
                return;
            }

            else
                current = null;
            return;
        }
        public void ToHead()//к первому
        {
            if (head == null)
                return;
            else
            {
                current = head;
                return;
            }
        }
        public ClassName obj()
        {
            return current.Data;
        }
        public int getSize()//вернуть размер хранильища
        {
            return size;
        }
        public bool eol()//не нулл
        {
            return current == null;
        }


    }
}
