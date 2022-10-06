using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;

        private double MINIUM_COST_PER_KM;
        private int COST_PER_TIME;
        private double MINIMUM_FARE;

        public InvoiceGenerator(RideType  rideType)
        {
            this.rideType = rideType;
            this.rideRepository = rideRepository;
            try
            {
                if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;

                }
                else if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;

                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride");
            }
        }

        public double CalculateFare(double distance , int time)
        {
            double totaleFare = 0;
            try
            {
                totaleFare= distance * MINIUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch(CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Null Rides");
                }
                if(distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "invoice Distance");
                }
                if (time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "invoice Time");
                }
            }
            return Math.Max(totaleFare, MINIMUM_FARE);
        }

        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totaleFare = 0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totaleFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Null Rides");
                }
            }
            return new InvoiceSummary(rides.Length, totaleFare);
        }
    }
}
