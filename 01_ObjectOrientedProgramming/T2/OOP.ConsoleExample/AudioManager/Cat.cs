using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioManager
{
    public class Cat : Animal
    {
        public override void animalSound()
        {
            AudioFileReader audioFile = new AudioFileReader("Resources/Cat.wav");
            WaveOutEvent waveOutEvent = new WaveOutEvent();

            waveOutEvent.Init(audioFile);
            waveOutEvent.Play();
            while (waveOutEvent.PlaybackState == PlaybackState.Playing)
            {
                System.Threading.Thread.Sleep(500);
            }
            waveOutEvent.Dispose();
            audioFile.Dispose();

        }
    }
}
