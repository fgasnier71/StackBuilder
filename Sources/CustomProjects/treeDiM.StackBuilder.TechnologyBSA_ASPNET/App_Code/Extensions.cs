using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Extensions
/// </summary>
public static class Extensions
{
	public static void Foreach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        if (collection != null)
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                action.Invoke(enumerator.Current);
            }
        }
    }
}