using System;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_ExcelConvertTool
{
    /// <summary>
    /// 列表拓展
    /// </summary>
    public static class IListExtension
    {
        /// <summary>
        /// 匹配
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="fromList">源列表</param>
        /// <param name="toList">配对列表</param>
        /// <returns></returns>
        public static bool ICompareTo<T>(this IList<T> fromList, IList<T> toList)
        {
            if (fromList.Count != toList.Count) { return false; }

            foreach (T t in fromList)
            {
                if (!toList.Contains(t))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 是否包含某元素
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="iList">列表</param>
        /// <param name="element">元素</param>
        /// <returns></returns>
        public static bool IContains<T>(this IList<T> iList, T element)
        {
            if (!iList.Contains(element))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 根据元素 返回下标
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="iList">列表</param>
        /// <param name="element">元素</param>
        /// <returns></returns>
        public static int IIndexOf<T>(this IList<T> iList, T element)
        {
            if (!iList.Contains(element))
            {
                return -1;
            }
            else
            {
                return iList.IndexOf(element);
            }
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="iList">列表</param>
        /// <param name="index">插入索引</param>
        /// <param name="element">元素</param>
        public static List<T> IInsert<T>(this IList<T> iList, int index, T element)
        {
            if (index >= 0 && index < iList.Count)
            {
                List<T> list = new List<T>();
                iList.IForEach(iListElement => list.Add(iListElement));

                list.Insert(index, element);

                return list;
            }
            else
            {
                return null;
                throw new FormatException("元素超索引");
            }
        }

        /// <summary>
        /// 删除元素
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="iList">列表</param>
        /// <param name="element">元素</param>
        /// <returns></returns>
        public static List<T> IRemove<T>(this IList<T> iList, T element)
        {
            if (iList.Contains(element))
            {
                List<T> list = new List<T>();
                iList.IForEach(iListElement => list.Add(iListElement));

                list.Remove(element);
                return list;
            }
            else
            {
                return null;
                throw new FormatException($"列表中不存在元素:{element}");
            }
        }

        /// <summary>
        /// 删除元素
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="iList">列表</param>
        /// <param name="index">元素索引</param>
        /// <returns></returns>
        public static List<T> IRemoveAt<T>(this IList<T> iList, int index)
        {
            if (index >= 0 && index < iList.Count)
            {
                List<T> list = new List<T>();
                iList.IForEach(iListElement => list.Add(iListElement));

                list.RemoveAt(index);
                return list;
            }
            else
            {
                return null;
                throw new FormatException($"列表中不存在索引为{index}的元素");
            }
        }

        /// <summary>
        /// 排序 返回列表
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="iList">列表</param>
        /// <returns></returns>
        public static List<T> ISort<T>(this IList<T> iList)
        {
            List<T> list = new List<T>();

            iList.IForEach(element => list.Add(element));

            list.Sort();

            return list;
        }

        /// <summary>
        /// 排序 返回列表
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="iList"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<T> ISort<T, TValue>(this IList<T> iList, Func<T, TValue> predicate)
        {
            try
            {
                return iList.OrderBy(predicate).ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 倒序 返回列表
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="iList">列表</param>
        /// <returns></returns>
        public static List<T> IReverse<T>(this IList<T> iList)
        {
            List<T> list = new List<T>();

            iList.IForEach(element => list.Add(element));
            list.Sort();
            list.Reverse();

            return list;
        }

        /// <summary>
        /// 倒序 返回列表
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="iList"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<T> IReverse<T, TValue>(this IList<T> iList, Func<T, TValue> predicate)
        {
            try
            {
                return iList.OrderByDescending(predicate).ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 数组 for 循环
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="iList">类型-自动识别</param>
        /// <param name="predicate"></param>
        public static void IFor<T>(this IList<T> iList, Action<int, T> predicate)
        {
            for (int i = 0; i < iList.Count; i++)
            {
                predicate(i, iList[i]);
            }
        }

        /// <summary>
        /// 数组 ForEach
        /// </summary>
        /// <typeparam name="T">类型-自动识别</typeparam>
        /// <param name="iList">IList</param>
        /// <param name="predicate">指定类型回调</param>
        public static void IForEach<T>(this IList<T> iList, Action<T> predicate)
        {
            foreach (var item in iList)
            {
                predicate(item);
            }
        }

        /// <summary>
        /// Linq 查询 返回元素
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="iList"></param>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        public static T ILinqGet<T>(this IList<T> iList, Func<T, bool> predicate)
        {
            try { return iList.First(predicate); }
            catch { return default(T); }
        }

        /// <summary>
        /// Linq 查询 返回列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iList"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<T> ILinqGetList<T>(this IList<T> iList, Func<T, bool> predicate)
        {
            try { return iList.Where(predicate).ToList(); }
            catch { return null; }
        }
    }
}
