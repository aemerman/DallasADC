﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using NationalInstruments.VisaNS;

namespace Nevis14
{
    class SCPI
    {
        private MessageBasedSession scpitalker;
        public string SCPIhostName = "192.168.1.1";
        public const double ampMax = 5.0;

        public SCPI()
        {
            scpitalker = new MessageBasedSession("TCPIP::169.254.2.20::5025::SOCKET");
        }

        public SCPI(MessageBasedSession talker)
        {
            scpitalker = talker;
        }

        public bool ApplySin(double freq, double amp, double offset)
        {
            try
            {
                string s = "APPL:SIN " + freq + ", " + amp + ", " + offset;
                WriteToSCPI(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool ClearStatus()
        {
            try
            {
                WriteToSCPI("*CLS");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool OutputOn()
        {
            try
            {
                WriteToSCPI("OUTP ON");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool OutputOff()
        {
            try
            {
                WriteToSCPI("OUTP OFF");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public string ReadFromSCPI()
        {
            string responseData = scpitalker.ReadString();
            Console.WriteLine(responseData);
            return responseData;
        }

        public void WriteToSCPI(string s)
        {
            //Byte[] data = System.Text.Encoding.ASCII.GetBytes(s);
            Console.WriteLine(s);
            scpitalker.Write(s);
            if (s.IndexOf('?') >= 0)
                ReadFromSCPI();
            Byte[] lf = {(Byte)'\n'};
            scpitalker.Write(lf);

            if (s.IndexOf("?") >=0 )
                ReadFromSCPI();
        }
    }
}