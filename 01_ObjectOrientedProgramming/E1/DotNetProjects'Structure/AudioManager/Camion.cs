using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioManager
{
    public class Camion : Vehiculo
    {
        public override void VehiculoSonido()
        {
            base.VehiculoSonido();
            AudioFileReader audioFile = new AudioFileReader("Resoures/camion.wav");
            WaveOutEvent waveOutEvent = new WaveOutEvent();

            waveOutEvent.Init(audioFile);
            waveOutEvent.Play();
            while (waveOutEvent.PlaybackState == PlaybackState.Playing)
            {
                System.Threading.Thread.Sleep(1000);
            }

            waveOutEvent.Dispose();
            audioFile.Dispose();
        }

        public override string ToString()
        {
            return "Camions";
        }
    }
}
