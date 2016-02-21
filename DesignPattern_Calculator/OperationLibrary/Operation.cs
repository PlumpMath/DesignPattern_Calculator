using System;

namespace OperationLibrary
{
    /// <summary>
    /// 运算类
    /// </summary>
    public class Operation
    {
        private double _numberA = 0;
        private double _numberB = 0;
        /// <summary>
        /// 第一个运算数
        /// </summary>
        public double NumberA
        {
            get
            {
                return _numberA;
            }

            set
            {
                _numberA = value;
            }
        }
        /// <summary>
        /// 第二个运算数
        /// </summary>
        public double NumberB
        {
            get
            {
                return _numberB;
            }

            set
            {
                _numberB = value;
            }
        }
        /// <summary>
        /// 获得结果
        /// </summary>
        /// <returns></returns>
        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
        /// <summary>
        /// 检查输入的字符串是否准确
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string CheckNumberInput(string currentNumber, string inputString)
        {
            string result = "";
            if (inputString == ".")
            {
                if (currentNumber.IndexOf(".") < 0)
                {
                    if (currentNumber.Length == 0)
                        result = "0" + inputString;
                    else
                        result = currentNumber + inputString;
                }
            }
            else if (currentNumber == "0")
            {
                result = inputString;
            }
            else
            {
                result = currentNumber + inputString;
            }

            return result;
        }
    }
    /// <summary>
    /// 加法运算类
    /// </summary>
    public class OperationAdd : Operation
    {
        /// <summary>
        /// 加法运算结果
        /// </summary>
        /// <returns></returns>
        public override double GetResult()
        {
            double result = 0;
            result = NumberA + NumberB;
            return result;
        }
    }
    /// <summary>
    /// 除法运算类
    /// </summary>
    public class OperationDiv : Operation
    {
        /// <summary>
        /// 除法运算结果
        /// </summary>
        /// <returns></returns>
        public override double GetResult()
        {
            double result = 0;
            if (NumberB == 0)
            {
                throw new Exception("除数不能为0.");
            }
            result = NumberA / NumberB;
            return result;
        }
    }
    /// <summary>
    ///  乘法运算类
    /// </summary>
    public class OperationMul : Operation
    {
        /// <summary>
        /// 乘法运算
        /// </summary>
        /// <returns></returns>
        public override double GetResult()
        {

            double result = 0;
            result = NumberA * NumberB;
            return result;
        }
    }
    /// <summary>
    /// 减法运算类
    /// </summary>
    public class OperationSub : Operation
    {
        /// <summary>
        /// 减法运算结果
        /// </summary>
        /// <returns></returns>
        public override double GetResult()
        {
            double result = 0;
            result = NumberA - NumberB;
            return result;
        }
    }
    /// <summary>
    /// 平方类
    /// </summary>
    class OperationSqr : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberB * NumberB;
            return result;
        }
    }

    /// <summary>
    /// 平方根类
    /// </summary>
    class OperationSqrt : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if (NumberB < 0)
                throw new Exception("负数不能开平方根。");
            result = Math.Sqrt(NumberB);
            return result;
        }
    }
    /// <summary>
    /// 相反数类
    /// </summary>
    class OperationReverse : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = -NumberB;
            return result;
        }
    }
    public class OperationFactory
    {
        public static Operation createOperate(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    {
                        oper = new OperationAdd();
                        break;
                    }
                case "-":
                    {
                        oper = new OperationSub();
                        break;
                    }
                case "*":
                    {
                        oper = new OperationMul();
                        break;
                    }
                case "/":
                    {
                        oper = new OperationDiv();
                        break;
                    }
                case "sqr":
                    {
                        oper = new OperationSqr();
                        break;
                    }
                case "sqrt":
                    {
                        oper = new OperationSqrt();
                        break;
                    }
                case "+/-":
                    {
                        oper = new OperationReverse();
                        break;
                    }
            }
            return oper;
        }
    }
}
