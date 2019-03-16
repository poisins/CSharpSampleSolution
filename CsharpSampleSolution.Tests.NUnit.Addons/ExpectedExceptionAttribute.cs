﻿namespace NUnit.Framework
{
    using System;
    using NUnit.Framework.Interfaces;
    using NUnit.Framework.Internal;
    using NUnit.Framework.Internal.Commands;

    /// <summary>
    /// A simple ExpectedExceptionAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ExpectedExceptionAttribute : NUnitAttribute, IWrapTestMethod
    {
        private readonly Type expectedExceptionType;

        public ExpectedExceptionAttribute(Type type)
        {
            this.expectedExceptionType = type;
        }

        public TestCommand Wrap(TestCommand command)
        {
            return new ExpectedExceptionCommand(command, this.expectedExceptionType);
        }

        private class ExpectedExceptionCommand : DelegatingTestCommand
        {
            private readonly Type expectedType;

            public ExpectedExceptionCommand(TestCommand innerCommand, Type expectedType)
                : base(innerCommand)
            {
                this.expectedType = expectedType;
            }

            public override TestResult Execute(TestExecutionContext context)
            {
                Type caughtType = null;

                try
                {
                    this.innerCommand.Execute(context);
                }
                catch (Exception ex)
                {
                    if (ex is NUnitException)
                    {
                        ex = ex.InnerException;
                    }

                    caughtType = ex.GetType();
                }

                if (caughtType == this.expectedType)
                {
                    context.CurrentResult.SetResult(ResultState.Success);
                }
                else if (caughtType != null)
                {
                    context.CurrentResult.SetResult(
                        ResultState.Failure,
                        $"Expected '{this.expectedType.Name}' but got '{caughtType.Name}'");
                }
                else
                {
                    context.CurrentResult.SetResult(
                        ResultState.Failure,
                        $"Expected '{this.expectedType.Name}' but no exception was thrown");
                }

                return context.CurrentResult;
            }
        }
    }
}