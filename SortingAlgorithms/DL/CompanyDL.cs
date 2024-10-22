﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SortingAlgorithms.BL;
namespace SortingAlgorithms.DL
{
    public class CompanyDL
    {
        private static List<Company> companies = new List<Company>();
        private static Random random = new Random();
        public static List<Company> Companies { get => companies; set => companies = value; }
        public static string parse(string line, int index)
        {
            int count = 0;
            string word = "";
            bool flag = true;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '"')
                {
                    flag = !flag;
                }
                else if (line[i] == ',' && flag)
                {
                    count++;
                }
                else if (count == index)
                {
                    word += line[i];
                }
            }
            return word;
        }
        public static List<Company> loadData(string fileName)
        {
            Companies.Clear();
            StreamReader sr = new StreamReader(fileName);
            string line;
            int index;
            int noOfEmployees;
            int foundedYear;
            string id;
            string name;
            string website;
            string country;
            string description;
            string industry;
            line = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                index = int.Parse(parse(line, 0));
                id = parse(line, 1);
                name = parse(line, 2);
                website = parse(line, 3);
                country = parse(line, 4);
                description = parse(line, 5);
                foundedYear = int.Parse(parse(line, 6));
                industry = parse(line, 7);
                noOfEmployees = int.Parse(parse(line, 8));
                Company company = new Company(index, id, name, website, country, description, foundedYear, industry, noOfEmployees);
                addToList(company);
            }
            return Companies;
        }
        public static void addToList(Company company)
        {
            Companies.Add(company);
        }
        public static void saveData(List<Company> vec)
        {
            StreamWriter sw = new StreamWriter("SortedData.csv", false);

            foreach (var x in vec)
            {
                sw.WriteLine(x.Index.ToString() + "," + x.Id + "," + x.Name + "," + x.Website + "," + x.Country + "," + x.Description + "," + x.FoundedYear.ToString() + "," + x.Industry + "," + x.NoOfEmployees.ToString());
            }
            sw.Flush();
            sw.Close();
        }
        public static List<Company> bubbleSortWithEmployees(List<Company> arr, int n)
        {
            for (int x = 0; x < n - 1; x++)
            {
                bool isSwapped = false;
                for (int y = 0; y < n - x - 1; y++)
                {
                    if (arr[y].NoOfEmployees > arr[y + 1].NoOfEmployees)
                    {
                        Company temp = arr[y];
                        arr[y]=arr[y + 1];
                        arr[y + 1] = temp;
                       
                        isSwapped = true;
                    }
                }
                if (!isSwapped)
                {
                    break;
                }
            }
            return arr;
        }
        public static List<Company> bubbleSortWithIndex(List<Company> arr, int n)
        {
            for (int x = 0; x < n - 1; x++)
            {
                bool isSwapped = false;
                for (int y = 0; y < n - x - 1; y++)
                {
                    if (arr[y].Index > arr[y + 1].Index)
                    {
                        Company temp = arr[y];
                        arr[y] = arr[y + 1];
                        arr[y + 1] = temp;
                        isSwapped = true;
                    }
                }
                if (!isSwapped)
                {
                    break;
                }
            }
            return arr;
        }
        public static int findMinimumEmployee(List<Company> arr, int start, int end)
        {
            int min = arr[start].NoOfEmployees;
            int minIndex = start;
            for (int x = start; x < end; x++)
            {
                if (min > arr[x].NoOfEmployees)
                {
                    min = arr[x].NoOfEmployees;
                    minIndex = x;
                }
            }
            return minIndex;
        }
        public static int findMinimumIndex(List<Company> arr, int start, int end)
        {
            int min = arr[start].Index;
            int minIndex = start;
            for (int x = start; x < end; x++)
            {
                if (min > arr[x].Index)
                {
                    min = arr[x].Index;
                    minIndex = x;
                }
            }
            return minIndex;
        }
        public static List<Company> selectionSortWithEmployees(List<Company> arr, int n)
        {
            for (int x = 0; x < n - 1; x++)
            {
                int minIndex = findMinimumEmployee(arr, x, n);
                Company temp = arr[x];
                arr[x] = arr[minIndex];
                arr[minIndex] = temp;
            }
            return arr;
        }
        public static List<Company> selectionSortWithIndex(List<Company> arr, int n)
        {
            for (int x = 0; x < n - 1; x++)
            {
                int minIndex = findMinimumIndex(arr, x, n);
                Company temp = arr[x];
                arr[x] = arr[minIndex];
                arr[minIndex] = temp;
             
            }
            return arr;
        }
        public static List<Company> insertionSortWithEmployees(List<Company> arr, int n)
        {
            for (int x = 1; x < n; x++)
            {
                Company key = arr[x];
                int y = x - 1;
                while (y >= 0 && arr[y].NoOfEmployees > key.NoOfEmployees)
                {
                    arr[y + 1] = arr[y];
                    y--;
                }
                arr[y + 1] = key;
            }
            return arr;
        }
        public static List<Company> insertionSortWithIndex(List<Company> arr, int n)
        {
            for (int x = 1; x < n; x++)
            {
                Company key = arr[x];
                int y = x - 1;
                while (y >= 0 && arr[y].Index > key.Index)
                {
                    arr[y + 1] = arr[y];
                    y--;
                }
                arr[y + 1] = key;
            }
            return arr;
        }
        public static List<Company> mergeSortWithIndex(List<Company> arr, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                mergeSortWithIndex(arr, start, mid);
                mergeSortWithIndex(arr, mid + 1, end);
                mergeWithIndex(arr, start, mid, end);
            }
            return arr;
        }
        public static void mergeWithIndex(List<Company> arr, int start, int mid, int end)
        {
            int i = start;
            int j = mid + 1;
            Queue<Company> tempArr = new Queue<Company>();
            while (i <= mid && j <= end)
            {
                if (arr[i].Index < arr[j].Index)
                {
                    tempArr.Enqueue(arr[i]);
                    i++;
                }
                else
                {
                    tempArr.Enqueue(arr[j]);
                    j++;
                }
            }
            while (i <= mid)
            {
                tempArr.Enqueue(arr[i]);
                i++;
            }
            while (j <= end)
            {
                tempArr.Enqueue(arr[j]);
                j++;
            }
            for (int x = start; x <= end; x++)
            {
                arr[x] = tempArr.Peek();
                tempArr.Dequeue();
            }
        }
        public static List<Company> mergeSortWithEmployees(List<Company> arr, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                mergeSortWithEmployees(arr, start, mid);
                mergeSortWithEmployees(arr, mid + 1, end);
                mergeWithEmployees(arr, start, mid, end);
            }
            return arr;
        }
        public static void mergeWithEmployees(List<Company> arr, int start, int mid, int end)
        {
            int i = start;
            int j = mid + 1;
            Queue<Company> tempArr = new Queue<Company>();
            while (i <= mid && j <= end)
            {
                if (arr[i].NoOfEmployees < arr[j].NoOfEmployees)
                {
                    tempArr.Enqueue(arr[i]);
                    i++;
                }
                else
                {
                    tempArr.Enqueue(arr[j]);
                    j++;
                }
            }
            while (i <= mid)
            {
                tempArr.Enqueue(arr[i]);
                i++;
            }
            while (j <= end)
            {
                tempArr.Enqueue(arr[j]);
                j++;
            }
            for (int x = start; x <= end; x++)
            {
                arr[x] = tempArr.Peek();
                tempArr.Dequeue();
            }
        }
        public static bool compare(Company a, Company b)
        {
            return a.NoOfEmployees < b.NoOfEmployees;
        }
        public static List<Company> quickSortWithEmployees(List<Company> arr, int start, int end)
        {
            if (start < end)
            {
             
                int pivot = random.Next(start, end);
                Company temp1 = arr[start];
                arr[start] = arr[pivot];
                arr[pivot] = temp1;
                pivot = start;
                int mid = partitionWithEmployees(arr, start+1 , end, pivot);
                quickSortWithEmployees(arr, start, mid - 1);
                quickSortWithEmployees(arr, mid + 1, end);
            }
            return arr;
        }
        public static int partitionWithEmployees(List<Company> arr, int start, int end, int pivot)
        {
            int left = start;
            int right = end;
            while (left <= right)
            {
                while (left <= end && arr[left].NoOfEmployees < arr[pivot].NoOfEmployees)
                {
                    left++;
                }
                while (right >= start && arr[right].NoOfEmployees >= arr[pivot].NoOfEmployees)
                {
                    right--;
                }
                if (left < right)
                {
                    Company temp1 = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp1;

                }
                
            }
            Company temp = arr[pivot];
            arr[pivot] = arr[right];
            arr[right] = temp;
          
            return right;
        }
        public static List<Company> quickSortWithIndex(List<Company> arr, int start, int end)
        {
            if (start < end)
            {
                int pivot = random.Next(start, end);
                Company temp1 = arr[start];
                arr[start] = arr[pivot];
                arr[pivot] = temp1;
                pivot = start;
                int mid = partitionWithIndex(arr, start + 1, end, pivot);
                quickSortWithIndex(arr, start, mid - 1);
                quickSortWithIndex(arr, mid + 1, end);
            }
            return arr;
        }
        public static int partitionWithIndex(List<Company> arr, int start, int end, int pivot)
        {
            int left = start;
            int right = end;
            while (left <= right)
            {
                while (left <= end && arr[left].Index < arr[pivot].Index)
                {
                    left++;
                }
                while (right >= start && arr[right].Index >= arr[pivot].Index)
                {
                    right--;
                }
                if (left < right)
                {
                    Company temp1 = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp1;

                }
            }
            Company temp = arr[pivot];
            arr[pivot] = arr[right];
            arr[right] = temp;

            return right;
        }
        public static int parentIndex(int i)
        {
            return (i - 1) / 2;
        }
        public static int leftChildIndex(int i)
        {
            return (2 * i) + 1;
        }
        public static int rightChildIndex(int i)
        {
            return (2 * i) + 2;
        }
        public static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static void heapifyWithIndex(List<Company> arr, int size, int index)
        {
            int maxIndex;
            while (true)
            {
                int lIdx = leftChildIndex(index);
                int rIdx = rightChildIndex(index);
                if (rIdx >= size)
                {
                    if (lIdx >= size)
                        return;
                    else
                    {
                        maxIndex = lIdx;
                    }
                }
                else
                {
                    if (arr[lIdx].Index >= arr[rIdx].Index)
                    {
                        maxIndex = lIdx;
                    }
                    else
                    {
                        maxIndex = rIdx;
                    }
                }
                if (arr[index].Index < arr[maxIndex].Index)
                {
                    Company temp = arr[index];
                    arr[index] = arr[maxIndex];
                    arr[maxIndex] = temp;
                    index = maxIndex;
                }
                else
                    return;
            }
        }
        public static List<Company> heapSortWithIndex(List<Company> arr, int size)
        {
            for (int x = (size / 2) - 1; x >= 0; x--)
            {
                heapifyWithIndex(arr, size, x);
            }
            for (int x = size - 1; x > 0; x--)
            {
                
                Company temp = arr[0];
                arr[0] = arr[x];
                arr[x] = temp;
                heapifyWithIndex(arr, x, 0);
            }
            return arr;
        }
        public static void heapifyWithEployees(List<Company> arr, int size, int index)
        {
            int maxIndex;
            while (true)
            {
                int lIdx = leftChildIndex(index);
                int rIdx = rightChildIndex(index);
                if (rIdx >= size)
                {
                    if (lIdx >= size)
                        return;
                    else
                    {
                        maxIndex = lIdx;
                    }
                }
                else
                {
                    if (arr[lIdx].NoOfEmployees >= arr[rIdx].NoOfEmployees)
                    {
                        maxIndex = lIdx;
                    }
                    else
                    {
                        maxIndex = rIdx;
                    }
                }
                if (arr[index].NoOfEmployees < arr[maxIndex].NoOfEmployees)
                {

                    Company temp = arr[index];
                    arr[index] = arr[maxIndex];
                    arr[maxIndex] = temp;
                    index = maxIndex;
                }
                else
                    return;
            }
        }
        public static List<Company> heapSortWithEmployees(List<Company> arr, int size)
        {
            for (int x = (size / 2) - 1; x >= 0; x--)
            {
                heapifyWithEployees(arr, size, x);
            }
            for (int x = size - 1; x > 0; x--)
            {
                Company temp = arr[0];
                arr[0] = arr[x];
                arr[x] = temp;
                heapifyWithEployees(arr, x, 0);
            }
            return arr;
        }
        public static List<Company> countingSortWithEmployees(List<Company> arr)
        {

            int max = findMaximumEmployee(arr);
            List<int> count = new List<int>(new int[max + 1]);
            List<Company> output = new List<Company>(new Company[arr.Count]);
            for (int x = 0; x < arr.Count; x++)
            {
                count[arr[x].NoOfEmployees]++;
            }
            for (int x = 1; x < count.Count; x++)
            {
                count[x] = count[x - 1] + count[x];
            }
            for (int x = arr.Count - 1; x >= 0; x--)
            {
                int index = count[arr[x].NoOfEmployees] - 1;
                count[arr[x].NoOfEmployees]--;
                output[index] = arr[x];
            }
            return output;
        }
        public static int findMaximumEmployee(List<Company> vec)
        {
            int max = vec[0].NoOfEmployees;
            foreach (var a in vec)
            {
                if (max < a.NoOfEmployees)
                {
                    max = a.NoOfEmployees;
                }
            }
            return max;
        }
        public static List<Company> countingSortWithIndex(List<Company> arr)
        {

            int max = findMaximumIndex(arr);
            List<int> count = new List<int>(new int[max + 1]);
            List<Company> output = new List<Company>(new Company[arr.Count]);
            for (int x = 0; x < arr.Count; x++)
            {
                count[arr[x].Index]++;
            }
            for (int x = 1; x < count.Count; x++)
            {
                count[x] = count[x - 1] + count[x];
            }
            for (int x = arr.Count - 1; x >= 0; x--)
            {
                int index = count[arr[x].Index] - 1;
                count[arr[x].Index]--;
                output[index] = arr[x];
            }
            return output;
        }
        public static int findMaximumIndex(List<Company> vec)
        {
            int max = vec[0].Index;
            foreach (var a in vec)
            {
                if (max < a.Index)
                {
                    max = a.Index;
                }
            }
            return max;
        }
        public static List<Company> radixSortWithEmployees(List<Company> arr)
        {

            int max = findMaximumEmployee(arr);
            int place = 1;
            while ((max / place) > 0)
            {
                countingSortWithEmployees(ref arr, place);
                place = place * 10;
            }
            return arr;
        }
        public static List<Company> radixSortWithIndex(List<Company> arr)
        {

            int max = findMaximumIndex(arr);
            int place = 1;
            while ((max / place) > 0)
            {
                countingSortWithIndex(ref arr, place);
                place = place * 10;
            }
            return arr;
        }
        public static void countingSortWithEmployees(ref List<Company> arr, int place)
        {
            List<int> count = new List<int>(new int[10]);
            List<Company> output = new List<Company>(new Company[arr.Count]);
            for (int x = 0; x < arr.Count; x++)
            {
                count[(arr[x].NoOfEmployees / place) % 10]++;
            }
            for (int x = 1; x < count.Count; x++)
            {
                count[x] = count[x - 1] + count[x];
            }
            for (int x = arr.Count - 1; x >= 0; x--)
            {
                int index = count[(arr[x].NoOfEmployees / place) % 10] - 1;
                count[(arr[x].NoOfEmployees / place) % 10]--;
                output[index] = arr[x];
            }
            arr = output;
        }
        public static void countingSortWithIndex(ref List<Company> arr, int place)
        {
            List<int> count = new List<int>(new int[10]);
            List<Company> output = new List<Company>(new Company[arr.Count]);
            for (int x = 0; x < arr.Count; x++)
            {
                count[(arr[x].Index / place) % 10]++;
            }
            for (int x = 1; x < count.Count; x++)
            {
                count[x] = count[x - 1] + count[x];
            }
            for (int x = arr.Count - 1; x >= 0; x--)
            {
                int index = count[(arr[x].Index / place) % 10] - 1;
                count[(arr[x].Index / place) % 10]--;
                output[index] = arr[x];
            }
            arr = output;
        }
        public static List<Company> bucketSortWithEmployyees(List<Company> arr, int noOfBuckets)
        {
           
            List<List<Company>> bucket = new List<List<Company>>();
            for (int i = 0; i < noOfBuckets; i++)
            {
                List<Company> companies = new List<Company>();
                bucket.Add(companies);
            }
            for (int x = 0; x < arr.Count; x++)
            {
                bucket[arr[x].NoOfEmployees].Add(arr[x]);
            }
          /*  for (int x = 0; x < bucket.Count; x++)
            {
                if (bucket[x].Count!=0)
                bucket[x].Sort((a, b) => a.NoOfEmployees.CompareTo(b.NoOfEmployees));

            }*/
            int index = 0;
           
            for (int x = 0; x < bucket.Count; x++)
            {
                for (int y = 0; y < bucket[x].Count; y++)
                {
                    arr[index]=(bucket[x][y]);
                    index++;
                }
            }
            return arr;
        }
        public static List<Company> bucketSortWithIndex(List<Company> arr, int noOfBuckets)
        {
            int max = findMaximumIndex(arr);
            List<List<Company>> bucket = new List<List<Company>>();
            for (int i = 0; i < max+1; i++)
            {
                List<Company> companies = new List<Company>();
                bucket.Add(companies);
            }
            for (int x = 0; x < arr.Count; x++)
            {
                bucket[arr[x].Index].Add(arr[x]);
            }
         /*  for (int x = 0; x < bucket.Count; x++)
            {
                    bucket[x].Sort((a, b) => a.Index.CompareTo(b.Index));

            }*/
            int index = 0;

            for (int x = 0; x < bucket.Count; x++)
            {
                for (int y = 0; y < bucket[x].Count; y++)
                {
                    arr[index] = (bucket[x][y]);
                    index++;
                }
            }
            return arr;
        }
    }
}
