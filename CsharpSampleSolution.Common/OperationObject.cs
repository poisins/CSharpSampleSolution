namespace CsharpSampleSolution.Common
{
    using System;
    using System.Globalization;

    public class OperationObject<T1, T2> : IOperationObject
        where T1 : struct, IComparable, IComparable<T1>, IConvertible, IEquatable<T1>, IFormattable
        where T2 : struct, IComparable, IComparable<T2>, IConvertible, IEquatable<T2>, IFormattable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationObject{T1, T2}"/> class.
        /// </summary>
        /// <param name="a">Value which will be modified (subtracted from)</param>
        /// <param name="b">Value which will be used as modifier (value to be subtracted)</param>
        public OperationObject(T1 a, T2 b)
        {
            this.A = Convert.ToDecimal(a, CultureInfo.InvariantCulture);
            this.B = Convert.ToDecimal(b, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets or sets base value
        /// <para>E.g. Value which will be modified (subtracted from)</para>
        /// </summary>
        public decimal A { get; set; }

        /// <summary>
        /// Gets or sets modifier value
        /// <para>E.g. Value which will be used as modifier (value to be subtracted)</para>
        /// </summary>
        public decimal B { get; set; }
    }
}
