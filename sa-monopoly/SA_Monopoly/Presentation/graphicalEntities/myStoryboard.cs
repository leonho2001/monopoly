using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace SA_Monopoly.Presentation
{
    class myStoryboard
    {
        // don vi la milisecond
        const double LOOP_DURATION = 25;

        Storyboard storyboard;

        int currentSquare = 0;
        int prevSquare = 0;
        int noSqrToStep = 0;

        DispatcherTimer timer;
        long steps = 0;
        long NoSteps = 0;

        bool started;
        bool animating;
        double seekPoint;
        double endPoint;

        public bool Animating
        {
            get { return animating; }
        }

        public int CurrentSquare
        {
            get { return currentSquare; }
        }

        public myStoryboard(Storyboard sto)
        {
            this.storyboard = sto;

            this.storyboard.RepeatBehavior = RepeatBehavior.Forever;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(LOOP_DURATION);
            timer.Tick += new EventHandler(timer_tick);

            started = false;
            animating = false;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            
            //steps++;
            //if (steps % 8 == 0) currentSquare++;
            
            //double seekPoint = ((steps * LOOP_DURATION) + (prevSquare * 8 * LOOP_DURATION) + (currentSquare / 10) * 8 * LOOP_DURATION);
            seekPoint += LOOP_DURATION;
            //double seekPoint = (steps * LOOP_DURATION + (prevSquare + currentSquare/10) * 8 * LOOP_DURATION);

            if (seekPoint % 200 == 0)
            {
                currentSquare = (int)(seekPoint / 200) - currentSquare / 10;
                
            }
                
            if (seekPoint > 8800) 
            {

                endPoint -= seekPoint;
                seekPoint = 0;
                NoSteps -= steps;
                steps = 0;
                currentSquare = 0;
                prevSquare = 0;
                //timer.Stop();
                storyboard.Stop();
                storyboard.Begin();
                storyboard.Pause();
            }


            storyboard.Seek(TimeSpan.FromMilliseconds(seekPoint));

            /*if (steps >= NoSteps)
            {
                timer.Stop();
                steps = 0; 
                NoSteps = 0;

                noSqrToStep = 0;
                animating = false;
            }*/
            if (seekPoint >= endPoint)
            {
                timer.Stop();
                steps = 0;
                NoSteps = 0;

                noSqrToStep = 0;
                animating = false;
            }
        }

        public void moveThisAmountOfSquares(int noSqrToStep)
        {
            if (noSqrToStep >= 2 && noSqrToStep <= 39)
            {
                this.noSqrToStep = noSqrToStep;


                NoSteps = (noSqrToStep) * 8;

                prevSquare = currentSquare;

                if (started == false)
                {
                    storyboard.Begin();
                    storyboard.Pause();
                    started = true;
                }
                seekPoint = (currentSquare + currentSquare / 10) * 200;
                int totalStep = currentSquare + noSqrToStep;

                endPoint = (totalStep + totalStep / 10) * 200;
                timer.Start();

                animating = true;

            }
        }

    }
}
