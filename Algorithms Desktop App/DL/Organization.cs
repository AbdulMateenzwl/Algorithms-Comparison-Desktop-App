using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms_Desktop_App.BL;
namespace Algorithms_Desktop_App.BL
{
    public class Data
    {
        private List<Org> vtr = new List<Org>();
        public void set_Data(List<Org> v)
        {
            vtr = v;
        }
        public List<Org> get_Data()
        {
            return vtr;
        }
        public void add_org(Org org)
        {
            vtr.Add(org);
        }
        public List<Org> sortData(int num, int value, List<Org> vtr)
        {
            num++;
            value++;
            if (num == 1) //   SelectionSort
            {
                if (value == 1)
                {
                    return SelectionSortByIndex(vtr);
                }
                else
                {
                    return SelectionSortByEmp(vtr);
                }
            }
            else if (num == 2) // BubbleSort
            {
                if (value == 1)
                {
                    return BubbleSortByIndex(vtr);
                }
                else
                {
                    return BubbleSortByEmp(vtr);
                }
            }
            else if (num == 3) // InsertionSort
            {
                if (value == 1)
                {
                    return InsertionSortByIndex(vtr);
                }
                else
                {
                    return InsertionSortByEmp(vtr);
                }
            }
            else if (num == 4) // Mergesort
            {
                if (value == 1)
                {
                    return mergeSortByIndex(vtr, 0, vtr.Count - 1);
                }
                else
                {
                    return mergeSortByEmp(vtr, 0, vtr.Count - 1);
                }
            }
            else if (num == 5)      //quick Sort
            {
                if (value == 1)
                {
                    return quickSortIndex(vtr, 0, vtr.Count - 1);
                }
                else
                {
                    return quickSortEmp(vtr, 0, vtr.Count - 1);
                }
            }
            else if (num == 6)      // Heap Sort
            {
                if (value == 1)
                {
                    return heapSortIndex(vtr);
                }
                else
                {
                    return heapSortEmp(vtr);
                }
            }
            else if (num == 7)      //count Sort
            {
                if (value == 1)
                {
                    return countSortIndex(vtr);
                }
                else
                {
                    return countSortEmp(vtr);
                }
            }
            else if (num == 8)      // Radix Sort
            {
                if (value == 1)
                {
                    return radixSortIndex(vtr);
                }
                else
                {
                    return radixSortEmp(vtr);
                }
            }
            else if (num == 9)
            {
                if (value == 1)
                {
                    return bucketSortWithIndex(vtr);
                }
                else
                {
                    return bucketSortWithEmp(vtr);
                }
            }
            return vtr;
        }
        // Selection Sort
        public List<Org> SelectionSortByIndex(List<Org> vtr)
        {
            for (int x = 0; x < vtr.Count - 1; x++)
            {
                int min = x;
                for (int i = x; i < vtr.Count; i++)
                {
                    if (vtr[i].index < vtr[min].index)
                    {
                        min = i;
                    }
                }
                Org m = vtr[x];
                vtr[x] = vtr[min];
                vtr[min] = m;
            }
            return vtr;
        }
        public List<Org> SelectionSortByEmp(List<Org> vtr)
        {
            int min = 0;
            for (int m = 0; m < vtr.Count; m++)
            {
                min = m;
                for (int i = m + 1; i < vtr.Count; i++)
                {
                    if (vtr[i].no_emp < vtr[min].no_emp)
                    {
                        min = i;
                    }
                }
                Org j = vtr[m];
                vtr[m] = vtr[min];
                vtr[min] = j;
                min = 0;
            }
            return vtr;
        }
        // Insertion Sort
        public List<Org> InsertionSortByIndex(List<Org> vtr)
        {
            for (int m = 1; m <= vtr.Count; m++)
            {
                for (int i = m - 1; i > 0; i--)
                {
                    if (vtr[i - 1].index > vtr[i].index)
                    {
                        Org j = vtr[i - 1];
                        vtr[i - 1] = vtr[i];
                        vtr[i] = j;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return vtr;
        }
        public List<Org> InsertionSortByEmp(List<Org> vtr)
        {
            for (int m = 1; m <= vtr.Count; m++)
            {
                for (int i = m - 1; i > 0; i--)
                {
                    if (vtr[i - 1].no_emp > vtr[i].no_emp)
                    {
                        Org j = vtr[i - 1];
                        vtr[i - 1] = vtr[i];
                        vtr[i] = j;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return vtr;
        }
        // Bubble Sort
        public List<Org> BubbleSortByIndex(List<Org> vtr)
        {
            for (int x = 0; x < vtr.Count - 1; x++)
            {
                bool isSwapped = false;
                for (int y = 0; y < vtr.Count - x - 1; y++)
                {
                    if (vtr[y].index > vtr[y + 1].index)
                    {
                        Org j = vtr[y];
                        vtr[y] = vtr[y + 1];
                        vtr[y + 1] = j;
                        isSwapped = true;
                    }
                }
                if (!isSwapped)
                {
                    break;
                }
            }
            return vtr;
        }
        public List<Org> BubbleSortByEmp(List<Org> vtr)
        {
            for (int x = 0; x < vtr.Count - 1; x++)
            {
                bool isSwapped = false;
                for (int y = 0; y < vtr.Count - x - 1; y++)
                {
                    if (vtr[y].no_emp > vtr[y + 1].no_emp)
                    {
                        Org j = vtr[y];
                        vtr[y] = vtr[y + 1];
                        vtr[y + 1] = j;
                        isSwapped = true;
                    }
                }
                if (!isSwapped)
                {
                    break;
                }
            }
            return vtr;
        }
        //Merge Sort
        public void mergeindex(List<Org> arr, int l, int m, int r)
        {
            int k;
            int n1 = m - l + 1;
            int n2 = r - m;

            List<Org> L = new List<Org>();
            List<Org> R = new List<Org>();

            for (int x = 0; x < n1; x++)
            {
                L.Add(arr[l + x]);
            }
            for (int a = 0; a < n2; a++)
            {
                R.Add(arr[m + 1 + a]);
            }

            int i = 0;
            int j = 0;
            k = l;

            while (i < n1 && j < n2)
            {
                if (L[i].index <= R[j].index)
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
        public List<Org> mergeSortByIndex(List<Org> arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                mergeSortByIndex(arr, l, m);
                mergeSortByIndex(arr, m + 1, r);
                mergeindex(arr, l, m, r);
            }
            return arr;
        }
        public void mergeEmp(List<Org> arr, int l, int m, int r)
        {
            int k;
            int n1 = m - l + 1;
            int n2 = r - m;

            List<Org> L = new List<Org>();
            List<Org> R = new List<Org>();

            for (int x = 0; x < n1; x++)
            {
                L.Add(arr[l + x]);
            }
            for (int a = 0; a < n2; a++)
            {
                R.Add(arr[m + 1 + a]);
            }

            int i = 0;
            int j = 0;
            k = l;

            while (i < n1 && j < n2)
            {
                if (L[i].no_emp <= R[j].no_emp)
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
        public List<Org> mergeSortByEmp(List<Org> arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                mergeSortByEmp(arr, l, m);
                mergeSortByEmp(arr, m + 1, r);
                mergeEmp(arr, l, m, r);
            }
            return arr;
        }
        // Quick Sort
        public List<Org> quickSortIndex(List<Org> arr, int l, int r)
        {
            if (l < r)
            {
                int pivot = partitionIndex(ref arr, l, r);
                quickSortIndex(arr, l, pivot - 1);
                quickSortIndex(arr, pivot + 1, r);
            }
            return arr;
        }
        public int partitionIndex(ref List<Org> arr, int start, int end)
        {
            int pivot = arr[start].index;
            int i = start + 1;
            int j = end;
            do
            {
                while (pivot >= arr[i].index)
                {
                    i++;
                }
                while (pivot < arr[j].index)
                {
                    j--;
                }
                if (i < j)
                {
                    Org orgit = arr[i];
                    arr[i] = arr[j];
                    arr[j] = orgit;
                }
            } while (i < j);
            Org gt = arr[i];
            arr[i] = arr[j];
            arr[j] = gt;
            return j;
        }
        public List<Org> quickSortEmp(List<Org> arr, int l, int r)
        {
            if (l < r)
            {
                int pivot = partitionEmp(ref arr, l, r);
                quickSortEmp(arr, l, pivot - 1);
                quickSortEmp(arr, pivot + 1, r);
            }
            return arr;
        }
        public int partitionEmp(ref List<Org> arr, int start, int end)
        {
            int pivot = arr[start].no_emp;
            int i = start + 1;
            int j = end;
            do
            {
                while (pivot >= arr[i].no_emp)
                {
                    i++;
                }
                while (pivot < arr[j].no_emp)
                {
                    j--;
                }
                if (i < j)
                {
                    Org orgit = arr[i];
                    arr[i] = arr[j];
                    arr[j] = orgit;
                }
            } while (i < j);
            Org gt = arr[i];
            arr[i] = arr[j];
            arr[j] = gt;
            return j;
        }
        // Heap Sort
        public void heapifyIndex(List<Org> heapArr, int size, int index)
        {
            int maxIndex;
            while (true)
            {
                int lIdx = index * 2 + 1;
                int rIdx = index * 2 + 2;
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
                    if (heapArr[lIdx].index >= heapArr[rIdx].index)
                    {
                        maxIndex = lIdx;
                    }
                    else
                    {
                        maxIndex = rIdx;
                    }
                }
                if (heapArr[index].index < heapArr[maxIndex].index)
                {
                    Org obj = heapArr[index];
                    heapArr[index] = heapArr[maxIndex];
                    heapArr[maxIndex] = obj;
                    index = maxIndex;
                }
                else
                    return;
            }
        }
        public List<Org> heapSortIndex(List<Org> arr)
        {
            for (int x = (arr.Count / 2) - 1; x >= 0; x--)
            {
                heapifyIndex(arr, arr.Count, x);
            }
            for (int x = arr.Count - 1; x > 0; x--)
            {
                Org ty = arr[x];
                arr[x] = arr[0];
                arr[0] = ty;
                heapifyIndex(arr, x, 0);
            }
            return arr;
        }
        public void heapifyEmp(List<Org> heapArr, int size, int index)
        {
            int maxIndex;
            while (true)
            {
                int lIdx = index * 2 + 1;
                int rIdx = index * 2 + 2;
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
                    if (heapArr[lIdx].no_emp >= heapArr[rIdx].no_emp)
                    {
                        maxIndex = lIdx;
                    }
                    else
                    {
                        maxIndex = rIdx;
                    }
                }
                if (heapArr[index].no_emp < heapArr[maxIndex].no_emp)
                {
                    Org obj = heapArr[index];
                    heapArr[index] = heapArr[maxIndex];
                    heapArr[maxIndex] = obj;
                    index = maxIndex;
                }
                else
                    return;
            }
        }
        public List<Org> heapSortEmp(List<Org> arr)
        {
            for (int x = (arr.Count / 2) - 1; x >= 0; x--)
            {
                heapifyEmp(arr, arr.Count, x);
            }
            for (int x = arr.Count - 1; x > 0; x--)
            {
                Org ty = arr[x];
                arr[x] = arr[0];
                arr[0] = ty;
                heapifyEmp(arr, x, 0);
            }
            return arr;
        }
        // Count Sort
        public List<Org> countSortIndex(List<Org> arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i].index > max)
                {
                    max = arr[i].index;
                }
            }
            List<int> count = new List<int>(Enumerable.Repeat(0, max + 1));
            List<Org> output = new List<Org>(Enumerable.Repeat(new Org(), arr.Count));
            for (int x = 0; x < arr.Count; x++)
            {
                count[arr[x].index]++;
            }
            for (int x = 1; x < count.Count; x++)
            {
                count[x] = count[x - 1] + count[x];
            }
            for (int x = arr.Count - 1; x >= 0; x--)
            {
                int index = count[arr[x].index] - 1;
                count[arr[x].index]--;
                output[index] = arr[x];
            }
            return output;
        }
        public List<Org> countSortEmp(List<Org> arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i].no_emp > max)
                {
                    max = arr[i].no_emp;
                }
            }
            List<int> count = new List<int>(Enumerable.Repeat(0, max + 1));
            List<Org> output = new List<Org>(Enumerable.Repeat(new Org(), arr.Count));
            for (int x = 0; x < arr.Count; x++)
            {
                count[arr[x].no_emp]++;
            }
            for (int x = 1; x < count.Count; x++)
            {
                count[x] = count[x - 1] + count[x];
            }
            for (int x = arr.Count - 1; x >= 0; x--)
            {
                int index = count[arr[x].no_emp] - 1;
                count[arr[x].no_emp]--;
                output[index] = arr[x];
            }
            return output;
        }
        // Radix Sort
        public void radixCountingIndex(ref List<Org> arr, int place)
        {
            List<int> count = new List<int>(Enumerable.Repeat(0, 10));
            List<Org> output = new List<Org>(Enumerable.Repeat(new Org(), arr.Count));
            for (int x = 0; x < arr.Count; x++)
            {
                count[(arr[x].index / place) % 10]++;
            }
            for (int x = 1; x < count.Count; x++)
            {
                count[x] = count[x - 1] + count[x];
            }
            for (int x = arr.Count - 1; x >= 0; x--)
            {
                int index = count[(arr[x].index / place) % 10] - 1;
                count[(arr[x].index / place) % 10]--;
                output[index] = arr[x];
            }
            for (int x = 0; x < output.Count; x++)
            {
                arr[x] = output[x];
            }
        }
        public List<Org> radixSortIndex(List<Org> arr)
        {
            int max = 0;
            foreach (var a in arr)
            {
                if (a.index > max)
                {
                    max = a.index;
                }
            }
            int place = 1;
            while ((max / place) > 0)
            {
                radixCountingIndex(ref arr, place);
                place = place * 10;
            }
            return arr;
        }
        public void radixCountingEmp(ref List<Org> arr, int place)
        {
            List<int> count = new List<int>(Enumerable.Repeat(0, 10));
            List<Org> output = new List<Org>(Enumerable.Repeat(new Org(), arr.Count));
            for (int x = 0; x < arr.Count; x++)
            {
                count[(arr[x].no_emp / place) % 10]++;
            }
            for (int x = 1; x < count.Count; x++)
            {
                count[x] = count[x - 1] + count[x];
            }
            for (int x = arr.Count - 1; x >= 0; x--)
            {
                int index = count[(arr[x].no_emp / place) % 10] - 1;
                count[(arr[x].no_emp / place) % 10]--;
                output[index] = arr[x];
            }
            for (int x = 0; x < output.Count; x++)
            {
                arr[x] = output[x];
            }
        }
        public List<Org> radixSortEmp(List<Org> arr)
        {
            int max = 0;
            foreach (var a in arr)
            {
                if (a.no_emp > max)
                {
                    max = a.no_emp;
                }
            }
            int place = 1;
            while ((max / place) > 0)
            {
                radixCountingEmp(ref arr, place);
                place = place * 10;
            }
            return arr;
        }
        // Bucket Sort
        public List<Org> bucketSortWithIndex(List<Org> arr)
        {
            int noOfBuckets = arr.Count+1;
            List<List<Org>> bucket = new List<List<Org>>();
            for (int i = 0; i < noOfBuckets; i++)
            {
                List<Org> companies = new List<Org>();
                bucket.Add(companies);
            }
            for (int x = 0; x < arr.Count; x++)
            {
                bucket[arr[x].index].Add(arr[x]);
            }
            for (int x = 0; x < bucket.Count; x++)
            {
                if (bucket[x].Count != 0)
                {
                    bucket[x].Sort((a, b) => a.index.CompareTo(b.index));
                }

            }
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
        public List<Org> bucketSortWithEmp(List<Org> arr)
        {
            int noOfBuckets = 10000;
            List<List<Org>> bucket = new List<List<Org>>();
            for (int i = 0; i < noOfBuckets; i++)
            {
                List<Org> companies = new List<Org>();
                bucket.Add(companies);
            }
            for (int x = 0; x < arr.Count; x++)
            {
                bucket[arr[x].no_emp].Add(arr[x]);
            }
            for (int x = 0; x < bucket.Count; x++)
            {
                if (bucket[x].Count != 0)
                {
                    bucket[x].Sort((a, b) => a.no_emp.CompareTo(b.no_emp));
                }

            }
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

