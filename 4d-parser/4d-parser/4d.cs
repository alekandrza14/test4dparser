using System;
using System.Collections.Generic;
using System.IO;

namespace _4d_parser
{
	public class format_4d
	{

		public void save(string path)
		{
			for (int i = 0; i < this.objs.Count; i++)
			{
				this.output += this.objs[i].objstring;
				this.output += "\n+\n";
			}
			File.WriteAllText(path + ".4d", this.output);
		}


		public void loadobjs(string[] path)
		{
			for (int i = 0; i < path.Length; i++)
			{
				this.objs.Add(new objlayer(File.ReadAllText(path[i]), "1"));
			}
		}


		public void load(string path)
		{
			objs = new List<objlayer>();
			this.input = File.ReadAllText(path);
			for (int i =0;i<input.Length-1; i++)
			{

                if (input[i] != '+' && i < input.Length - 1)
                {
					i++;
                }
				if (input[i] == '+' && i < input.Length - 1)
				{

					this.i2++;
					i5.Add(i);
				}
			}
			Console.WriteLine(i2);
			objs.Add(new objlayer(input.Substring(0, i5[0]), "1"));
			for (int i = 0; i < i5.Count-1; i++)
			{
				Console.WriteLine(i5[i]);
				objs.Add(new objlayer(input.Substring(i5[i],i5[i+1]- i5[i]),"1"));
			}
			objs.Add(new objlayer(input.Substring(i5[i5.Count-1], input.Length- i5[i5.Count - 1]-1), "1"));
		}
		

		
		public List<objlayer> objs = new List<objlayer>();

		public List<int> i5 = new List<int>();
		public string output;

		
		public string input;

		
		public string nn;

		
		private int i2;
	}

	
	public class objlayer
	{
		
		public objlayer(string output, string color)
		{
			this.objstring = output;
			this.color = color;
		}

		
		public string color;

		
		public string objstring;
	}
	
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       