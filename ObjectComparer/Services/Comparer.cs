using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool AreSimilar<T>(T first, T second)
        {
            /// Add your implementation logic here. Feel free to add classes and types as required for your solution.
            bool flag = true;
            bool match = false;
            int countFirst, countSecond;
            if (first == null && second == null)
            {
                return flag;
            }
            else
            {
                foreach (PropertyInfo propObj1 in first.GetType().GetProperties())
                {
                    var propObj2 = second.GetType().GetProperty(propObj1.Name);
                    if (propObj1.PropertyType.Name.Equals("List`1"))
                    {
                        dynamic objList1 = propObj1.GetValue(first, null);
                        dynamic objList2 = propObj2.GetValue(second, null);
                        countFirst = objList1.Count;
                        countSecond = objList2.Count;
                        if (countFirst == countSecond)
                        {
                            countFirst = objList1.Count - 1;
                            while (countFirst > -1)
                            {
                                match = false;
                                countSecond = objList2.Count - 1;
                                while (countSecond > -1)
                                {
                                    match = AreSimilar(objList1[countFirst], objList2[countSecond]);
                                    if (match)
                                    {
                                        objList2.Remove(objList2[countSecond]);
                                        countSecond = -1;
                                        match = true;
                                    }
                                    if (match == false && countSecond == 0)
                                    {
                                        return false;
                                    }
                                    countSecond--;
                                }
                                countFirst--;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (propObj1.PropertyType.IsArray)
                    {
                        dynamic objList1 = ((IEnumerable<int>)propObj1.GetValue(first)).Cast<object>().OrderBy(y => y).ToList();
                        dynamic objList2 = ((IEnumerable<int>)propObj2.GetValue(second)).Cast<object>().OrderBy(y => y).ToList();// propObj2.GetValue(second, null);
                        countFirst = objList1.Count;
                        countSecond = objList2.Count;
                        if (countFirst == countSecond)
                        {
                            countFirst = objList1.Count - 1;
                            while (countFirst > -1)
                            {
                                match = false;
                                countSecond = objList2.Count - 1;
                                while (countSecond > -1)
                                {
                                    var m = objList1[countFirst];
                                    var n = objList2[countSecond];
                                    if (m == n)
                                    {
                                        match = true;
                                        objList2.Remove(objList2[countSecond]);
                                        countSecond = -1;
                                        match = true;
                                    }
                                    if (match == false && countSecond == 0)
                                    {
                                        return false;
                                    }
                                    countSecond--;
                                }
                                countFirst--;
                            }

                        }

                        else
                        {
                            return false;
                        }
                    }
                    else if (!(propObj1.GetValue(first, null).Equals(propObj2.GetValue(second, null))))
                    {
                        flag = false;
                        return flag;
                    }
                }
                return flag;
            }
        }
    }
}
