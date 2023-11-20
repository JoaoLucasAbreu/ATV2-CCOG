﻿using SkiaSharp;

namespace Projeto {
	class Program {

		readonly int[] quadrado = {
			0, 0, 0, 0,
			0, 255, 255, 0,
			0, 255, 255, 0,
			0, 0, 0, 0
		};
		static void Main(string[] args) {

			using (
				SKBitmap bitmap = SKBitmap.Decode("Exercicio 1.png")) {
				Console.WriteLine(bitmap.ColorType);

				unsafe {

					int largura = bitmap.Width;
					int altura = bitmap.Height;

					byte* ptr = (byte*)bitmap.GetPixels();
					int count  = 0;
					bool check;

					for (int y = 0; y < altura; y++)
					{
						for (int x = 0; x < largura; x++)
						{
							if (ptr[y * largura + x] == 255)
							{
								check = Check(ptr, x, y, largura, altura);
								if (check)
									Console.Write("oi");
							}
						}
					}

					Console.WriteLine("Número de aparições: " + count);
				
				}

			}
		}
		

		static unsafe bool Check(byte* img, int x, int y, int largura, int altura) {

			if (x - 1 < 0) 
				return false;
			
			if (y - 1 < 0) 
				return false;

			if (x + 3 > largura - 1)
				return false;

			if (y + 3 > altura - 1)
				return false;
			
			x--;
			y--;
			int[] quadrado2 = new int[16];

			if (img[y * largura + x] != 0)
				return false;
			else {
			}





			if ()







			for (int a = 0; a < 4; a++)
			{
				for (int l = 0; l < 4; l++) 
				{
					if (a == 0 || a == 3 || l == 0 || l == 3)
					{
						if (img[((y + a) * largura) + x + l] != 0) 
						{
							Console.WriteLine("oi");
							return false;
						}

					} else {
						if (img[(y + a) * largura + x + l] != 255) 
						{
							Console.WriteLine("tchau");
							return false;	
						}
					}
				}
			}
			
			return true;

		}

	}
}
