using System;

namespace MemoryCounter
{
	class SpojovySeznam<T>
	{
		Uzel zacatek, konec;
		public int Count { get; private set; }
		
		/*public T this[int index]
		{
			
		}*/


		class Uzel
		{
			public T data;
			public Uzel dalsi, predchozi;
		}

		public void VlozNaZacatek(T vstup)
		{
			Uzel novy = new Uzel();
			novy.data = vstup;
			novy.dalsi = zacatek;
			zacatek = novy;

			Count++;
		}
		public void VlozNaKonec(T vstup)
		{
			Uzel novy = new Uzel();
			novy.data = vstup;
			novy.predchozi = konec;
			konec = novy;

			Count++;
		}

		public void VypsatPrvky()
		{
			Uzel docasny = zacatek;
			if (zacatek == null) return;
			
			while (docasny.dalsi != null)
			{
				Console.WriteLine(docasny.data);
				docasny = docasny.dalsi;
			}
				Console.WriteLine(docasny.data);
			
			
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			SpojovySeznam<int> seznam = new SpojovySeznam<int>();
			seznam.VlozNaZacatek(1);
			seznam.VlozNaKonec(10);
			seznam.VlozNaKonec(11);

			seznam.VypsatPrvky();
		}
	}
}
