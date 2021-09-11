using System;

namespace GL.Series
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();

			while (userOption != "X")
			{
				switch (userOption)
				{
					case "1":
						ListSeries();
						break;
					case "2":
						InsertSerie();
						break;
					case "3":
						UpdateSerie();
						break;
					case "4":
						DeleteSerie();
						break;
					case "5":
						ViewSerie();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						Console.WriteLine("You typed an incorret option.");
						break;
				}

				userOption = GetUserOption();
			}

			Console.WriteLine("GL Series thanks you for your visit.");
			Console.ReadLine();
        }

        private static void DeleteSerie()
		{
			Console.Write("Enter the series id:");
			int idSerie = int.Parse(Console.ReadLine());

			repository.Delete(idSerie);
		}

        private static void ViewSerie()
		{
			Console.Write("Enter the series id:");
			int idSerie = int.Parse(Console.ReadLine());

			repository.VerifySerie(idSerie);
		}

        private static void UpdateSerie()
		{
			Console.Write("Enter the series id:");
			int idSerie = int.Parse(Console.ReadLine());

			if(repository.VerifyIndex(idSerie)) {

				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
				foreach (int i in Enum.GetValues(typeof(Genre))) {
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
				}

				Console.Write("Enter the genre from the options above:");
				int genre = int.Parse(Console.ReadLine());

				Console.Write("Enter the Series Title:");
				string title = Console.ReadLine();

				Console.Write("Enter the Start Year of the Series:");
				int year = int.Parse(Console.ReadLine());

				Console.Write("Enter the Series Description:");
				string description = Console.ReadLine();

				Serie updateSerie = new Serie(id: idSerie,
											genre: (Genre)genre,
											title: title,
											year: year,
											description: description);

				repository.Update(idSerie, updateSerie);
			}

			else {
				repository.NonExistentIndex();
			}
		}
        private static void ListSeries()
		{
			Console.WriteLine("List series");

			var list = repository.List();

			if (list.Count == 0)
			{
				Console.WriteLine("No registered series.");
				return;
			}

			foreach (var serie in list)
			{
                var deleted = serie.returnDeleted();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (deleted ? "*Deleted Series*" : ""));
			}
		}

        private static void InsertSerie()
		{
			Console.WriteLine("Insert new series");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genre))) {
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}

			Console.Write("Enter the genre from the options above:");
			int genre = int.Parse(Console.ReadLine());

			Console.Write("Enter the Series Title:");
			string title = Console.ReadLine();

			Console.Write("Enter the Start Year of the Series:");
			int year = int.Parse(Console.ReadLine());

			Console.Write("Enter the Series Description:");
			string description = Console.ReadLine();

			Serie newSerie = new Serie(id: repository.NextId(),
										genre: (Genre)genre,
										title: title,
										year: year,
										description: description);

			repository.Insert(newSerie);
		}

        private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("GL Series - The best series in one place!");
			Console.WriteLine("Enter the desired option:");

			Console.WriteLine("1- List series");
			Console.WriteLine("2- Insert new series");
			Console.WriteLine("3- Update series");
			Console.WriteLine("4- Delete series");
			Console.WriteLine("5- View series");
			Console.WriteLine("C- Clean Console");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}
    }
}
