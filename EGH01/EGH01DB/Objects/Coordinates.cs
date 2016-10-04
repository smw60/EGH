﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGH01DB.Objects
{
    class Coordinates
    {
        // широта:   0 - 90   - северная широта, -90 - 0 - южная широта 
        // долгота:  0 - 180  - восточная долгота, -180 - 0 - западная долгота 
        //comment

        public float latitude  {get; private set;}     // широта   12,1234567.. градусы 
        public float lngitude {get; private set;}     // долгота  123,123456.. градусы 
        public DMS Lat { get; private set;}
        public DMS Lng { get; private set;}
        
        public Coordinates()
        {
            this.latitude = this.lngitude = 0;
        }
        public Coordinates(float latitude, float lngitude)
        {
            this.latitude = validLat(latitude)? latitude: 0.0f;
            this.lngitude = validLng(lngitude)? lngitude: 0.0f;
            this.Lat  = new DMS(latitude);
            this.Lng  = new DMS(lngitude);
        }
        public Coordinates(int latd, int latm, float lats, int lngd, int lngm, float lngs)
        {
            this.Lat  = new DMS(latd, latm, lats);
            this.Lng =  new DMS(lngd, lngm, lngs);
            this.latitude = dms_to_d(latd, latm, lats);
            this.latitude = dms_to_d(lngd, lngm, lngs); 
        }
        public Coordinates(DMS lat, DMS lng)
        {
            this.Lat = lat;
            this.Lng = lng;
            this.latitude = dms_to_d(lat.d, lat.m, lat.s);
            this.latitude = dms_to_d(lng.d, lng.m, lng.s);
        }

        public struct DMS
        {
            public int d;     // градусы 
            public int m;     // минуты 
            public float s;   // секунды  

            public DMS(int d, int m, float s)
            {
                this.d = d;
                this.m = m;
                this.s = s;
            }
            public DMS(float itude)
            {
                this.d = this.m = 0;  this.s = 0.0f;
                d_to_dms(itude, ref this.d, ref this.m, ref this.s);  
            }
             
        }
        static public float dms_to_d(int d, int m, float s) { return (float)d + (float)m / 60.0f + s / 3600.0f;}
        static public void  d_to_dms( float itude, ref int  d, ref int m, ref float s) 
        {
            d = (int)itude;
            m = (int)((itude - (float)d) * 60.0f);
            s = (itude - (float)d - (float)m) * 3600.0f;  
        } 


        static bool validLat(float latitude) {return  latitude  >= -90.0f  && latitude  <= 90.0f;}
        static bool validLat(int d, int m, float s) { return validLat(dms_to_d(d,m,s));}
        static bool validLng(float lngitude) { return lngitude >= -180.0f && lngitude <= 180.0f;}
        static bool validLng(int d, int m, float s) { return validLng(dms_to_d(d, m, s));}
   
    }
}
