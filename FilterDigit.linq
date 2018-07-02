<Query Kind="Program" />


//00:00:42.3779610
//00:00:42.3617923

//00:01:19.0098054
//00:01:13.6226405

//00:03:14.9319225
//00:03:03.5896580

void Main()
{
	//const int length = 1000;
	const int length = int.MaxValue / 2000;
	int[] a = new int[length];
	Random rnd = new Random();
	for (int i = 0; i < length; i++)
	{
		a[i] = rnd.Next(-length/2 , length/2);
	}
	
	
	Stopwatch sw = Stopwatch.StartNew();
	FilterDigit(7, a);
    Console.WriteLine(sw.Elapsed);
	sw.Stop();
	
	Stopwatch sw2 = Stopwatch.StartNew();
	FilterDigit2(7, a);
    Console.WriteLine(sw2.Elapsed);
	sw2.Stop();

}

int[] FilterDigit(int digit, params int[] a)
{
	int[] temp = new int[] { };
            for (int i = 0; i < a.Length; i++)
            {
                if (ContainsDigit(a[i], digit))
                {                    
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = a[i];
                }

            }

            return temp;
}


        bool ContainsDigit(int number, int digit)
        {
            int[] digits = ExctractDigits(number);
            for (int j = 0; j < digits.Length; j++)
            {
                if (digits[j] == digit)
                {
                    return true;
                }
            }

            return false;
        }

        int[] ExctractDigits(int number)
        {
            int[] digits = new int[] { };
			if (number < 0)
            {
                number *= -1;
            }
            while (number > 0)
            {
                Array.Resize(ref digits, digits.Length + 1);
                digits[digits.Length - 1] = number % 10;
                number /= 10;
            }

            return digits;
        }
	
int[] FilterDigit2(int digit, params int[] a)
{
	int[] temp = new int[] { };
    for (int i = 0; i < a.Length; i++)
    {
		string digits = a[i].ToString();
		string dig = digit.ToString();
        if (digits.Contains(dig))
        {                    
            Array.Resize(ref temp, temp.Length + 1);
            temp[temp.Length - 1] = a[i];
        }

    }

    return temp;
}

