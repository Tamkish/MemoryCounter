using System;

namespace MemoryCounter
{
	class SpojovySeznam<T> where T : IComparable
	{
		Node start, end;
		public int Count { get; private set; }


		class Node
		{
			public T data;
			public Node next, prev;

			#region operators
			public static bool operator <(Node node, T input)
			{
				return node.data.CompareTo(input) < 0;
			}
			public static bool operator >(Node node, T input)
			{
				return node.data.CompareTo(input) > 0;
			}
			public static bool operator <=(Node node, T input)
			{
				return node.data.CompareTo(input) <= 0;
			}
			public static bool operator >=(Node node, T input)
			{
				return node.data.CompareTo(input) >= 0;
			}
			public static bool operator ==(Node node, T input)
			{
				return node.data.CompareTo(input) == 0;
			}
			public static bool operator !=(Node node, T input)
			{
				return node.data.CompareTo(input) != 0;
			}


			#endregion
		}

		public void AddStart(T input)
		{
			Node newnode = new Node();
			newnode.data = input;
			if (start != null)
			{
				start.prev = newnode;
				newnode.next = start;
			}
			else
			{
				end = newnode;
			}
			start = newnode;

			Count++;
		}
		public void AddEnd(T input)
		{
			Node newnode = new Node();
			newnode.data = input;
			if (end != null)
			{
				end.next = newnode;
				newnode.prev = end;

			}
			else
			{
				start = newnode;
			}
			end = newnode;

			Count++;
		}
		public void Add(T input)
		{
			Node smaller = start;
			for (int i = 0; i < Count; i++)
			{
				if (smaller.next == null)
				{
					AddEnd(input);
					return;
				}

				if (smaller.next <= input)
				{
					smaller = smaller.next;
				}
				else
				{
					Node newnode = new Node();
					newnode.data = input;
					smaller.next.prev = newnode;
					newnode.next = smaller.next;
					smaller.next = newnode;
					newnode.prev = smaller;
					return;
				}
			}
		}

		//		1) přidejte metodu, která vrátí index zadaného prvku
		public int IndexOf(T input)
		{
			Node current = start;
			for (int i = 0; i < Count; i++)
			{
				if (current == input)
				{
					return i;
				}

				if (current.next != null)
				{
					current = current.next;
				}
				
			}
			return -1;
		}

		//2) přidejte metodu pro zjištění počtu výskytů prvku T
		//(seznam může být nesetříděný a prvky se stejnou hodnotou se mohou opakovat)

		//3) přidejte metodu, která obrátí pořadí prvků


		//4) přidejte mtodu pro odstranění všech prvků větších než vstupní parametr

		//5) upravte třídu Spojový seznam tak, aby implementovala rozhraní IList<T>
		//neboli umožňovala přístup k prvkům pomocí indexu zapsaného v[]

		//6) přidejte metodu nebo operátor + pro spojení dvou seřazených seznamů tak,
		//aby výsledek byl opět seřazený seznam

		public void VypsatPrvky()
		{
			Node uzel = start;
			for (int i = 0; i < Count; i++)
			{
				Console.WriteLine(uzel.data);
				uzel = uzel.next;
			}
		}


	}


	class Program
	{
		static void Main(string[] args)
		{
			SpojovySeznam<int> seznam = new SpojovySeznam<int>();
			//mel jsem problem s domaci verzi takze jsem ted nemel Add a z nejakeho duvodu mi ted nefunguje.
			seznam.AddStart(1);
			seznam.AddEnd(10);
			seznam.AddEnd(11);
			seznam.Add(4);
			seznam.Add(6);
			seznam.Add(7);
			seznam.Add(2);
			seznam.Add(6);
			seznam.Add(9);
			seznam.Add(0);

			seznam.VypsatPrvky();
		}
	}
}
