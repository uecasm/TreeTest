namespace TreeTest.Shared;

internal static class LinqExtensions
{
    public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T>? list, Func<T, IEnumerable<T>?> childSelector)
    {
        var tree = new Stack<T>((list ?? Enumerable.Empty<T>()).Reverse());

        while (tree.Count > 0)
        {
            var current = tree.Pop();
            yield return current;

            foreach (var child in (childSelector(current) ?? Enumerable.Empty<T>()).Reverse())
            {
                tree.Push(child);
            }
        }
    }
}