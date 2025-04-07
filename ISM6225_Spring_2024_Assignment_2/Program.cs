using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));
            
            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Edge case: array is null or empty
                if (nums == null || nums.Length == 0)
                {
                    return new List<int>();
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    int index = Math.Abs(nums[i]) - 1;
                    // Covert indexes into negative numbers
                    if (nums[index] > 0 )
                    {
                        nums[index] = -nums[index];
                    }
                }

                // Find missing numbers
                List<int> missingNumbers = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                     missingNumbers.Add(i + 1);
                    }
                }

                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                List<int> evens = new List<int>();
                List<int> odds = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    //no significant edges to consider that are not already handled
                    // check if the number is even or odd
                    if (nums[i] % 2 == 0)
                    {
                        evens.Add(nums[i]);
                    }
                    else
                    {
                        odds.Add(nums[i]);
                    }
                }
                // Append lists in the order of evens first and then odds
                evens.AddRange(odds);
                return  evens.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                var map = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];

                    if (map.ContainsKey(complement))
            {
                return new int[] { map[complement], i };
            }

            map[nums[i]] = i;
        }
                return new int[0]; // Placeholder
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Edge cases= input not sorted; negative numbers will be considered, as they could contribute to the highest possible product
                Array.Sort(nums); // Sort ascending by default

                int n = nums.Length;

                // Option 1: product of 3 largest
                int max1 = nums[n - 1] * nums[n - 2] * nums[n - 3];

                // Option 2: product of 2 smallest and largest, considering possible negatives
                int max2 = nums[0] * nums[1] * nums[n - 1];
                return Math.Max(max1, max2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Edge case: negative number
                if (decimalNumber < 0)
                    throw new ArgumentException("Provide a positive number");
                // Edge case: zero
                if (decimalNumber == 0)
                    return "0";
                string binary = "";

                while (decimalNumber > 0)
                {
                    int remainder = decimalNumber % 2;
                    binary = remainder + binary;
                    decimalNumber /= 2;
                }

                return binary;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Edge case: negative number
                if (x < 0)
                    return false;
                string original = x.ToString();
                char[] reversedArray = original.ToCharArray();
                Array.Reverse(reversedArray);
                string reversed = new string(reversedArray);
                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Edge case: negative number
                if (n < 0)
                    throw new ArgumentException("n must be non-negative");

                if (n == 0)
                    return 0;
                if (n == 1)
                    return 1;
                int prev1 = 0;
                int prev2 = 1;
                int current = 0;
                for (int i = 2; i <= n; i++)
                {
                    current = prev1 + prev2;
                    prev1 = prev2;
                    prev2 = current;
                }
                return current;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


