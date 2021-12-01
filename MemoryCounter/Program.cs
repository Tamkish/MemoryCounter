using System;

namespace MemoryCounter
{
	class SpojovySeznam<T> where T:IComparable
	{
		Uzel zacatek, konec;
		public int Count { get; private set; }


		class Uzel
		{
			public T data;
			public Uzel dalsi, predchozi;
		}

		public void VlozNaZacatek(T vstup)
		{
			Uzel novy = new Uzel();
			novy.data = vstup;
			if (zacatek != null)
			{ 
				zacatek.predchozi = novy;
			novy.dalsi = zacatek;
			}
			zacatek = novy;

			Count++;
		}
		public void VlozNaKonec(T vstup)
		{
			Uzel novy = new Uzel();
			novy.data = vstup;
			if (konec != null)
			{
				konec.dalsi = novy;
			novy.predchozi = konec;

			}
			konec = novy;

			Count++;
		}
		public void VlozSerazene(T vstup)
		{
			Uzel mensiNezVstup = zacatek;
			for (int i = 0; i < Count; i++)
			{
				if (vstup.CompareTo(mensiNezVstup.data) <= 0) //pokud vstup je mensi nez momentalni index
				{
					//VlozNaPozici(i, vstup) //TODO =========================================================
					//return
				}
				else
				{

				}
			}
		}

		public void VypsatPrvky()
		{
			Uzel uzel = zacatek;
			for (int i = 0; i < Count; i++)
			{
				Console.WriteLine(uzel.data);
				uzel = uzel.dalsi;
			}
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
