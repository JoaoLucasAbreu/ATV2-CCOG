using SkiaSharp;

namespace Projeto {
	class Program {

		static void Main(string[] args){

			using (SKBitmap bitmap = SKBitmap.Decode("Exercicio 1.png")){
    			int largura = bitmap.Width;
				int altura = bitmap.Height;
                int count = 0;

				byte[] forma = new byte[]{
					0, 0, 0, 0,
					0, 255, 255, 0,
					0, 255, 255, 0,
					0, 0, 0, 0
				};
				unsafe{
					byte* entrada = (byte*)bitmap.GetPixels();
                    count = check(entrada, forma, largura, altura);
				}

				Console.WriteLine("Número de aparições: " + count);
			}
		}
		
        static unsafe int check(byte* entrada, byte[] forma, int altura, int largura){
            int contador=0;
            	for (int y = 0; y < altura - 3; y++){
					for (int x = 0; x < largura - 3; x++){
						bool achou_forma = true;
						    for (int py = 0; py < 4; py++){
								for (int px = 0; px < 4; px++){
									byte* pixel_atual = entrada + ((y + py) * largura + (x + px));
									byte valor_pixel = pixel_atual[0];
									if (valor_pixel != forma[py * 4 + px]){
										achou_forma = false;
										break;
									}
								}
								if (!achou_forma){
									break;
								}
							}
							if (achou_forma){
								contador++;
							}
						}
					}

            return contador;
        }
	}
}
