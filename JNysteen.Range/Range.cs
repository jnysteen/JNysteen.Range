using System;
// ReSharper disable ConvertIfStatementToReturnStatement

namespace JNysteen.Range
{
    /// <summary>
    ///     A range of T
    /// </summary>
    /// <typeparam name="T">The type the range bounds</typeparam>
    public class Range<T> where T : struct, IComparable<T>
    {
        /// <summary>
        ///     Start of the range. If the range has no lower bound, this is `null`.
        /// </summary>
        public T? Start { get; }
        
        /// <summary>
        ///     End of the range. If the range has no upper bound, this is `null`.
        /// </summary>
        public T? End { get; }

        /// <summary>
        ///     Creates a new Range
        /// </summary>
        /// <param name="start">The start of the range (if any)</param>
        /// <param name="end">The end of the range (if any)</param>
        /// <exception cref="ArgumentException">Will be thrown if the start parameter is greater or equal to the end parameter, of both of the parameters are null</exception>
        public Range(T? start, T? end)
        {
            if(start == null && end == null)
                throw new ArgumentException($"The {nameof(start)} parameter and the {nameof(end)} parameter cannot both be null");
            
            if((start != null && end != null) && start.Value.CompareTo(end.Value) >= 0)
                throw new ArgumentException($"The {nameof(start)} parameter must be comparably smaller than the {nameof(end)} parameter");
            
            Start = start;
            End = end;
        }
        
        /// <summary>
        ///     Checks if this range overlaps with another range.
        /// </summary>
        /// <param name="otherRange">The range that might overlap with this range</param>
        /// <returns>`true` if the ranges overlap. `false` otherwise</returns>
        public bool OverlapsWith(Range<T> otherRange)
        {
            return (OverlapsWithInner(otherRange) || otherRange.OverlapsWithInner(this));
        }
        
        private bool OverlapsWithInner(Range<T> otherRange)
        {
            if (Start.HasValue && !otherRange.IsInRange(Start))
                return false;
            
            if (End.HasValue && !otherRange.IsInRange(End))
                return false;

            return true;
        } 

        /// <summary>
        ///     Checks if a given item is contained within this range
        /// </summary>
        /// <param name="item">The item to check against the range</param>
        /// <returns>`true` if the given item falls within the range. `false` otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if the item is null</exception>
        public bool IsInRange(T? item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (Start.HasValue && Start.Value.CompareTo(item.Value) > 0)
                return false;
            
            if (End.HasValue && End.Value.CompareTo(item.Value) < 0)
                return false;

            return true;
        }
    }
}