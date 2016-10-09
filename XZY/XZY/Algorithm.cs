using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
//using System.Threading.Tasks;

namespace XZY
{
    public delegate void DrawUpdateRequest(ResultP P);
    public class Algorithm
    {
        //Algorithm constant define
        //Max Peddle Value,convert from two byte
        const int MaxPeddle = 65535;  
        //Peddle value update rate: 50ms
        const int UpdateRate = 50;
        //Quick press define: precent of chage within 100ms = 40%
        const int PrecentQuickFlashValue = 40;
        //Flash Interval 100毫秒闪一次
        const int FlashInterval = 100;
        //Precentage of SixLED
        const int SixLEDPrecentage = 15;
        //Precentage of TwelveLED
        const int TwelveLEDPrecentage = 45;
        //Precentage of EighteenLED
        const int EighteenLEDPrecentage = 80;


        //Control Prarm

        private ResultP P = new ResultP();


        //Internal value
        private int StepValue = 0;
        private int LastPeddleValue = 0;
        private Timer tmFlash = new Timer();
        private int FlashStatus = 0;  // Mark if in flash mode
        private int isAllLightON = 0;
        private int SixLEDStep = 0;
        private int TwelveLEDStep = 0;
        private int EighteenLEDPStep = 0;


        //Used to draw result
        public event DrawUpdateRequest Draw;

        public Algorithm()
        {
            //Generate Flash step value
            StepValue = MaxPeddle * UpdateRate * PrecentQuickFlashValue / 100 / 100;
            if (StepValue < 1) StepValue = 1;

            //Generate LED Step
            SixLEDStep = MaxPeddle * SixLEDPrecentage / 100;
            TwelveLEDStep = MaxPeddle * TwelveLEDPrecentage / 100;
            EighteenLEDPStep = MaxPeddle * EighteenLEDPrecentage / 100;

            //Setup Flash timer
            tmFlash.Interval = FlashInterval;
            tmFlash.Tick += tmFlash_Tick;
            
        }



        //Algorithm Begin
        public void Update(int PeddleValue)
        {
            if (PeddleValue == 0)
            {
                if (FlashStatus == 1)
                    StopLightFlash();
                LightOff();
            }
            else if (FlashStatus == 1)
            {
                // Do nothing, stay in this state
            }
            else if (PeddleValue - LastPeddleValue > StepValue)
            {
                LightFlash();
            }
            else if (PeddleValue <= SixLEDStep)
            {
                LEDSixON();
            }
            else if (PeddleValue > SixLEDStep && PeddleValue <= TwelveLEDStep)
            {
                LEDTwelveON();
            }
            else if (PeddleValue > TwelveLEDStep && PeddleValue<= EighteenLEDPStep)
            {
                LEDEighteenON();
            }
            else if (PeddleValue > EighteenLEDPStep)
            {
                LightFlash();
            }
            LastPeddleValue = PeddleValue;
                
        }


        //6 Actions below
        private void LightFlash()
        {
            FlashStatus = 1;
            tmFlash.Start();
        }
        private void StopLightFlash()
        {
            tmFlash.Stop();
            FlashStatus = 0;
            P.P0 = 0;
            P.P1 = 0;
            P.P2 = 0;
            Draw(P);
        }
        private void LightOff()
        {
            isAllLightON = 0;
            P.P0 = 0;
            P.P1 = 0;
            P.P2 = 0;
            Draw(P);
        }
        private void LEDSixON()
        {
            P.P0 = 1;
            P.P1 = 0;
            P.P2 = 0;
            Draw(P);
        }
        private void LEDTwelveON()
        {
            P.P0 = 1;
            P.P1 = 1;
            P.P2 = 0;
            Draw(P);
        }
        private void LEDEighteenON()
        {
            P.P0 = 1;
            P.P1 = 1;
            P.P2 = 1;
            Draw(P);
        }

        //Flash tick
        void tmFlash_Tick(object sender, EventArgs e)
        {
            if (FlashStatus == 0)
            {
                StopLightFlash();
            }
            else if (FlashStatus == 1)
            {
                if (isAllLightON == 0)
                {
                    P.P0 = 1;
                    P.P1 = 1;
                    P.P2 = 1;
                    isAllLightON = 1;
                }
                else if (isAllLightON == 1)
                {
                    P.P0 = 0;
                    P.P1 = 0;
                    P.P2 = 0;
                    isAllLightON = 0;
                }
                tmFlash.Start();
            }
            Draw(P);
        }

    }


    public class ResultP
    {
        public int P0 = 0;
        public int P1 = 0;
        public int P2 = 0;
    }
}
