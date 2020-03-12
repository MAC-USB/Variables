<<<<<<< HEAD
﻿using System.IO;
using System;

public class FileUpdate 
{
    public static string ruta = @"C:\Users\Carlos Sivira\Desktop\chance.txt";
    //public static string ruta = @"/tmp/chance";

    public static void update()
	{
		string textoBase = "1";

		reset(ruta);

		using(StreamWriter entrada = new StreamWriter(ruta,false))
		{
			entrada.Write (textoBase);
			entrada.Close ();
		}
	}

    static void reset(string ruta) 
	{
		string[] lineas = File.ReadAllLines (ruta);

		for (int i = 0; i < lineas.Length; i++) 
		{
			lineas [i] = string.Empty;
		}

		File.WriteAllLines (ruta,lineas);
	}
}
=======
﻿using System.IO;
using System;

public class FileUpdate 
{
    public static string ruta = @"C:\Users\Carlos Sivira\Desktop\chance.txt";
    //public static string ruta = @"/tmp/chance";
	//ublic static string ruta = @"C:\Users\chance.txt";

    public static void update()
	{
		string textoBase = "1";

		reset(ruta);

		using(StreamWriter entrada = new StreamWriter(ruta,false))
		{
			entrada.Write (textoBase);
			entrada.Close ();
		}
	}

    static void reset(string ruta) 
	{
		string[] lineas = File.ReadAllLines (ruta);

		for (int i = 0; i < lineas.Length; i++) 
		{
			lineas [i] = string.Empty;
		}

		File.WriteAllLines (ruta,lineas);
	}
}
>>>>>>> a3caea27c4076713d3e30d082d3612e11cd7d9d6
