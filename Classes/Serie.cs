using System;

namespace GL.Series
{
    public class Serie : BaseEntity
    {
        // Attributes
		private Genre Genre { get; set; }
		private string Title { get; set; }
		private string Description { get; set; }
		private int Year { get; set; }
        private bool Deleted {get; set;}

        // Methods
		public Serie(int id, Genre genre, string title, string description, int year) {
			this.Id = id;
			this.Genre = genre;
			this.Title = title;
			this.Description = description;
			this.Year = year;
            this.Deleted = false;
		}

        public override string ToString() {
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string text = "";
            text += "Genre: " + this.Genre + Environment.NewLine;
            text += "Title: " + this.Title + Environment.NewLine;
            text += "Description: " + this.Description + Environment.NewLine;
            text += "Start Year: " + this.Year + Environment.NewLine;
            text += "Deleted: " + this.Deleted;
			return text;
		}

        public string returnTitle() {
			return this.Title;
		}

		public int returnStartYear() {
			return this.Year;
		}

		public string returnDescription() {
			return this.Description;
		}

		public int returnId() {
			return this.Id;
		}

        public bool returnDeleted() {
			return this.Deleted;
		}

        public void Delete() {
            this.Deleted = true;
        }
    }
}