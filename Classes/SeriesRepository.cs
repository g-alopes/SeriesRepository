using System;
using System.Collections.Generic;
using GL.Series.Interfaces;

namespace GL.Series
{
	public class SeriesRepository : IRepository<Serie>
	{
        private List<Serie> seriesList = new List<Serie>();
		public void Update(int id, Serie s)
		{
			seriesList[id] = s;
		}

		public void Delete(int id)
		{
			if(VerifyIndex(id)) {
				seriesList[id].Delete();
				string title = seriesList[id].returnTitle();
				Console.WriteLine("Series {0} successfully deleted.", title);
			}

			else {
				NonExistentIndex();
			}
		}

		public void Insert(Serie s)
		{
			seriesList.Add(s);
		}

		public List<Serie> List()
		{
			return seriesList;
		}

		public int NextId()
		{
			return seriesList.Count;
		}

		public void NonExistentIndex() {
			Console.WriteLine("You are trying to access a non-existent series.");
		}

		// Verify if user is trying to access an existent index
		public bool VerifyIndex(int id) {
			return (seriesList.Count > id);
		}

		public void VerifySerie(int id)
		{
			if(VerifyIndex(id)) {
				Console.WriteLine(seriesList[id]);
			}

			else {
				NonExistentIndex();
			}
		}
	}
}