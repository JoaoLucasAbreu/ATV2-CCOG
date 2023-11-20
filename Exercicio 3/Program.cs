using SkiaSharp;

namespace Projeto {
	class Program {
		static void Main(string[] args) {
			// ****************************************************************************
			// Esse código é só um começo! :)
			// ****************************************************************************


        // Criar uma lista com 200 elementos, todos inicializados com o valor 0
        List<int> minhaLista = new List<int>(new int[256]);

		using (SKBitmap bitmap = SKBitmap.Decode("Exercicio 3.png")) {
		 	Console.WriteLine(bitmap.ColorType);

			unsafe {
				
				int largura = bitmap.Width;
				int altura = bitmap.Height;

				byte* ptr = (byte*)bitmap.GetPixels();

				for (int y = 0; y < altura; y++)
				{
					for (int x = 0; x < largura; x++)
					{
						minhaLista[ptr[y * largura + x]]++;
					}
				}


				for (int i = 0; i < minhaLista.Count; i++) 
				{
					Console.WriteLine($"Quantidade de pixels com valor {i}: {minhaLista[i]}");
				}
			}
		 }
		}
	}
}
