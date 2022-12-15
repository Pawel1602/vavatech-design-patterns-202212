using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BuilderPattern.Models
{
    public class Person
	{
		public string Name { get; set; }
		public string Position { get; set; }
		public IList<string> Skills { get; set; }

		public Person()
		{
			Skills = Enumerable.Empty<string>().ToList();
		}

		public void AddSkill(string skill)
        {
			Thread.Sleep(TimeSpan.FromSeconds(1));

			Skills.Add(skill);

		}
	}
}
