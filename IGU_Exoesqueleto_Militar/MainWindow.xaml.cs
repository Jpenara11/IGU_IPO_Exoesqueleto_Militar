using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Speech.Recognition;

namespace IPO_IGU
{
    public partial class MainWindow : Window
    {

        private static Timer aTimer;
        private static Timer aTimer2;
        private static Timer aTimer3;
        String hora, minutos;
        System.Speech.Recognition.SpeechRecognitionEngine voz = new System.Speech.Recognition.SpeechRecognitionEngine();
        int linea = 0;
        int contador = 0;
        System.Media.SoundPlayer logout = new System.Media.SoundPlayer(Properties.Resources.tonoLlamada);

        public MainWindow()
        {
            InitializeComponent();

            aTimer = new System.Timers.Timer();
            aTimer.Interval = 500;

            aTimer.Elapsed += OnTimedEvent;

            aTimer.AutoReset = true;

            aTimer.Enabled = true;

            aTimer2 = new System.Timers.Timer();
            aTimer2.Interval = 2000;

            aTimer2.Elapsed += OnTimedEvent2;

            aTimer2.AutoReset = true;

            aTimer2.Enabled = true;

            aTimer3 = new System.Timers.Timer();
            aTimer3.Interval = 60000;

            aTimer3.Elapsed += OnTimedEvent3;

            aTimer3.AutoReset = true;

            aTimer3.Enabled = true;

            voz.SetInputToDefaultAudioDevice();
            voz.LoadGrammar(new System.Speech.Recognition.DictationGrammar());
            voz.RecognizeAsync(System.Speech.Recognition.RecognizeMode.Multiple);

        }

        void OnTimedEvent3(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (contador == 0)
            {
                
                logout.Play();
                contador++;

                this.Dispatcher.Invoke(() =>
                {
                    Teniente.Visibility = Visibility.Visible;
                });

                
            }
        }

