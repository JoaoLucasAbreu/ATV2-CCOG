using SkiaSharp;

namespace Projeto {
	class Program {
		static void Main(string[] args) {
			using (SKBitmap bitmapEntrada = SKBitmap.Decode("Exercicio 2.png"),
				bitmapSaida = new SKBitmap(new SKImageInfo(bitmapEntrada.Width, bitmapEntrada.Height, SKColorType.Gray8))) {

				unsafe {
					byte* entrada = (byte*)bitmapEntrada.GetPixels();
					byte* saida = (byte*)bitmapSaida.GetPixels();
					int largura = bitmapEntrada.Width;
					int altura = bitmapEntrada.Height;
					long pixelsTotais = bitmapEntrada.Width * bitmapEntrada.Height;

					unsafe{
						for (int e = 0, s = 0; s < pixelsTotais; e += 4, s++) {
							saida = ChangeBrightness(entrada[e + 2] , entrada[e + 1] , entrada[e]) ;
						}
					}							
				}

				unsafe{
					using (FileStream stream = new FileStream("Exercicio out 2.png", FileMode.OpenOrCreate, FileAccess.Write)) {
						bitmapSaida.Encode(stream, SKEncodedImageFormat.Png, 100);
					}
				}
			}	
		}

		static unsafe byte* ChangeBrightness(byte r, byte g, byte b) {
			unsafe{
				double R = (double)r / 255;
				double G = (double)g / 255;
				double B = (double)b / 255;

				double max = Math.Max(Math.Max(R, G), B);
				double V = max;

				double v =255.0 * V;
				int color = 0;

				if (v < 0){
					color = (byte)(saida * (1 + v));
				}else{
					saida = (byte)(saida + ((255 - saida) * v));
				}	

				if(saida < 0){
					saida = 0;
				}
				if(saida > 255){
					saida = 255;
				}	
			}							
		}
	}
}