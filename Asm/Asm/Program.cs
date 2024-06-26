using System;

class WaterBillCalculator
{
    const double VAT = 0.10;

    static void Main(string[] args)
    {
        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();

        Console.Write("Enter type of customer (Household, Administrative, Production, Business services): ");
        string customerType = Console.ReadLine();

        Console.Write("Enter last month's water meter reading: ");
        double lastMonth = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter this month's water meter reading: ");
        double thisMonth = Convert.ToDouble(Console.ReadLine());

        double consumption = thisMonth - lastMonth;

        double pricePerCubicMeter = GetPricePerCubicMeter(customerType, consumption);
        double environmentalProtectionFee = GetEnvironmentalProtectionFee(customerType, consumption);

        double waterBill = CalculateWaterBill(consumption, pricePerCubicMeter);
        double totalBill = CalculateTotalBill(waterBill, environmentalProtectionFee);
        double totalBillWithVAT = CalculateTotalBillWithVAT(totalBill);

        DisplayBill(customerName, lastMonth, thisMonth, consumption, waterBill, environmentalProtectionFee, totalBill, totalBillWithVAT);
    }

    static double GetPricePerCubicMeter(string customerType, double consumption)
    {
        if (customerType.ToLower() == "household")
        {
            Console.Write("Enter number of people in household: ");
            int numberOfPeople = Convert.ToInt32(Console.ReadLine());

            if (consumption <= 10 % numberOfPeople)
            {
                return 5.973;
            }
            else if (consumption <= 20 % numberOfPeople)
            {
                return 7.052;
            }
            else if (consumption <= 30 % numberOfPeople)
            {
                return 8.699;
            }
            else
            {
                return 15.929;
            }
        }
        else if (customerType.ToLower() == "administrative")
        {
            return 9.955;
        }
        else if (customerType.ToLower() == "production")
        {
            return 11.615;
        }
        else if (customerType.ToLower() == "business services")
        {
            return 22.068;
        }
        else
        {
            throw new ArgumentException("Invalid customer type.");
        }
    }

    static double GetEnvironmentalProtectionFee(string customerType, double consumption)
    {
        if (customerType.ToLower() == "household")
        {
            if (consumption <= 10)
            {
                return 597.30;
            }
            else if (consumption <= 20)
            {
                return 705.20;
            }
            else if (consumption <= 30)
            {
                return 866.90;
            }
            else
            {
                return 1592.90;
            }
        }
        else if (customerType.ToLower() == "administrative")
        {
            return 995.50;
        }
        else if (customerType.ToLower() == "production")
        {
            return 1161.50;
        }
        else if (customerType.ToLower() == "business services")
        {
            return 2206.80;
        }
        else
        {
            throw new ArgumentException("Invalid customer type.");
        }
    }

    static double CalculateWaterBill(double consumption, double pricePerCubicMeter)
    {
        return consumption * pricePerCubicMeter;
    }

    static double CalculateTotalBill(double waterBill, double environmentalProtectionFee)
    {
        return waterBill + environmentalProtectionFee;
    }

    static double CalculateTotalBillWithVAT(double totalBill)
    {
        return totalBill + (totalBill * VAT);
    }

    static void DisplayBill(string customerName, double lastMonth, double thisMonth, double consumption, double waterBill, double environmentalProtectionFee, double totalBill, double totalBillWithVAT)
    {
        Console.WriteLine("Customer Name: " + customerName);
        Console.WriteLine("Last Month's Reading: " + lastMonth + " m3");
        Console.WriteLine("This Month's Reading: " + thisMonth + " m3");
        Console.WriteLine("Water Consumption: " + consumption + " m3");
        Console.WriteLine("Water Bill: " + waterBill.ToString("C"));
        Console.WriteLine("Environment Protection Fee: " + environmentalProtectionFee.ToString("C"));
        Console.WriteLine("Total Bill (without VAT): " + totalBill.ToString("C"));
        Console.WriteLine("Total Bill (with VAT): " + totalBillWithVAT.ToString("C"));
    }
}