        void voz_Speech(object sender, System.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit word in e.Result.Words)
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (word.Text.Equals("normal"))
                    {
                        Modo2.Content = "Normal";
                        Soldado.Visibility = Visibility.Hidden;
                        Mirilla.Visibility = Visibility.Hidden;
                        Facial.Visibility = Visibility.Hidden;
                        Reconocimiento.Visibility = Visibility.Hidden;
                        Descripcion.Visibility = Visibility.Hidden;
                        Radar.Visibility = Visibility.Hidden;
                        Distancia.Visibility = Visibility.Hidden;
                        Metros.Visibility = Visibility.Hidden;
                        Probabilidad.Visibility = Visibility.Hidden;
                        Porcentaje.Visibility = Visibility.Hidden;
                        Mapa.Visibility = Visibility.Hidden;
                        Flecha.Visibility = Visibility.Hidden;
                        Vision.Visibility = Visibility.Hidden;
                        Termometro.Visibility = Visibility.Hidden;
                        Constantes.Visibility = Visibility.Hidden;
                        TenienteRechazada.Visibility = Visibility.Hidden;
                        TenienteCogida.Visibility = Visibility.Hidden;
                    }
                    else if (word.Text.Equals("infrarrojos"))
                    {
                        Modo2.Content = "Infrarrojos";
                        Vision.Visibility = Visibility.Visible;
                        Termometro.Visibility = Visibility.Visible;
                        Radar.Visibility = Visibility.Visible;
                        Distancia.Visibility = Visibility.Visible;
                        Metros.Visibility = Visibility.Visible;
                        Probabilidad.Visibility = Visibility.Visible;
                        Porcentaje.Visibility = Visibility.Visible;
                        Mapa.Visibility = Visibility.Hidden;
                        Flecha.Visibility = Visibility.Hidden;
                        Mirilla.Visibility = Visibility.Visible;
                        Constantes.Visibility = Visibility.Hidden;
                        Soldado.Visibility = Visibility.Hidden;
                        Facial.Visibility = Visibility.Hidden;
                        Reconocimiento.Visibility = Visibility.Hidden;
                        Descripcion.Visibility = Visibility.Hidden;
                    }
                    else if (word.Text.Equals("defensa"))
                    {
                        Modo2.Content = "Defensa";


                        Soldado.Visibility = Visibility.Visible;
                        Mirilla.Visibility = Visibility.Visible;
                        Radar.Visibility = Visibility.Visible;
                        Distancia.Visibility = Visibility.Visible;
                        Metros.Visibility = Visibility.Visible;
                        Probabilidad.Visibility = Visibility.Visible;
                        Porcentaje.Visibility = Visibility.Visible;
                        Mapa.Visibility = Visibility.Hidden;
                        Flecha.Visibility = Visibility.Hidden;
                        Vision.Visibility = Visibility.Hidden;
                        Termometro.Visibility = Visibility.Hidden;
                        Constantes.Visibility = Visibility.Hidden;

                    }
                    else if (word.Text.Equals("navegacion") || word.Text.Equals("navegación"))
                    {
                        Modo2.Content = "Navegación y GPS";
                        Mapa.Visibility = Visibility.Visible;
                        Flecha.Visibility = Visibility.Visible;
                        Soldado.Visibility = Visibility.Hidden;
                        Mirilla.Visibility = Visibility.Hidden;
                        Facial.Visibility = Visibility.Hidden;
                        Reconocimiento.Visibility = Visibility.Hidden;
                        Descripcion.Visibility = Visibility.Hidden;
                        Radar.Visibility = Visibility.Hidden;
                        Distancia.Visibility = Visibility.Hidden;
                        Metros.Visibility = Visibility.Hidden;
                        Probabilidad.Visibility = Visibility.Hidden;
                        Porcentaje.Visibility = Visibility.Hidden;
                        Vision.Visibility = Visibility.Hidden;
                        Termometro.Visibility = Visibility.Hidden;
                        Constantes.Visibility = Visibility.Hidden;

                    }
                    else if (word.Text.Equals("reconocimiento"))
                    {
                        Modo2.Content = "Reconocimiento Facial";
                        Soldado.Visibility = Visibility.Visible;
                        Facial.Visibility = Visibility.Visible;
                        Reconocimiento.Visibility = Visibility.Visible;
                        Descripcion.Visibility = Visibility.Visible;
                        Mapa.Visibility = Visibility.Hidden;
                        Flecha.Visibility = Visibility.Hidden;
                        Vision.Visibility = Visibility.Hidden;
                        Termometro.Visibility = Visibility.Hidden;
                        Constantes.Visibility = Visibility.Hidden;
                    }
                    else if (word.Text.Equals("constantes"))
                    {
                        Modo2.Content = "Constantes Vitales";
                        Soldado.Visibility = Visibility.Hidden;
                        Mirilla.Visibility = Visibility.Hidden;
                        Facial.Visibility = Visibility.Hidden;
                        Reconocimiento.Visibility = Visibility.Hidden;
                        Descripcion.Visibility = Visibility.Hidden;
                        Radar.Visibility = Visibility.Hidden;
                        Distancia.Visibility = Visibility.Hidden;
                        Metros.Visibility = Visibility.Hidden;
                        Probabilidad.Visibility = Visibility.Hidden;
                        Porcentaje.Visibility = Visibility.Hidden;
                        Mapa.Visibility = Visibility.Hidden;
                        Flecha.Visibility = Visibility.Hidden;
                        Constantes.Visibility = Visibility.Visible;
                        Vision.Visibility = Visibility.Hidden;
                        Termometro.Visibility = Visibility.Hidden;
                    }
                    else if (word.Text.Equals("coger"))
                    {
                        TenienteCogida.Visibility = Visibility.Visible;
                        Teniente.Visibility = Visibility.Hidden;
                        logout.Stop();
                    }
                    else if (word.Text.Equals("rechazar"))
                    {
                        TenienteRechazada.Visibility = Visibility.Visible;
                        Teniente.Visibility = Visibility.Hidden;
                        logout.Stop(); 
                    }
                });
            }
        }

        void OnTimedEvent2(Object source, System.Timers.ElapsedEventArgs e)
        {
            Random r = new Random();
            int aleatorio = r.Next(-1, 5);

            this.Dispatcher.Invoke(() =>
            {
      
                switch (aleatorio)
                {
                    case 0:
                        Cobertura1.Fill = Brushes.White;
                        Cobertura2.Fill = Brushes.White;
                        Cobertura3.Fill = Brushes.White;
                        Cobertura4.Fill = Brushes.White;
                        Objetivo.Visibility = Visibility.Visible;
                        Objetivo1.Visibility = Visibility.Hidden;
                        Objetivo2.Visibility = Visibility.Hidden;
                        Objetivo3.Visibility = Visibility.Hidden;
                        Objetivo4.Visibility = Visibility.Hidden;
                        break;

                    case 1:
                        Cobertura1.Fill = Brushes.Black;
                        Cobertura2.Fill = Brushes.White;
                        Cobertura3.Fill = Brushes.White;
                        Cobertura4.Fill = Brushes.White;
                        Objetivo.Visibility = Visibility.Hidden;
                        Objetivo1.Visibility = Visibility.Visible;
                        Objetivo2.Visibility = Visibility.Hidden;
                        Objetivo3.Visibility = Visibility.Hidden;
                        Objetivo4.Visibility = Visibility.Hidden;
                        break;

                    case 2:
                        Cobertura1.Fill = Brushes.Black;
                        Cobertura2.Fill = Brushes.Black;
                        Cobertura3.Fill = Brushes.White;
                        Cobertura4.Fill = Brushes.White;
                        Objetivo.Visibility = Visibility.Hidden;
                        Objetivo1.Visibility = Visibility.Hidden;
                        Objetivo2.Visibility = Visibility.Visible;
                        Objetivo3.Visibility = Visibility.Hidden;
                        Objetivo4.Visibility = Visibility.Hidden;
                        break;

                    case 3:
                        Cobertura1.Fill = Brushes.Black;
                        Cobertura2.Fill = Brushes.Black;
                        Cobertura3.Fill = Brushes.Black;
                        Cobertura4.Fill = Brushes.White;
                        Objetivo.Visibility = Visibility.Hidden;
                        Objetivo1.Visibility = Visibility.Hidden;
                        Objetivo2.Visibility = Visibility.Hidden;
                        Objetivo3.Visibility = Visibility.Visible;
                        Objetivo4.Visibility = Visibility.Hidden;
                        break;

                    case 4:
                        Cobertura1.Fill = Brushes.Black;
                        Cobertura2.Fill = Brushes.Black;
                        Cobertura3.Fill = Brushes.Black;
                        Cobertura4.Fill = Brushes.Black;
                        Objetivo.Visibility = Visibility.Hidden;
                        Objetivo1.Visibility = Visibility.Hidden;
                        Objetivo2.Visibility = Visibility.Hidden;
                        Objetivo3.Visibility = Visibility.Hidden;
                        Objetivo4.Visibility = Visibility.Visible;
                        break;
                }
            });
        }

            void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
            {
                hora = Convert.ToString(e.SignalTime.Hour);
                minutos = Convert.ToString(e.SignalTime.Minute);
            

                switch (minutos)
                {
                    case "0":
                        minutos = "00";
                        break;
                    case "1":
                        minutos = "01";
                        break;
                    case "2":
                        minutos = "02";
                        break;
                    case "3":
                        minutos = "03";
                        break;
                    case "4":
                        minutos = "04";
                        break;
                    case "5":
                        minutos = "05";
                        break;
                    case "6":
                        minutos = "06";
                        break;
                    case "7":
                        minutos = "07";
                        break;
                    case "8":
                        minutos = "08";
                        break;
                    case "9":
                        minutos = "09";
                        break;
                }

                hora = String.Concat(hora,":");
                hora = String.Concat(hora, minutos);
            

                this.Dispatcher.Invoke(() =>
                {
                    Hora.Content = hora;

                    if (linea > 7) linea = 0;

                    switch (linea)
                    {
                        case 0: LineaRadar.Visibility = Visibility.Visible;
                                LineaRadar1.Visibility = Visibility.Hidden;
                                LineaRadar2.Visibility = Visibility.Hidden;
                                LineaRadar3.Visibility = Visibility.Hidden;
                                LineaRadar4.Visibility = Visibility.Hidden;
                                LineaRadar5.Visibility = Visibility.Hidden;
                                LineaRadar6.Visibility = Visibility.Hidden;
                                LineaRadar7.Visibility = Visibility.Hidden;
                                break;
                        case 1:
                            LineaRadar.Visibility = Visibility.Hidden;
                            LineaRadar1.Visibility = Visibility.Visible;
                            LineaRadar2.Visibility = Visibility.Hidden;
                            LineaRadar3.Visibility = Visibility.Hidden;
                            LineaRadar4.Visibility = Visibility.Hidden;
                            LineaRadar5.Visibility = Visibility.Hidden;
                            LineaRadar6.Visibility = Visibility.Hidden;
                            LineaRadar7.Visibility = Visibility.Hidden;
                            break;
                        case 2:
                            LineaRadar.Visibility = Visibility.Hidden;
                            LineaRadar1.Visibility = Visibility.Hidden;
                            LineaRadar2.Visibility = Visibility.Visible;
                            LineaRadar3.Visibility = Visibility.Hidden;
                            LineaRadar4.Visibility = Visibility.Hidden;
                            LineaRadar5.Visibility = Visibility.Hidden;
                            LineaRadar6.Visibility = Visibility.Hidden;
                            LineaRadar7.Visibility = Visibility.Hidden;
                            break;
                        case 3:
                            LineaRadar.Visibility = Visibility.Hidden;
                            LineaRadar1.Visibility = Visibility.Hidden;
                            LineaRadar2.Visibility = Visibility.Hidden;
                            LineaRadar3.Visibility = Visibility.Visible;
                            LineaRadar4.Visibility = Visibility.Hidden;
                            LineaRadar5.Visibility = Visibility.Hidden;
                            LineaRadar6.Visibility = Visibility.Hidden;
                            LineaRadar7.Visibility = Visibility.Hidden;
                            break;
                        case 4:
                            LineaRadar.Visibility = Visibility.Hidden;
                            LineaRadar1.Visibility = Visibility.Hidden;
                            LineaRadar2.Visibility = Visibility.Hidden;
                            LineaRadar3.Visibility = Visibility.Hidden;
                            LineaRadar4.Visibility = Visibility.Visible;
                            LineaRadar5.Visibility = Visibility.Hidden;
                            LineaRadar6.Visibility = Visibility.Hidden;
                            LineaRadar7.Visibility = Visibility.Hidden;
                            break;
                        case 5:
                            LineaRadar.Visibility = Visibility.Hidden;
                            LineaRadar1.Visibility = Visibility.Hidden;
                            LineaRadar2.Visibility = Visibility.Hidden;
                            LineaRadar3.Visibility = Visibility.Hidden;
                            LineaRadar4.Visibility = Visibility.Hidden;
                            LineaRadar5.Visibility = Visibility.Visible;
                            LineaRadar6.Visibility = Visibility.Hidden;
                            LineaRadar7.Visibility = Visibility.Hidden;
                            break;
                        case 6:
                            LineaRadar.Visibility = Visibility.Hidden;
                            LineaRadar1.Visibility = Visibility.Hidden;
                            LineaRadar2.Visibility = Visibility.Hidden;
                            LineaRadar3.Visibility = Visibility.Hidden;
                            LineaRadar4.Visibility = Visibility.Hidden;
                            LineaRadar5.Visibility = Visibility.Hidden;
                            LineaRadar6.Visibility = Visibility.Visible;
                            LineaRadar7.Visibility = Visibility.Hidden;
                            break;
                        case 7:
                            LineaRadar.Visibility = Visibility.Hidden;
                            LineaRadar1.Visibility = Visibility.Hidden;
                            LineaRadar2.Visibility = Visibility.Hidden;
                            LineaRadar3.Visibility = Visibility.Hidden;
                            LineaRadar4.Visibility = Visibility.Hidden;
                            LineaRadar5.Visibility = Visibility.Hidden;
                            LineaRadar6.Visibility = Visibility.Hidden;
                            LineaRadar7.Visibility = Visibility.Visible;
                            break;
                    }

                    linea++;
                });
            }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Altavoz.Visibility = Visibility.Hidden;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            int distanciaActual, distanciaNueva, probabilidadActual, probabilidadNueva;

            distanciaActual = Convert.ToInt32(Distancia.Content);
            probabilidadActual = Convert.ToInt32(Probabilidad.Content);

            if (e.Key == Key.Up)
            {
                distanciaNueva = distanciaActual + 1;
                probabilidadNueva = probabilidadActual + 2;

                Probabilidad.Content = Convert.ToString(probabilidadNueva);
                Distancia.Content = Convert.ToString(distanciaNueva);
            }

            if (e.Key == Key.Down)
            {
                distanciaNueva = distanciaActual - 1;
                probabilidadNueva = probabilidadActual - 2;

                if (distanciaNueva <= 0)
                {
                    Distancia.Content = Convert.ToString(0);
                    Probabilidad.Content = Convert.ToString(0);
                }

                else
                {
                    Distancia.Content = Convert.ToString(distanciaNueva);
                    Probabilidad.Content = Convert.ToString(probabilidadNueva);
                }
            }

            if (e.Key == Key.Enter)
            {
                Altavoz.Visibility = Visibility.Visible;
                
                voz.SpeechRecognized += new EventHandler<System.Speech.Recognition.SpeechRecognizedEventArgs>(voz_Speech);
            }
        }
    }
}
