using System;
using System.Collections.Generic;
using System.Text;

namespace ShowApp.Entity
{
	public class Comment
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public DateTime Date { get; set; }
		public string UserId { get; set; }
		public int ShowId { get; set; }
		public Show Show { get; set; }

	}
}
